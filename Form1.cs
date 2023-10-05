using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using _5_Lab_4_Sem;

namespace _6_Lab_4_Sem
{
    public partial class Form1 : Form
    {
        List<MarkerParams> markers = new List<MarkerParams>();

        List<FindObject> objects = new List<FindObject>();

        string errPath = "D:\\техзрение4сем\\5_Lab_4_Sem\\error\\err.png";

        VideoCapture capture;

        Mat imageSource = new Mat("D:\\техзрение4сем\\5_Lab_4_Sem\\error\\err.png");

        Mat source;

        Mat candidateToMarkerPerspective;

        CameraParams cameraParameters;

        OpenCvSharp.Point[][] candidates;

        const float markerWidth = 90f;

        const int markerFieldWidth = 306;

        const int numOfRowsInMarker = 9;

        Rect[] rectsOnMarker;

        MarkerParams findMarker;

        System.Drawing.Point cameraPosition;

        Bitmap map;

        float viewAngle;

        float prevViewAngle;

        string fsArr = "";

        public Form1()
        { 
            
            InitializeComponent();

            rectsOnMarker = Lab6Operations.MakeArrOfRects(markerFieldWidth / numOfRowsInMarker);
            rectsOnMarker = Lab6Operations.ReorgonizeArrOfRectsToSpiral(rectsOnMarker);
        }

        private void webCamBut_Click(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
            imageSource = Cv2.ImRead(errPath);
        }

        private void videoBut_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                capture.Open(openFileDialog1.FileName);
                imageSource = Cv2.ImRead(errPath);
            }
        }

        private void imgBut_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imageSource = Cv2.ImRead(openFileDialog1.FileName);
                capture = null;
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (cameraParameters == null) return;

            map = new Bitmap(200, 400);

            objects.Clear();

            //находим мат из сурса
            source?.Dispose();
            ReadMatFromSource(out source);

            //code
            candidates = null;
            candidates = Lab6Operations.FindCandidatesToMarkers(source);

            for (int i = 0; i < candidates.Length; i++)
            {

                float dist = Lab6Operations.FindDistToMarker(candidates[i], cameraParameters.MmInPixelsIn1m, markerWidth); // изменить ширину на высоту
                float angle = Lab6Operations.FindAngleOfTurn(candidates[i]);

                candidateToMarkerPerspective?.Dispose();
                candidateToMarkerPerspective = Lab6Operations.GetPerspectiveByContour(source, candidates[i], new OpenCvSharp.Size(markerFieldWidth, markerFieldWidth)); // размер одной ячейки при 306 на 306 = 34 пикселя

                candidateToMarkerPerspective = candidateToMarkerPerspective.CvtColor(ColorConversionCodes.BGR2GRAY);
                candidateToMarkerPerspective = candidateToMarkerPerspective.AdaptiveThreshold(100, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 401, 2);

                int code = Lab6Operations.FindCodeOnPerspectiveMarker(candidateToMarkerPerspective,rectsOnMarker);

                if (Lab6Operations.MarkerArrContains(markers, code, out findMarker))
                {
                    objects.Add(new FindObject(dist, angle, findMarker));
                }


                //float angle = Lab6Operations.FindAngleOfTurn()
                try // непонятная тупая странная ошибка
                {                //dist
                    source.PutText(dist.ToString(), candidates[i][0], HersheyFonts.HersheyPlain, 1, new Scalar(0, 0, 0), 1);
                    source.PutText(code.ToString(), candidates[i][3], HersheyFonts.HersheyPlain, 1, new Scalar(0, 0, 0), 1);
                }
                catch { }

                //int code = Lab6Operations.FindCodeOnPerspectiveMarker(candidateToMarkerPerspective);

                Lab6Operations.DrawContourOnMat(source, candidates[i], new Scalar(255, 255, 0)); //test

                Cv2.ImShow("2", candidateToMarkerPerspective); //test
            }

            if(objects.Count == 1)
            {
                cameraPosition = Lab6Operations.FindPositionByOneMarker(objects[0]);
            }
            else if (objects.Count > 1)
            {
                cameraPosition = Lab6Operations.FindPositionByFewMarkers(objects);
            }
            // осталось линию направления взгляда робота и поворачиваемые маркеры и центр маркера вместо левого верхнего угла.
            viewAngle = Lab6Operations.DrawPlayerAndMarkers(markers, cameraPosition, map, objects, cameraParameters);
            if(viewAngle!= -999999)
            {
                prevViewAngle = viewAngle;
            }

            fieldBox.Image = map;


            //code end

            Cv2.ImShow("1", source);
        }

        private void ReadMatFromSource(out Mat source)
        {
            Mat tempMat = new Mat();
            //mat = new Mat();

            if (capture != null)
            {
                //mat?.Dispose();
                capture.Read(tempMat);
                source = tempMat;
                //tempMat?.Dispose();
                return;
            }
            source = imageSource.Clone();
            return;
        }

        private void cameraParamsBut_Click(object sender, EventArgs e)
        {
            cameraParameters = new CameraParams(int.Parse(cameraForwardNum.Value.ToString()), int.Parse(cameraRightNum.Value.ToString()), int.Parse(cameraPixelsNum.Value.ToString()));
        }

        private void addMarkerNum_Click(object sender, EventArgs e)
        {
            markers.Add(new MarkerParams((int)markerXNum.Value,(int)markerYNum.Value,(int)markerCodeNum.Value,(int)markerOrientationNum.Value));
        }

        private void deleteMarkerBut_Click(object sender, EventArgs e)
        {
            if(markers.Count() > 0)
            {
                markers.RemoveAt(markers.Count() - 1);
            }
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            if (mainTimer.Enabled)
            {
                fsArr = fsArr + "X = "+cameraPosition.X.ToString()+" Y = " + cameraPosition.Y.ToString()+" angle = " + (prevViewAngle*(180/Math.PI)).ToString()+Environment.NewLine;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("D:\\техзрение4сем\\6_Lab_4_Sem\\history.csv", fsArr);
        }
    }
}

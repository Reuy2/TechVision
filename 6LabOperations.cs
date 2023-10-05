using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Lab_4_Sem
{
    public static class Lab6Operations
    {
        public static OpenCvSharp.Point[][] FindCandidatesToMarkers(Mat source)
        {
            OpenCvSharp.Point[][] contours;

            List<OpenCvSharp.Point[]> finalContours = new List<OpenCvSharp.Point[]>();

            OpenCvSharp.HierarchyIndex[] hierarchy = null;

            Mat temp = source.Clone();
            temp = temp.GaussianBlur(new OpenCvSharp.Size(3, 3), 7, 7);
            temp = temp.Canny(58, 26, 3, true);

            //OutputArray hierarchy = null;
            temp.FindContours(out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            for(int i = 0; i < contours.Length; i++)
            {
                if(Cv2.ContourArea(contours[i]) < Cv2.ArcLength(contours[i], true))
                {
                    continue;
                }

                

                contours[i] = Cv2.ApproxPolyDP(contours[i], 5, true);

                if (contours[i].Length == 4)
                {
                    OpenCvSharp.Point minPoint = FindMinInContour(contours[i]);
                    if (minPoint.X != contours[i][0].X && minPoint.Y != contours[i][0].Y)
                    {
                        OpenCvSharp.Point tempPoint = contours[i][0];
                        contours[i][0] = contours[i][1];
                        contours[i][1] = contours[i][2];
                        contours[i][2] = contours[i][3];
                        contours[i][3] = tempPoint;

                    }

                    finalContours.Add(contours[i]);
                }
            }
            temp?.Dispose();

            return finalContours.ToArray();
            //Cv2.ApproxPolyDP(contours)

        }

        public static Rect[] ReorgonizeArrOfRectsToSpiral(Rect[] rectsOnMarker)
        {
            Rect[] temp = (Rect[])rectsOnMarker.Clone();
            int[] trueArrOfCoords = {24,17,18,25,32,31,30,23,16,9,10,11,12,19,26,33,40,39,38,37,36,29,22,15,8,1,2,3,4,5,6,13,20,27,34,41,48,47,46,45,44,43,42,35,28,21,14,7,0 };

            for (int i = 0; i < 49; i++)
            {
                rectsOnMarker[i] = temp[trueArrOfCoords[i]];
            }

            return rectsOnMarker;
        }

        public static OpenCvSharp.Point FindMinInContour(OpenCvSharp.Point[] contour)
        {
            OpenCvSharp.Point minPoint = contour[0];

            for (int point = 0; point < contour.Length; point++)
            {
                if (contour[point].X+ contour[point].Y < minPoint.X+minPoint.Y) minPoint = contour[point];

                //if (contour[point].Y < minY) minY = contour[point].Y;
            }

            return minPoint;
        }

        public static float FindAngleOfTurn(OpenCvSharp.Point[] points)
        {
            float leftSide = points[1].Y - points[0].Y;

            float rightSide = points[2].Y - points[3].Y;


            return ConvertFrom07To13(leftSide / rightSide);
        }

        private static float ConvertFrom07To13(float num)
        {
            return (((num - 0.7f) * (90f - -90f)) / (1.3f - 0.7f)) + -90f;
        }

        public static float FindDistToMarker(OpenCvSharp.Point[] points, float mmInPixelsIn1Meter,float widthMarker)
        {

            float widthInPixels = ((points[1].Y - points[0].Y) + (points[2].Y - points[3].Y)) / 2;

            float mmInPixelsMarker = widthMarker / widthInPixels;

            return mmInPixelsMarker / mmInPixelsIn1Meter;
        }

        internal static bool MarkerArrContains(List<MarkerParams> markers, int code, out MarkerParams outMarker)
        {
            foreach (MarkerParams marker in markers)
            {
                if (marker.Code == code) 
                {
                    outMarker = marker;
                    return true;
                }
            }
            outMarker = null;
            return false;
        }

        public static Mat GetPerspectiveByContour(Mat mat, OpenCvSharp.Point[] contour,OpenCvSharp.Size size)
        {
            Mat final = new Mat(size, mat.Type());

            float[,] A4 =
                new float[,]
                {
                    { contour[0].X, contour[0].Y },
                    { contour[3].X, contour[3].Y  },
                    { contour[1].X, contour[1].Y  },
                    { contour[2].X, contour[2].Y  }
                };

            float[,] A = new float[,]
            {
                { 0, 0 },
                { size.Width, 0 },
                { 0, size.Height },
                { size.Width, size.Height }
            };

            Mat A4_matrix = new Mat(4, 2, MatType.CV_32F, A4);
            Mat A_matrix = new Mat(4, 2, MatType.CV_32F, A);
            Mat m = Cv2.GetPerspectiveTransform(A4_matrix, A_matrix);
            Cv2.WarpPerspective(mat, final, m, final.Size());
            return final;
        }

        internal static System.Drawing.Point FindPositionByFewMarkers(List<FindObject> objects)
        {
            int count = 0;

            int x = 0;
            int y = 0;

            for (int i = 0; i < objects.Count(); i++)
            {
                for (int j = i+1; j < objects.Count(); j++)
                {
                    count++;
                    System.Drawing.Point firstPoint = FindPositionByOneMarker(objects[i]);
                    System.Drawing.Point secondPoint = FindPositionByOneMarker(objects[j]);

                    if(x == 0|| y == 0)
                    {
                        x = (firstPoint.X + secondPoint.X) / 2;
                        y = (firstPoint.Y + secondPoint.Y) / 2;
                    }
                    else
                    {
                        x = (firstPoint.X + secondPoint.X+x) / 3;
                        y = (firstPoint.Y + secondPoint.Y+y) / 3;
                    }
                }
            }

            return new System.Drawing.Point(x, y);
        }

        internal static float DrawPlayerAndMarkers(List<MarkerParams> markers, System.Drawing.Point cameraPosition, System.Drawing.Bitmap map,List<FindObject> objects, CameraParams cameraParameters)
        {

            int meanXOfMarkers = 0;

            int meanYOfMarkers = 0;
            Graphics g = Graphics.FromImage(map);
            try
            {
                g.DrawEllipse(Pens.Black, cameraPosition.X-2.5f, cameraPosition.Y-2.5f, 5, 5);
                //g.DrawLine(Pens.Red, cameraPosition);
            }
            catch { }

            foreach (var marker in markers)
            {
                Lab6Operations.DrawRotatedRectangle(g, marker);
            }

            if (objects.Count > 0)
            {
                foreach (var visibleMarker in objects)
                {
                    meanXOfMarkers += visibleMarker.marker.X;
                    meanYOfMarkers += visibleMarker.marker.Y;
                    try
                    {
                        g.DrawLine(Pens.Red, cameraPosition.X, cameraPosition.Y, visibleMarker.marker.X, visibleMarker.marker.Y);
                    }
                    catch { }
                    //g.DrawLine(Pens.Red, cameraPosition.X, cameraPosition.Y, visibleMarker.marker.X, visibleMarker.marker.Y);
                }
                meanXOfMarkers = meanXOfMarkers / objects.Count;
                meanYOfMarkers = meanYOfMarkers / objects.Count;

                float angle = FIndAngleOfView(meanXOfMarkers, meanYOfMarkers, cameraPosition);

                DrawFieldOfView(angle, cameraPosition, cameraParameters, g);

                return angle;
            }

            return -999999;
        }

        private static void DrawFieldOfView(float angle, System.Drawing.Point cameraPosition, CameraParams cameraParameters, Graphics g)
        {
            int FOV = 70;
            float x1 = cameraPosition.X + 10;
            float y1 = cameraPosition.Y;

            float x2 = cameraPosition.X + 10;
            float y2 = cameraPosition.Y;

            RotateDot(cameraPosition.X, cameraPosition.Y, angle - FOV / 2, ref x1, ref y1);
            RotateDot(cameraPosition.X, cameraPosition.Y, angle + FOV / 2, ref x2, ref y2);
            try
            {
                g.DrawLine(Pens.Brown, cameraPosition.X, cameraPosition.Y, x1, y1);
                g.DrawLine(Pens.Brown, cameraPosition.X, cameraPosition.Y, x2, y2);
            }
            catch { }
        }

        private static float FIndAngleOfView(int meanXOfMarkers, int meanYOfMarkers, System.Drawing.Point cameraPosition)
        {
            //float tgA = (float)(meanYOfMarkers - cameraPosition.Y) / (float)(meanXOfMarkers-cameraPosition.X);

            return (float)(Math.Atan2((float)(meanYOfMarkers - cameraPosition.Y), (float)(meanXOfMarkers - cameraPosition.X))-Math.PI);
        }

        private static void DrawRotatedRectangle(Graphics g, MarkerParams marker)
        {
            int width = 20;
            int height = 5;
            float angle = (float)((Math.PI / 180) * marker.Orientation +90* (Math.PI / 180));

            float x1 = marker.X - width / 2;
            float y1 = marker.Y - height / 2;

            float x2 = x1 + width;// + width / 2;
            float y2 = y1;

            float x3 = x1 + width ;
            float y3 = y1 + height ;

            float x4 = x1;
            float y4 = y1 + height;

            RotateDot(marker, angle, ref x1, ref y1);
            RotateDot(marker, angle, ref x2, ref y2);
            RotateDot(marker, angle, ref x3, ref y3);
            RotateDot(marker, angle, ref x4, ref y4);

            g.DrawLine(Pens.Red, x1, y1, x2, y2);
            g.DrawLine(Pens.Black, x2, y2, x3, y3);
            g.DrawLine(Pens.Black, x3, y3, x4, y4);
            g.DrawLine(Pens.Black, x4, y4, x1, y1);
        }

        private static void RotateDot(MarkerParams marker, float angle, ref float x1, ref float y1)
        {
            float prevx1 = x1;
            float prevy1 = y1;
            // X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

            x1 = (float)((prevx1 - marker.X) * Math.Cos(angle) - (prevy1 - marker.Y) * Math.Sin(angle) + marker.X);
            // Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
            y1 = (float)((prevx1 - marker.X) * Math.Sin(angle) + (prevy1 - marker.Y) * Math.Cos(angle) + marker.Y);
        }

        private static void RotateDot( float x0,  float y0, float angle, ref float x1, ref float y1)
        {
            float prevx1 = x1;
            float prevy1 = y1;
            // X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

            x1 = (float)((prevx1 - x0) * Math.Cos(angle) - (prevy1 - y0) * Math.Sin(angle) + x0);
            // Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
            y1 = (float)((prevx1 - x0) * Math.Sin(angle) + (prevy1 - y0) * Math.Cos(angle) + y0);
        }

        internal static System.Drawing.Point FindPositionByOneMarker(FindObject findObject)
        {
            System.Drawing.Point point = new System.Drawing.Point(-1,-1);

            int x = (int)(findObject.marker.X + (findObject.distance*100) * Math.Cos((findObject.angle + findObject.marker.Orientation)*(Math.PI/180)));
            int y = (int)(findObject.marker.Y + (findObject.distance*100) * Math.Sin((findObject.angle + findObject.marker.Orientation) * (Math.PI / 180)));

            point.X = x;
            point.Y = y;

            return point;
        }

        public static void DrawContourOnMat(Mat mat, OpenCvSharp.Point[] contour, Scalar scalar)
        {
            for (int i = 0; i + 1 < contour.Length; i++)
            {
                mat.Line(contour[i].X, contour[i].Y, contour[i + 1].X, contour[i + 1].Y, scalar);
            }

            //perspectiveMat.Circle(center, 5, new Scalar(0, 0, 0));

            mat.Line(contour[contour.Length - 1].X, contour[contour.Length - 1].Y, contour[0].X, contour[0].Y, scalar);
        }

        public static int FindCodeOnPerspectiveMarker(Mat marker,Rect[] rectsInMarker)
        {
            int code = 0;

            for (int i = 0; i < 49; i++)
            {
                marker.Rectangle(rectsInMarker[i],Scalar.Red);

                if (CheckRectToFullness(rectsInMarker[i],marker) > 0.4)
                {
                    code += i;
                }
            }

            return code;
        }

        public static float CheckRectToFullness(Rect rect, Mat marker)
        {
            Mat temp = marker[rect];

            return (float)temp.CountNonZero() / (float)(rect.Height * rect.Width);
        }

        public static Rect[] MakeArrOfRects(int sizeOf1Cell)
        {

            Rect[] coordsOfCells = new Rect[49];

            int x = 34;
            int y = 34 - sizeOf1Cell;

            for (int i = 0; i < 49; i++)
            {
                if (i % 7 == 0)
                {
                    x = 34;
                    y += sizeOf1Cell;
                }

                coordsOfCells[i] = new Rect(x, y, sizeOf1Cell, sizeOf1Cell);

                x += sizeOf1Cell;
            }
            return coordsOfCells;
        }
    }
}

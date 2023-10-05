using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Lab_4_Sem
{
    class CameraParams
    {

        float mmInPixelsIn1m = 90f / 59f;

        int DeltaForwardCm { get; set; }

        int DeltaRightCm { get; set; }


        //59
        int PixelsIn1m { set { mmInPixelsIn1m = 90f / value; } }

        public float MmInPixelsIn1m
        {
            get { return mmInPixelsIn1m; }
            //set { mmInPixelsIn1m = 90f / value; }
        }

        public CameraParams(int forward,int right,int pixels)
        {
            this.DeltaForwardCm = forward;
            this.DeltaRightCm = right;
            this.PixelsIn1m = pixels;
        }

        public void ChangeParams(int forward, int right, int pixels)
        {
            this.DeltaForwardCm = forward;
            this.DeltaRightCm = right;
            this.PixelsIn1m = pixels;
        }

    }
}

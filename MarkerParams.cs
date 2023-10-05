using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Lab_4_Sem
{
    class MarkerParams
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Code { get; set; }

        public int Orientation { get; set; }

        public MarkerParams(int x, int y, int code, int orientation)
        {
            this.X = x;
            this.Y = y;
            this.Code = code;
            this.Orientation = orientation;
        }

        public static bool operator== (MarkerParams marker, int code)
        {
            if (marker.Code == code) return true;

            return false;
        }

        public static bool operator !=(MarkerParams marker, int code)
        {
            if (marker.Code != code) return true;

            return false;
        }
    }
}

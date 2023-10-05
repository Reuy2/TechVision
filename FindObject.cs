using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Lab_4_Sem
{
    struct FindObject
    {

        public float distance;

        public float angle;

        public MarkerParams marker;

        public FindObject(float dist,float angle, MarkerParams marker)
        {
            distance = dist;
            this.angle = angle;
            this.marker = marker;
        }

    }
}

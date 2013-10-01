using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04.StructurePoint3D
{
    struct Point3D
    {
        public Point3D(int x,int y,int z):this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        public static Point3D Point0 
        {
            get
            {
                return zeroPoint;
            }
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}",X,Y,Z);
        }
    }
}

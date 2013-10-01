using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04.StructurePoint3D
{
    class Path
    {
        private readonly List<Point3D> allPoints = new List<Point3D>();
        public List<Point3D> AllPoints
        {
            get { return allPoints; }
        }

        public void AddPoint(Point3D point)
        {
            allPoints.Add(point);
        }
    }
}

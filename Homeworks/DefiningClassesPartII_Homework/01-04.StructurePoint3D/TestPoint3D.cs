using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01_04.StructurePoint3D
{
    class TestPoint3D
    {
        static void Main()
        {
            Path myPath = new Path();
            myPath.AddPoint(new Point3D(1, 2, 3));
            myPath.AddPoint(new Point3D(4, 5, 6));
            myPath.AddPoint(new Point3D(7, 8, 9));
            PathStorage.SavePaths(myPath.AllPoints);
            Console.WriteLine("The coordinates of points in this path are:");
            List<Point3D> currentPath=PathStorage.LoadPaths();
            foreach (var item in currentPath)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("The distance between first and second point is {0}",CalculateDistance.Calculate3DDistance(myPath.AllPoints[0],myPath.AllPoints[1]));
            Console.WriteLine("Press 'y' if you want to clear the path storage, any other key to keep current path");
            string choice = Console.ReadLine();
            if (choice=="y"||choice=="Y")
            {
                File.Delete("../../storage.txt");
            }
        }
    }
}

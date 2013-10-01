using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04.StructurePoint3D
{
    static class PathStorage
    {
        public static void SavePaths(List<Point3D> path)
        {
            StreamWriter file = new StreamWriter("../../storage.txt", true); //assume we will append points
            using (file)
            {
                foreach (var point in path)
                {
                    file.WriteLine(point);
                }
            }
        }

        public static List<Point3D> LoadPaths()
        {
            List<Point3D> path = new List<Point3D>();
            StreamReader file = new StreamReader("../../storage.txt");
            using (file)
            {
                string currentLine = file.ReadLine();
                while (currentLine!=null)
                {
                    string[] currentCoord = currentLine.Split(',');
                    int[] coordinates = new int[currentCoord.Length];
                    for (int i = 0; i < coordinates.Length; i++)
                    {
                        coordinates[i] = int.Parse(currentCoord[i]);
                    }
                    Point3D currentPoint = new Point3D(coordinates[0], coordinates[1], coordinates[2]);
                    path.Add(currentPoint);
                    currentLine = file.ReadLine();
                }
            }
            return path;
        }
    }
}

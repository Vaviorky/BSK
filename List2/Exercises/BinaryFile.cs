using System;
using System.IO;
using System.Reflection;

namespace List2.Exercises
{
    public static class BinaryFile
    {
        public static byte[] Read(string fileName)
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, @"TestFiles\", fileName);
                var file = File.ReadAllBytes(path);
                return file;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return null;
            }
        }
    }
}
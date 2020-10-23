using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task1.Exporter.Interfaces;

namespace Task1.Exporter
{
    public class FileExporter : IFileExporter
    {
        public void Export(List<Tuple<string, double>> data, string path)
        {
            using(var stream = new FileStream(path, FileMode.Create))
            {
                using(var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    foreach(var line in data)
                    {
                        var transformedLine = GetTransformedData(line);
                        writer.WriteLine(transformedLine);
                    }
                }
            }
        }

        private string GetTransformedData(Tuple<string, double> data)
        {
            return $"{data.Item1};{data.Item2}";
        }
    }
}

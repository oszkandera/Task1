using System;
using System.Collections.Generic;

namespace Task1.Exporter.Interfaces
{
    public interface IFileExporter
    {
        void Export(List<Tuple<string, double>> data, string path);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace GeneradorDeCodigo
{
    public class GenerateFileBuilder  
    {
        IWriter _writer;
        public GenerateFileBuilder(IWriter writer)
        {
            this._writer = writer;
        }
       
        public void CreateField(string route, string Titulo)
        {
            string CodigoMap = Codigo.CassBuilder(Titulo);
            _writer.Writer(route, Titulo, "Builder", CodigoMap);
        }
        public void CreateFieldAll(string route)
        {
            ShowAll showAll = new ShowAll();
            foreach(var i in showAll.NameTable())
            {
                string CodigoMap = Codigo.CassBuilder(i);
                _writer.Writer(route, i, "Map", CodigoMap);
            }

        }
        

    }
}

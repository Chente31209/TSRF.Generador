using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace GeneradorDeCodigo
{
    public class GenerateFileBuilder  
    {
        readonly IWriter _writer;
        readonly IdbConnection _Idb;
        public GenerateFileBuilder(IWriter writer, IdbConnection Idb)
        {
            this._writer = writer;
            this._Idb = Idb;
        }
        

        public void CreateField(string route, string Titulo)
        {
            Codigo codigo = new Codigo(_Idb);
            string CodigoMap = codigo.CassBuilder(Titulo);
            _writer.Writer(route, Titulo, "Builder", CodigoMap);
        }
        public void CreateFieldAll(string route)
        {
            ShowAll showAll = new ShowAll(_Idb);
            foreach(var i in showAll.NameTable())
            {
                Codigo codigo = new Codigo(_Idb);
                string CodigoMap = codigo.CassBuilder(i);
                _writer.Writer(route, i, "Builder", CodigoMap);
            }

        }
        

    }
}

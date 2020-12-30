using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace GeneradorDeCodigo
{
    public class GenerateFileEnty
    {
        IWriter _writer;
        IdbConnection _Idb;
        public GenerateFileEnty(IWriter writer, IdbConnection Idb)
        {
            this._writer = writer;
            this._Idb = Idb;
        }
        
        public void CreateField(string route, string Titulo)
        {
            Codigo codigo = new Codigo(_Idb);
            string CodigoGenerado = codigo.ClassPropertis(Titulo,"Entity");
            _writer.Writer(route, Titulo,"Entity", CodigoGenerado);
        }
        public void CreateFieldAll(string route)
        {
            Codigo codigo = new Codigo(_Idb);
            ShowAll showAll = new ShowAll(_Idb);
            foreach (var i in showAll.NameTable())
            {
                string CodigoGenerado = codigo.ClassPropertis(i,"Entity");
                _writer.Writer(route, i, "Entity", CodigoGenerado);
            }
        }
       
    }
}

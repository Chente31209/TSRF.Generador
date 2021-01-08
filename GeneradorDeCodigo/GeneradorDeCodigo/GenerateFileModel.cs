using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenerateFileModel
    {
        IWriter _writer;
        readonly IdbConnection _Idb;
        public GenerateFileModel(IWriter writer, IdbConnection Idb)
        {
            this._writer = writer;
            this._Idb = Idb;

        }
        
        public void CreateField(string route, string Titulo)
        {
            Codigo codigo = new Codigo(_Idb);
            string CodigoGenerado = codigo.ClassPropertis(Titulo, "");
            _writer.Writer(route, Titulo, "", CodigoGenerado);
        }
        public void CreateFieldAll(string route)
        {
            Codigo codigo = new Codigo(_Idb);
            ShowAll showAll = new ShowAll(_Idb);
            foreach (var i in showAll.NameTable())
            {
                if (i.Contains("RDB$"))
                    Console.WriteLine("Salto de Tabla");
                else
                {
                    string CodigoGenerado = codigo.ClassPropertis(i, "");
                    _writer.Writer(route, i, "", CodigoGenerado);
                }
                
            }
        }

    }
}

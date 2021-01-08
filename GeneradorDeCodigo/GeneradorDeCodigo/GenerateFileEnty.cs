using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace GeneradorDeCodigo
{
    public class GenerateFileEnty
    {
        readonly IWriter _writer;
        readonly IdbConnection _Idb;
      
        public GenerateFileEnty(IWriter writer, IdbConnection Idb  )
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
                if (i.Contains("RDB$"))
                    Console.WriteLine("Salto de Tabla");
                else
                {
                string CodigoGenerado = codigo.ClassPropertis(i,"Entity");
                _writer.Writer(route, i, "Entity", CodigoGenerado);
                }
                
            }
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenerateFileDto
    {
        IWriter _writer;
        IdbConnection _Idb;
        public GenerateFileDto(IWriter writer, IdbConnection Idb)
        {
            this._writer = writer;
            this._Idb = Idb;
        }
        
        public void CreateField(string route, string Titulo)
        {
            Codigo codigo = new Codigo(_Idb);
            string CodigoGenerado = codigo.ClassPropertis(Titulo,"Dto");
            _writer.Writer(route, Titulo, "Dto", CodigoGenerado);
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
                    string CodigoGenerado = codigo.ClassPropertis(i, "Dto");
                    _writer.Writer(route, i, "Dto", CodigoGenerado);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenerateFileDto
    {
        IWriter _writer;
        public GenerateFileDto(IWriter writer)
        {
            this._writer = writer;
        }
        public void CreateField(string route, string Titulo)
        {
            string CodigoGenerado = Codigo.ClassPropertis(Titulo,"Dto");
            _writer.Writer(route, Titulo, "Dto", CodigoGenerado);
        }
        public void CreateFieldAll(string route)
        {

            ShowAll showAll = new ShowAll();
            foreach (var i in showAll.NameTable())
            {
                string CodigoGenerado = Codigo.ClassPropertis(i, "Dto");
                _writer.Writer(route, i, "Dto", CodigoGenerado);
            }
        }
    }
}

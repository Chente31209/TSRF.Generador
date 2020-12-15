using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenerateFileModel
    {
        IWriter _writer;
        public GenerateFileModel(IWriter writer)
        {
            this._writer = writer;

        }

        public void CreateField(string route, string Titulo)
        {
            string CodigoGenerado = Codigo.ClassPropertis(Titulo, "");
            _writer.Writer(route, Titulo, "", CodigoGenerado);
        }
        public void CreateFieldAll(string route)
        {

            ShowAll showAll = new ShowAll();
            foreach (var i in showAll.NameTable())
            {
                string CodigoGenerado = Codigo.ClassPropertis(i, "");
                _writer.Writer(route, i, "", CodigoGenerado);
            }
        }

    }
}

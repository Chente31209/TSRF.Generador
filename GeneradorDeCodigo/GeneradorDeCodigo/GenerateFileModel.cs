using System;

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
        /// <summary>
        /// este metodo es para crear un archivo en espesifico
        /// </summary>
        public void CreateField(string route, string Titulo)
        {
            if (Titulo.Contains("$"))
                Console.WriteLine("Salto de Tabla");
            else
            {
            Codigo codigo = new Codigo(_Idb);
            string CodigoGenerado = codigo.ClassPropertis(Titulo, "");
            _writer.Writer(route, Titulo, "", CodigoGenerado);

            Mensaje.MensajeDeCreacion("Model", Titulo);
            }
        }
        /// <summary>
        ///  este metodo es para crear todos los archivos 
        /// </summary>
        public void CreateFieldAll(string route)
        {
            Codigo codigo = new Codigo(_Idb);
            ShowAll showAll = new ShowAll(_Idb);
            foreach (var i in showAll.NameTable())
            {
                if (i.Contains("$"))
                    Console.WriteLine("Salto de Tabla");
                else
                {
                    string CodigoGenerado = codigo.ClassPropertis(i, "");
                    _writer.Writer(route, i, "", CodigoGenerado);
                    Mensaje.MensajeDeCreacion("Model",i);
                   
                }
                
            }
        }

    }
}

using System;

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
                string CodigoMap = codigo.CassBuilder(Titulo);
                _writer.Writer(route, Titulo, "Builder", CodigoMap);

                Mensaje.MensajeDeCreacion("Builder", Titulo);
            }
        }
        /// <summary>
        ///  este metodo es para crear todos los archivos 
        /// </summary>
        public void CreateFieldAll(string route)
        {
            ShowAll showAll = new ShowAll(_Idb);
            foreach (var i in showAll.NameTable())
            {
                if (i.Contains("$"))
                    Console.WriteLine("Salto de Tabla");
                else
                {
                    Codigo codigo = new Codigo(_Idb);
                    string CodigoMap = codigo.CassBuilder(i);
                    _writer.Writer(route, i, "Builder", CodigoMap);

                    Mensaje.MensajeDeCreacion("Builder", i);
                }
            }
        }
    }
}

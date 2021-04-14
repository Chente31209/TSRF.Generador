using System;

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
                string CodigoGenerado = codigo.ClassPropertis(Titulo, "Dto");
                _writer.Writer(route, Titulo, "Dto", CodigoGenerado);

                Mensaje.MensajeDeCreacion("Dto", Titulo);
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
                    string CodigoGenerado = codigo.ClassPropertis(i, "Dto");
                    _writer.Writer(route, i, "Dto", CodigoGenerado);

                    Mensaje.MensajeDeCreacion("Dto", i);
                }
            }
        }
    }
}

using System;

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
                string CodigoGenerado = codigo.ClassPropertis(Titulo, "Entity");
                _writer.Writer(route, Titulo, "Entity", CodigoGenerado);

                Mensaje.MensajeDeCreacion("Entity", Titulo);
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
                string CodigoGenerado = codigo.ClassPropertis(i,"Entity");
                _writer.Writer(route, i, "Entity", CodigoGenerado);

                    Mensaje.MensajeDeCreacion("Entity", i);
                }
                
            }
        }
       
    }
}

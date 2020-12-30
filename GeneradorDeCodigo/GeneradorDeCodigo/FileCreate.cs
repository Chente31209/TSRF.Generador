using System;
using System.IO;
using System.Text;

namespace GeneradorDeCodigo
{
    public class FileCreate : IWriter
    {
        IdbConnection _idb;
        public FileCreate(IdbConnection idb)
        {
            this._idb = idb;
        }
        public void Writer(string route, string Titulo, string type, string Codigo)
        {
            LinqQueris linqQueris = new LinqQueris(_idb);
            var minusculas = linqQueris.Tables(Titulo)[0].Titule;
            var Nombre = FormatWord.ParseMinusulas(minusculas);
            var path = $"{route}\\{Nombre}{type}.cs";
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(Codigo);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

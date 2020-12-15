using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace GeneradorDeCodigo
{
    public class FileCreate : IWriter
    {
        
        public void Writer(string route, string Titulo, string type, string Codigo)
        {
          

            var minusculas = LinqQueris.Tables(Titulo)[0].Titule.ToLower();
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
            var path = $"{route}\\{Nombre}{type}.cs";

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(Codigo);
                    // Add some information to the file.
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

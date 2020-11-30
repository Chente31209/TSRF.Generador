using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace GeneradorDeCodigo
{
    public class GenerateFileEnty
    {
        GenerateEntity generateEntity = new GenerateEntity();
        GenetateTables genetateTables = new GenetateTables();

        public void CreateField(string route, string Titulo)
        {
            var Table = generateEntity.Generate(Titulo);

            var minusculas = LinqQueris.Tables(Titulo)[0].Titule.ToLower();
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
            var path = $"{route}\\{Nombre}Entity.cs";

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(Codigo.classEnty(Titulo));
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

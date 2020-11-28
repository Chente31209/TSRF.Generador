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
           
            
        }
    }
}

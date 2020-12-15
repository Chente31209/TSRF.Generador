using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GeneratePropertis
    {
       
        List<Propertis> entities = new List<Propertis> { };
        public List<Propertis> Generate(string Titule)
        {
            foreach (var i in LinqQueris.Tables(Titule))
            {
                var minusculas = i.Columns.ToLower();
                var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
                entities.Add(new Propertis { TableEntity = $"public {i.Type} {Nombre} {{ get; set; }}" });
            }
            return entities;
        }
        
    }
}

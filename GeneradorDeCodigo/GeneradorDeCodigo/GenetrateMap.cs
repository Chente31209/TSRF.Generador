using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenetrateMap
    {
        List<DBMap> dBMaps = new List<DBMap> { };
        public List<DBMap> Generate(string Titule)
        {
            DBMap dBMap = new DBMap();
            var tables = LinqQueris.Tables(Titule);
            foreach (var i in tables)
            {
                
                var minusculas = i.Columns.ToLower();
                var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
                dBMaps.Add(new DBMap { Map = $"Clientes.Property(x => x.{Nombre}).HasColumnName(\"{i.Columns}\");" });
            }
            return dBMaps;
        }
        
    }
}

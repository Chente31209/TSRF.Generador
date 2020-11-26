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
            GenetateTables tables = new GenetateTables();
            var getTable = from table in tables.Generate()
                           where table.Titule.StartsWith(Titule)
                           select (table);

            foreach (var i in getTable)
            {
                var minusculas = i.Columns.ToLower();
                var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
                dBMaps.Add(new DBMap { Map = $"Clientes.Property(x => x.{Nombre}).HasColumnName(\"{i.Columns}\");" });
            }
            return dBMaps;
        }
        public void show(string titulo)
        {
            Console.WriteLine($"***********************************{titulo}_map************************************");
            foreach (var i in Generate(titulo))
            {
                Console.WriteLine(i.Map);
            }
        }
    }
}

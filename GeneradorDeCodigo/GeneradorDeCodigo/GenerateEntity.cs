using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenerateEntity
    {
       
        List<Entity> entities = new List<Entity> { };
        public List<Entity> Generate(string Titule)
        {
            GenetateTables tables = new GenetateTables();

            //var getTable = tables.Generate().GroupBy(x => x.Titule == Titule).FirstOrDefault();
            var getTable = from table in tables.Generate()
                           where table.Titule.StartsWith(Titule)
                           select (table);

            foreach (var i in getTable)
            {
                var minusculas = i.Columns.ToLower();
                var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
                entities.Add(new Entity { TableEntity = $"public int {Nombre} {{ get; set; }}" });
            }
            return entities;
        }
        public void show(string titulo)
        {
            Console.WriteLine($"***********************************{titulo}************************************");
            foreach(var i in Generate(titulo))
            {
                Console.WriteLine(i.TableEntity);
            }
        }
    }
}

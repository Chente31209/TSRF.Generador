using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GeneratePropertis
    {
        IdbConnection _idb;
        public GeneratePropertis(IdbConnection idb)
        {
            this._idb = idb;
        }
        List<Propertis> entities = new List<Propertis> { };
        public List<Propertis> Generate(string Titule)
        {
            LinqQueris linqQueris = new LinqQueris(_idb);
            foreach (var i in linqQueris.Tables(Titule))
            {
                var minusculas = i.Columns.ToLower();
                var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(minusculas);
                entities.Add(new Propertis { TableEntity = $"public {i.Type} {Nombre} {{ get; set; }}" });
            }
            return entities;
        }
        
    }
}

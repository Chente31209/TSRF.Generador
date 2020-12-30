using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenerateKes : ConnectionDB
    {
       
        public GenerateKes(IdbConnection idb) : base(idb)
        { }
        public PrimariKey parse(string Columna)
        {
            var Key =Columna.Split("|");
            return new PrimariKey { Titule=Key[0].Trim(), Key=Key[1].Trim()};
        }
        public List<PrimariKey> Gkeys()
        {
            
            List<PrimariKey> primariKeys = new List<PrimariKey> { };
            foreach (var i in PrimaryKey(Sentences.PrimaryKey()))
            {
                primariKeys.Add(parse(i));
            }
            return primariKeys;
        }

    }
}

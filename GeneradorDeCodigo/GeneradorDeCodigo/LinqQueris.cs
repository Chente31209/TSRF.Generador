using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneradorDeCodigo
{
   public  class LinqQueris
    {
        public static  List<Tables> Tables(string tableTitule)
        {
            GenetateTables tables = new GenetateTables();
            var getTable = from table in tables.Generate()
                           where table.Titule.StartsWith(tableTitule)
                           select (table);
            
            return getTable.ToList();
        }
        public static PrimariKey Keys(string tableTituleKey)
        {
            GenerateKes generateKes = new GenerateKes();

            var getTable = from table in generateKes.Gkeys()
                           where table.Titule.StartsWith(tableTituleKey)
                           select (table);

            return getTable.FirstOrDefault();
        }

    }
}

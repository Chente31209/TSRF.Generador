using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneradorDeCodigo
{
   public   class LinqQueris
    {
        IdbConnection _idb;
        public LinqQueris(IdbConnection idb)
        {
            this._idb = idb;
        }

        public   List<Tables> Tables(string tableTitule)
        {
           // IdbConnection Idb = new ConnectionDB();
            GenetateTables tables = new GenetateTables(_idb);
            var getTable = from table in tables.Generate()
                           where table.Titule.StartsWith(tableTitule)
                           select (table);
            
            return getTable.ToList();
        }
        public  PrimariKey Keys(string tableTituleKey)
        {
            //IdbConnection Idb = new ConnectionDB();
            GenerateKes generateKes = new GenerateKes(_idb);

            var getTable = from table in generateKes.Gkeys()
                           where table.Titule.StartsWith(tableTituleKey)
                           select (table);

            return getTable.FirstOrDefault();
        }

    }
}

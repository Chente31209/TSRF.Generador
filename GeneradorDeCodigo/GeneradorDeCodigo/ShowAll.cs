using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class ShowAll
    {
        IdbConnection _idb;
        public ShowAll(IdbConnection idb)
        {
            this._idb = idb;
        }

        
       // GenerateFileEnty generateFileEnty = new GenerateFileEnty();

      
        public List<string> NameTable()
        {
            GenetateTables genetateTables = new GenetateTables(_idb);
            var lista = genetateTables.Generate().GroupBy(x => x.Titule).Select(x => x.FirstOrDefault());
            List<string> Nombres = new List<string> { };
            foreach (var i in lista)
            {
                Nombres.Add(i.Titule);
            }
            return Nombres;

        }




    }
}

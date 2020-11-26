using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenetateTables
    {
        ConnectionDB connection = new ConnectionDB();
        public Tables Parse(string Campo)
        {
            var tabla = Campo.Split("|");
            return new Tables { Titule = tabla[0].Trim(), Columns = tabla[1].Trim() };
        }
        public List<Tables> Generate()
        {
            var list = connection.ColumnDB(Sentences.ColumnAll());
            List<Tables> ListTables = new List<Tables> { };
            foreach (var i in list)
            {
                ListTables.Add(Parse(i));
            }
            return ListTables;
        }

        public void show()
        {
            var lista = Generate().GroupBy(x=>x.Titule).Select(x=>x.FirstOrDefault());
            

            foreach (var i in lista)
            {
                Console.WriteLine(i.Titule);
            }
        }
    }
}

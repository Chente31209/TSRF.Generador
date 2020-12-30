using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenetateTables: ConnectionDB 
    {
       
        public GenetateTables(IdbConnection idb) : base(idb)
        {
        }

        public Tables Parse(string Campo)
        {
            var tabla = Campo.Split("|");
            
           if (tabla[2].Trim() == "CHAR(1)")
            {
                return new Tables
                {
                    Titule = tabla[0].Trim(),
                    Columns = tabla[1].Trim(),
                    Type = (tabla[3] == "NOT NULL" ? "char" : "char?"),
                    IsNull = (tabla[3] == "NULL")
                };
                
            }
            if (tabla[2].Trim() == "INTEGER" || tabla[2].Trim().Contains("NUMERIC"))
            {
                return new Tables
                {
                    Titule = tabla[0].Trim(),
                    Columns = tabla[1].Trim(),
                    Type = (tabla[3] == "NOT NULL" ? "int" : "int?"),
                    IsNull = (tabla[3] == "NULL")
                };
            }  

            if (tabla[2].Trim() == "TIMESTAMP" || tabla[2].Trim() == "DATE")
            {
                return new Tables
                {
                    Titule = tabla[0].Trim(),
                    Columns = tabla[1].Trim(),
                    Type = (tabla[3] == "NOT NULL" ? "DateTime" : "DateTime?"),
                    IsNull = (tabla[3] == "NULL")
                };
                
            }
            else
            {
                return new Tables
                {
                    Titule = tabla[0].Trim(),
                    Columns = tabla[1].Trim(),
                    Type = (tabla[3] == "NOT NULL" ? "string" : "string"),
                    IsNull = (tabla[3] == "NULL")
                };
            }
                 

        }
        public List<Tables> Generate()
        {
            var list = Tabla(Sentences.ColumnAll());
           
            List<Tables> ListTables = new List<Tables> { };
            foreach (var i in list)
            {
                ListTables.Add(Parse(i));
            }
            return ListTables;
        }

        
    }
}

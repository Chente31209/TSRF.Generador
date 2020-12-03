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
            if (tabla[2] == "CHAR(1)")
            {
                if(tabla[3]== "NOT NULL")
                    return new Tables { Titule = tabla[0].Trim(),
                                        Columns = tabla[1].Trim(),
                                        Type="char" ,
                                        IsNull=false };
                else
                    return new Tables { Titule = tabla[0].Trim(),
                                        Columns = tabla[1].Trim(), 
                                        Type = "char?", 
                                        IsNull=true };
            }
            if (tabla[2].Trim() == "INTEGER" || tabla[2].Trim().Contains("NUMERIC"))
            {
                if (tabla[3] == "NOT NULL")
                    return new Tables { Titule = tabla[0].Trim(),  
                                        Columns = tabla[1].Trim(),
                                        Type = "int",
                                        IsNull = false };
                else
                    return new Tables { Titule = tabla[0].Trim(),
                                        Columns = tabla[1].Trim(),
                                        Type = "int?",
                                        IsNull= true };
            }  

            if (tabla[2].Trim() == "TIMESTAMP" || tabla[2].Trim() == "DATE")
            {
                if(tabla[3] == "NOT NULL")
                    return new Tables { Titule = tabla[0].Trim(),
                                        Columns = tabla[1].Trim(),
                                        Type = "DateTime", 
                                        IsNull = false };
                else
                    return new Tables { Titule = tabla[0].Trim(),   
                                        Columns = tabla[1].Trim(),
                                        Type = "DateTime?",
                                        IsNull = true };
            }
            else
            {
                if (tabla[3] == "NOT NULL")
                    return new Tables { Titule = tabla[0].Trim(),
                                        Columns = tabla[1].Trim(), 
                                        Type = "string",
                                        IsNull = false };
                else
                    return new Tables { Titule = tabla[0].Trim(),
                                        Columns = tabla[1].Trim(), 
                                        Type = "string?", 
                                        IsNull = true };
            }
                 

        }
        public List<Tables> Generate()
        {
            var list = connection.Tabla(Sentences.ColumnAll());
           
            List<Tables> ListTables = new List<Tables> { };
            foreach (var i in list)
            {
                ListTables.Add(Parse(i));
            }
            return ListTables;
        }

        
    }
}

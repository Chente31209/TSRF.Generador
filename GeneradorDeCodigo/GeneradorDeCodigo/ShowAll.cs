using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class ShowAll
    {
        GenerateEntity generateEntity = new GenerateEntity();
        GenetrateMap genetrateMap = new GenetrateMap();
        GenetateTables genetateTables = new GenetateTables();
        GenerateFileEnty generateFileEnty = new GenerateFileEnty();

        /// <summary>
        /// Te Muestra Una vista prebia de el map a generar espesifiando el titulo de la tabla 
        /// -m
        /// </summary>
        /// <param name="titulo"></param>
        public void showMap(string titulo)
        {
            Console.WriteLine($"***********************************{titulo}_map************************************");
            foreach (var i in genetrateMap.Generate(titulo))
            {
                Console.WriteLine(i.Map);
            }
        }
        /// <summary>
        /// Te Muestra Una vista prebia de la entidad a generar espesifiando el titulo de la tabla 
        /// </summary>
        /// <param name="titulo"></param>
        public void showEnty(string titulo)
        {
            Console.WriteLine($"***********************************{titulo}************************************");
            foreach (var i in generateEntity.Generate(titulo))
            {
                Console.WriteLine(i.TableEntity);
            }
        }
        /// <summary>
        /// Te muestra de una forma detallada las propiedades de una tabla espesifiada  
        /// </summary>
        public void showAllTable(string titulo)
        {
            foreach (var i in LinqQueris.Tables(titulo))
            {
                Console.WriteLine("****************************-Row-*******************************************");
                Console.WriteLine($"Titiulo: {i.Titule}\n Columna: {i.Columns}\n Tipo: {i.Type} \n IsNUll {i.IsNull}");

            }
        }
        /// <summary>
        /// Te muestra los nombres de las tablas que wxiten en la dase de datos 
        /// </summary>
        public void showNameTable()
        {
            var lista = genetateTables.Generate().GroupBy(x => x.Titule).Select(x => x.FirstOrDefault());
            int NumeroDeTabla = 1;
            foreach (var i in lista)
            {
                Console.WriteLine($"**********-Table {NumeroDeTabla++}-***********");
                Console.WriteLine($"Titiulo: {i.Titule}");

            }
        }

        public List<string> NameTable()
        {
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

﻿using System;

namespace GeneradorDeCodigo
{
    class Program
    {

        static void Main(string[] args)
        {
            ShowAll showAll = new ShowAll();
            GenerateFileEnty generateFile = new GenerateFileEnty();

            generateFile.CreateField(@"D:\", "CLIENTES");

            if (args.Length == 0)
            {
                Console.WriteLine($"Si no sabes como prosegir teclea -h o -help para ver las sentecias que exiten \n" +
                                  $"Generador de Mps Y Entidades sobre la base de datos FierBid\n desarollador TRSF\n vercion 1.0");
            }
            else
            {
                if (args[0] == "-h" || args[0] == "-help")
                {
                    Console.WriteLine($" -m/-map \"<Nombre De la Tabla>\" *Te mostrara una Vista Previa De Un Map ");
                    Console.WriteLine($" -e/-empty \"<Nombre De la Tabla>\" *Te mostrara una Vista Previa De Un Map ");
                    Console.WriteLine($" -t/-tables \"<Nombre De la Tabla>\" *Te mostara un listado de las columnas  de una tabla e informasin de la misma \n " +
                                      $" -t/-tables sin un parameto te mostrara los nombres de todas las tablas  ");
                }
                if (args[0] == "-m" || args[0] == "-map")
                {
                    showAll.showMap(args[1]);
                }
                if (args[0] == "-e" || args[0] == "-empty")
                {
                    showAll.showEnty(args[1]);
                }
                if (args[0] == "-t" || args[0] == "-tables")
                {
                    if (args.Length==2)
                    {
                        showAll.showAllTable(args[1]);
                    }
                    else
                    {
                        showAll.showNameTable();
                    }
                }

            }
        }

    }
}

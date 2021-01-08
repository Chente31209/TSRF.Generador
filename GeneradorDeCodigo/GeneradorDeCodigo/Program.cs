using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using System;
using System.IO;

namespace GeneradorDeCodigo
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            Console.BackgroundColor= ConsoleColor.Cyan;
            
            string path = Directory.GetCurrentDirectory();
            IdbConnection idb;
            IWriter writer;
            GenerateFileEnty generateFile;
            GenerateFileBuilder generateFileMap;
            GenerateFileDto generateFileDto;
            GenerateFileModel generateFileModel;
                if (args.Length == 0)
                {
                    Console.WriteLine($"Si no sabes como prosegir teclea -h o -help para ver las sentecias que exiten \n" +
                                      $"Generador de Mps Y Entidades sobre la base de datos FierBid\n desarollador TRSF\n vercion 1.0");
                }
                else
                {
                    if (args[0] == "-h" || args[0] == "-help")
                    {
                        Console.WriteLine($" -f/-file  \"<Ruta de la basede datos>\" \"<Ruta>\" \"<Nombre de la tabla>\" *Te generar un archivo cs en la ruta indiada ");
                    }

                    if (args[0] == "-f" || args[0] == "-file")
                    {
                        // se asignan las bariables y sus constructores 
                        idb = new ConetionFB(args[1], "sysdba", "masterkey");
                        writer = new FileCreate(idb);
                        generateFile = new GenerateFileEnty(writer, idb);
                        generateFileMap = new GenerateFileBuilder(writer, idb);
                        generateFileDto = new GenerateFileDto(writer, idb);
                        generateFileModel = new GenerateFileModel(writer, idb);

                        // se asigna el paht del deireorio actal y se espefia la tabla 
                        // Comando=> -f <Direcion de la Base De datos> <Nombre de la tabla>
                        if (args.Length == 3)
                        {
                            Console.WriteLine(path);
                            generateFile.CreateField(path, args[2]);
                            generateFileDto.CreateField(path, args[2]);
                            generateFileModel.CreateField(path, args[2]);
                            generateFileMap.CreateField(path, args[2]);

                        }
                        // se asigana el paht por el usario y se nombra la tabla 
                        // Comando=> -f <Direcion de la Base De datos> <diercion de gardado> <Nombre de la tabla>
                        if (args.Length == 4)
                        {
                            generateFile.CreateField(args[2], args[3]);
                            generateFileDto.CreateField(args[2], args[3]);
                            generateFileModel.CreateField(args[2], args[3]);
                            generateFileMap.CreateField(args[2], args[3]);

                        }
                        // no se espefia nada solo se ejecuta el comado y crea los archivos en el direori actal 
                        // Comando=> -f <Direcion de la Base De datos> 
                        if (args.Length == 2)
                        {
                            generateFile.CreateFieldAll(path);
                            generateFileDto.CreateFieldAll(path);
                            generateFileModel.CreateFieldAll(path);
                            generateFileMap.CreateFieldAll(path);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = loggerFactory.CreateLogger<Program>();
                logger.LogError($"ocurio un error de tipo \n {e.Message}");
            }
        }
    }
}

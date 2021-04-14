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
            try
            {
                string acion="-h",
                       pathfb = @"D:\PRUEBAWEBAPI.FDB",
                       guardado=@"D:\",
                       Nametable="CLIENTES";
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
                    foreach (var item in args)
                    {
                        if (item.Contains("-"))
                            acion = item;
                        if (item.Contains(".FDB") && item.Contains(@":\"))
                            pathfb = item;
                        if (item.Contains(@":\"))
                            guardado = item;
                        else
                            Nametable = item;
                    }
                    Console.WriteLine($"a {acion} p {pathfb} g {guardado} n {Nametable}");
                    if (acion == "-h" || acion == "-help")
                    {
                        Console.WriteLine($" -f/-file  \"<Ruta de la basede datos>\" \"<Ruta>\" \"<Nombre de la tabla>\" *Te generar un archivo cs en la ruta indiada ");
                    }
                    if (acion == "-f" || acion == "-file")
                    {
                        // se asignan las bariables y sus constructores 
                        idb = new ConetionFB(pathfb, "sysdba", "masterkey");
                        writer = new FileCreate(idb);
                        generateFile = new GenerateFileEnty(writer, idb);
                        generateFileMap = new GenerateFileBuilder(writer, idb);
                        generateFileDto = new GenerateFileDto(writer, idb);
                        generateFileModel = new GenerateFileModel(writer, idb);
                        // se asigna el paht del deireorio actal y se espefia la tabla 
                        // Comando=> -f <Direcion de la Base De datos> <Nombre de la tabla>
                        if (args.Length == 3)
                        {
                            generateFile.CreateField(path, Nametable);
                            generateFileDto.CreateField(path, Nametable);
                            generateFileModel.CreateField(path, Nametable);
                            generateFileMap.CreateField(path, Nametable);
                        }
                        // se asigana el paht por el usario y se nombra la tabla 
                        // Comando=> -f <Direcion de la Base De datos> <diercion de gardado> <Nombre de la tabla>
                        if (args.Length == 4)
                        {
                            generateFile.CreateField(guardado, Nametable);
                            generateFileDto.CreateField(guardado, Nametable);
                            generateFileModel.CreateField(guardado, Nametable);
                            generateFileMap.CreateField(guardado, Nametable);
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

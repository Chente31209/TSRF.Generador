using System;

namespace GeneradorDeCodigo
{
    class Program
    {
        static void Main(string[] args)
        {

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
                    //@"D:\PRUEBAWEBAPI.FDB"
                    idb = new ConetionFB(args[1], "sysdba", "masterkey");
                    writer = new FileCreate(idb);
                    generateFile = new GenerateFileEnty(writer, idb);
                    generateFileMap = new GenerateFileBuilder(writer, idb);
                    generateFileDto = new GenerateFileDto(writer, idb);
                    generateFileModel = new GenerateFileModel(writer, idb);

                    if (args.Length == 4)
                    {
                       
                        generateFile.CreateField(args[2], args[3]);
                        generateFileMap.CreateField(args[2], args[3]);
                        generateFileDto.CreateField(args[2], args[3]);
                        generateFileModel.CreateField(args[2], args[3]);
                    }
                    else
                    {
                        generateFileMap.CreateFieldAll(@"D:\01_Pruebas De GF");
                        generateFile.CreateFieldAll(@"D:\01_Pruebas De GF");
                    }
                }
            }
        }

    }
}

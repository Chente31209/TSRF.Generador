using System;

namespace GeneradorDeCodigo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string tabla = "ZONAS_CLIENTES";
            GenerateEntity generateEntity = new GenerateEntity();
            GenetrateMap genetrateMap = new GenetrateMap();
            GenetateTables genetateTables = new GenetateTables();

            genetateTables.show();
            generateEntity.show(tabla);
            genetrateMap.show(tabla);
            
        }

    }
}

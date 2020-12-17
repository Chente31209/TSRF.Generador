using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeneradorDeCodigo
{
    public static class Codigo
    {
        public static string ClassPropertis(string Titulo,string type)
        {
            List<string> Propiedades = new List<string> { };
            GeneratePropertis generateEntity = new GeneratePropertis();
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Titulo.ToLower());
            string Enabesado = $"using System;\n" +
                $"namespace TRSF\n{{\n public class {Nombre}{type}\n{{ ";
            string Cuerpo = "";
            foreach(var i in generateEntity.Generate(Titulo))
            {
                Propiedades.Add($"{i.TableEntity} \n");
            }
            Cuerpo = String.Join(' ', Propiedades);
            string Fll = $"{Enabesado}\n {Cuerpo}\n }}\n}}";
            return Fll;
        }

        public static string CassBuilder(string Titulo)
        {
            GenetrateBuilder genetrateMap = new GenetrateBuilder();

            List<string> Propiedades = new List<string> { };
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Titulo.ToLower());
            string Enabesado = $"using System;\n using System.Collections.Generic; \n using System.Text;\nusing Microsoft.EntityFrameworkCore;\nusing Data.Contract.Entities; \n" +
                $"namespace TRSF\n{{\n public static class {Nombre}Builder\n{{\n " +
                $"public static void Builder (ModelBuilder modelBuilder)\n{{ ";
            string Cuerpo = "";
            foreach (var i in genetrateMap.Generate(Titulo))
            {
                Propiedades.Add($"{i.Map} \n");
            }
            Cuerpo = String.Join(' ', Propiedades);
            string Fll = $"{Enabesado}\n {Cuerpo}\n }}\n }}\n}}";
            return Fll;
        }

    }
    //var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase();
}

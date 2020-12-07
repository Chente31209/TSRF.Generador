using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeneradorDeCodigo
{
    public static class Codigo
    {
        public static string classEnty(string Titulo)
        {
            List<string> Propiedades = new List<string> { };
            GenerateEntity generateEntity = new GenerateEntity();
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Titulo.ToLower());
            string Enabesado = $"namespace <Nombre>{{\n public class {Nombre}Entity{{ ";
            string Cuerpo = "";
            foreach(var i in generateEntity.Generate(Titulo))
            {
                Propiedades.Add($"{i.TableEntity} \n");
            }
            Cuerpo = String.Join(' ', Propiedades);
            string Fll = $"{Enabesado}\n {Cuerpo}\n }}\n}}";
            return Fll;
        }

        public static string classMap(string Titulo)
        {
            GenetrateMap genetrateMap = new GenetrateMap();

            List<string> Propiedades = new List<string> { };
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Titulo.ToLower());
            string Enabesado = $"Mappear (ModelBuilder modelBuilder){{ ";
            string Cuerpo = "";
            foreach (var i in genetrateMap.Generate(Titulo))
            {
                Propiedades.Add($"{i.Map} \n");
            }
            Cuerpo = String.Join(' ', Propiedades);
            string Fll = $"{Enabesado}\n {Cuerpo}\n }}";
            return Fll;
        }

    }
    //var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase();
}

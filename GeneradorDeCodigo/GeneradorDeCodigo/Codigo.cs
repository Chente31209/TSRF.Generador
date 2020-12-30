using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeneradorDeCodigo
{
    public  class Codigo
    {
        readonly IdbConnection _Idb;
        public Codigo(IdbConnection Idb)
        {
            this._Idb = Idb;
        }
        public  string ClassPropertis(string Titulo,string type)
        {
            List<string> Propiedades = new List<string> { };
            GeneratePropertis generateEntity = new GeneratePropertis(_Idb);
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Titulo.ToLower());
            string Enabesado = $"using System;\n" +
                $"namespace TRSF\n{{\n \tpublic class {Nombre}{type}\n\t{{\t ";
            string Cuerpo = "";
            foreach(var i in generateEntity.Generate(Titulo))
            {
                Propiedades.Add($"\t\t{i.TableEntity} \n");
            }
            Cuerpo = String.Join(' ', Propiedades);
            string Fll = $"{Enabesado}\n {Cuerpo}\n \t}}\n}}";
            return Fll;
        }

        public  string CassBuilder(string Titulo)
        {
            GenetrateBuilder genetrateMap = new GenetrateBuilder(_Idb);

            List<string> Propiedades = new List<string> { };
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Titulo.ToLower());
            string Enabesado = $"using System;\n using System.Collections.Generic; \n using System.Text;\nusing Microsoft.EntityFrameworkCore;\nusing Data.Contract.Entities; \n" +
                $"namespace TRSF\n{{\n\t public static class {Nombre}Builder\n\t{{\n " +
                $"\t\tpublic static void Builder (ModelBuilder modelBuilder)\n\t\t{{ ";
            string Cuerpo = "";
            foreach (var i in genetrateMap.Generate(Titulo))
            {
                Propiedades.Add($"\t\t\t{i.Map} \n");
            }
            Cuerpo = String.Join(' ', Propiedades);
            string Fll = $"{Enabesado}\n {Cuerpo}\n \t\t}}\n \t }}\n}}";
            return Fll;
        }

    }
    //var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase();
}

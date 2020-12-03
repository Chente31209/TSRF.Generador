using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeneradorDeCodigo
{
    public static class FormatWord
    {
        public static string ParseMinusulas(string Palabra)
        {
            var Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Palabra.ToLower());
            return Nombre;
        }


    }
}

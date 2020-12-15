using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GeneradorDeCodigo
{
    public class GenetrateBuilder
    {
       
        List<DBMap> dBMaps = new List<DBMap> ();
        public List<DBMap> Generate(string Titule)
        {

            DBMap dBMap = new DBMap();
            var tables = LinqQueris.Tables(Titule);
            var key = LinqQueris.Keys(Titule);

            
            dBMaps.Add(new DBMap { Map = $"var {FormatWord.ParseMinusulas(Titule)} = modelBuilder.Entity<{Titule}Entity>();" });
            dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.HasKey(x => x.{FormatWord.ParseMinusulas(key.Key)}).HasName(\"{key.Key}\");" });
            foreach (var i in tables)
            {
                dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.Property(x => x.{FormatWord.ParseMinusulas(i.Columns.ToLower())}).HasColumnName(\"{i.Columns}\");" });
            }
            dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.ToTable(\"{Titule}\");" });
            // Moneda.ToTable("MONEDAS");
            return dBMaps;
        }

       
        
    }
}

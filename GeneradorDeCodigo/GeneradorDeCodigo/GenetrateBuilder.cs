using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;



namespace GeneradorDeCodigo
{
    public class GenetrateBuilder
    {
        IdbConnection _idb;
        public GenetrateBuilder(IdbConnection idb)
        {
            this._idb = idb;
            

        }
       
        List<DBMap> dBMaps = new List<DBMap> ();
       

        public List<DBMap> Generate(string Titule)
        {
            LinqQueris linqQueris = new LinqQueris(_idb);
                var tables = linqQueris.Tables(Titule);
                var key = linqQueris.Keys(Titule);

                var titule = FormatWord.ParseMinusulas(Titule);
                dBMaps.Add(new DBMap { Map = $"var {FormatWord.ParseMinusulas(Titule)} = modelBuilder.Entity<{titule}Entity>();" });
            try
            {
                if (key is null)
                {
                    dBMaps.Add(new DBMap
                    {
                        Map = $"{FormatWord.ParseMinusulas(Titule)}.HasKey(x => x./*lo siento no se encotro uma Key */).HasName(\"lo siento no se encotro uma Key \");"
                    });
                }
                else
                {
                    if (key.Key is null)
                    {
                        dBMaps.Add(new DBMap
                        {
                            Map = $"{FormatWord.ParseMinusulas(Titule)}.HasKey(x => x./*lo siento no se encotro uma Key */).HasName(\"lo siento no se encotro uma Key \");"
                        });
                    }
                    else
                    {
                        dBMaps.Add(new DBMap
                        {
                            Map = $"{FormatWord.ParseMinusulas(Titule)}.HasKey(x => x.{FormatWord.ParseMinusulas(key.Key)}).HasName(\"{key.Key}\");"
                        });
                    }
                }

                foreach (var i in tables)
                {
                    dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.Property(x => x.{FormatWord.ParseMinusulas(i.Columns.ToLower())}).HasColumnName(\"{i.Columns}\");" });
                }
                dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.ToTable(\"{Titule}\");" });
                Console.WriteLine("se corrio el bulder " +
                    "1");
                return dBMaps;
                
            }
            catch (NullReferenceException e)
            {
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = loggerFactory.CreateLogger<GenetrateBuilder>();
                logger.LogError($"{e}");
               
                foreach (var i in tables)
                {
                    dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.Property(x => x.{FormatWord.ParseMinusulas(i.Columns.ToLower())}).HasColumnName(\"{i.Columns}\");" });
                }
                dBMaps.Add(new DBMap { Map = $"{FormatWord.ParseMinusulas(Titule)}.ToTable(\"{Titule}\");" });
                return dBMaps;
               
            }
            

        }

       
        
    }
}

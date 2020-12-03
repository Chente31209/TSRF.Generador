using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace GeneradorDeCodigo
{
    public class ConnectionDB
    {
		public List<String> Row { get; set; }
		public List<String> key { get; set; }
		public List<String> TablaRow { get; set; }

		public  List<String> ColumnDB(string sentecia)
		{
			Row = new List<string> { };
			using (var connection = new FbConnection(@"database=localhost:D:\PRUEBAWEBAPI.FDB;user=sysdba;password=masterkey"))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					using (var command = new FbCommand(sentecia, connection, transaction))
					{
						using (var reader = command.ExecuteReader())
						{

							while (reader.Read())
							{
								var values = new object[reader.FieldCount];
								reader.GetValues(values);
								Row.Add(string.Join("|", values));
								
							}
						}
					}
				}
			}
			return Row;
		}
		public List<String> Tabla(string sentecia)
        {
			TablaRow = new List<String> { };
            foreach (var i in ColumnDB(sentecia))
            {
				TablaRow.Add(i);
            }
            
			return TablaRow;

		}
		public List<String> PrimaryKey(string sentecia)
		{
			key = new List<String> { };
			foreach (var i in ColumnDB(sentecia))
			{
				key.Add(i);
			}
			return key;

		}
	}
}

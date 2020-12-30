using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace GeneradorDeCodigo
{
	public class ConnectionDB  
	{
        readonly IdbConnection _Idb;
		public ConnectionDB(IdbConnection idb)
		{
			this._Idb = idb;
		}
		public List<String> ColumnDB(string sentecia)
		{
			var Row = new List<string> { };
			using (var connection = _Idb.GetConnection()/*GetConnection(@"D:\PRUEBAWEBAPI.FDB", "sysdba", "masterkey")*/)
			{
				connection.Open();
				using (var command = new FbCommand(sentecia, connection))
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
				connection.Close();
			}
			return Row;
		}
		public List<String> Tabla(string sentecia)
		{
			var TablaRow = new List<String> { };
			foreach (var i in ColumnDB(sentecia))
			{
				TablaRow.Add(i);
			}
			return TablaRow;
		}
		public List<String> PrimaryKey(string sentecia)
		{
			var key = new List<String> { };
			foreach (var i in ColumnDB(sentecia))
			{
				key.Add(i);
			}
			return key;
		}
	}
}
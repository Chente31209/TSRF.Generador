using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    class ConetionFB : IdbConnection	
    {
        private readonly string bsaedeDatos;
        private readonly string user;
        private readonly string pasword;

        public ConetionFB(string bsaedeDatos, string user, string pasword)
		{
			this.bsaedeDatos = bsaedeDatos;
			this.user = user;
			this.pasword = pasword;
		}
		private static FbConnection Connection { get; set; }
		public FbConnection GetConnection()
		{
			if (Connection is null || Connection.State == System.Data.ConnectionState.Closed)
			{
				Connection = new FbConnection($"database=localhost:{this.bsaedeDatos};user={this.user};password={this.pasword}");

				return Connection;
			}
			else
				return Connection;
		}
	}
}

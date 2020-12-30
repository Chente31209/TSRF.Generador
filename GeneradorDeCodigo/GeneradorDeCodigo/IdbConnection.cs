using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public interface IdbConnection
    {
        //FbConnection GetConnection(string bsaedeDatos, string user, string pasword);
        FbConnection GetConnection();

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public interface IWriter
    {
        void Writer(string route, string Titulo, string type, string Codigo );
    }
}

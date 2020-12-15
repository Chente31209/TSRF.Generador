﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace GeneradorDeCodigo
{
    public class GenerateFileEnty
    {
        IWriter _writer;
        public GenerateFileEnty(IWriter writer)
        {
            this._writer = writer;

        }
       
        public void CreateField(string route, string Titulo)
        {
            string CodigoGenerado = Codigo.ClassPropertis(Titulo,"Enty");
            _writer.Writer(route, Titulo,"Enty", CodigoGenerado);
        }
        public void CreateFieldAll(string route)
        {
            
            ShowAll showAll = new ShowAll();
            foreach (var i in showAll.NameTable())
            {
                string CodigoGenerado = Codigo.ClassPropertis(i,"Enty");
                _writer.Writer(route, i, "Enty", CodigoGenerado);
            }
        }
       
    }
}

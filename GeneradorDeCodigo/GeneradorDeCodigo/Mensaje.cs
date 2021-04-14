using System;

namespace GeneradorDeCodigo
{
    public static class Mensaje
    {
        public static void MensajeDeCreacion(string Tipo,string Titiulo)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Se creo el {Tipo} de {Titiulo}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

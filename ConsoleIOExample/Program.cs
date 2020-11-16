using System;
using System.IO;

namespace ConsoleIOExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Ejecutar el programa de la siguiente manera: ConsoleIOExample entrada.txt salida.txt");
                return;
            }
            try
            {
                // Intentamos abrir el archivo de salida para escribir
                using (var writer = new StreamWriter(args[1]))
                {
                    using (var reader = new StreamReader(args[0]))
                    {
                        // Redireccionamos salida estandar a archivo.
                        Console.SetOut(writer);
                        // Redireccionamos entrada estandar a archivo.
                        Console.SetIn(reader);
                        string line;
                        while ((line = Console.ReadLine()) != null)
                        {
                            string newLine = line.Replace(" ", "\t");
                            Console.WriteLine(newLine);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return;
            }

            // Restauramos la salida a pantalla
            var standarOutput = new StreamWriter(Console.OpenStandardOutput());
            standarOutput.AutoFlush = true;
            Console.SetOut(standarOutput);
            Console.WriteLine($"Se han sustituido espacio por tabuladores exitomente en {args[0]}.");
            return;
        }
    }
}

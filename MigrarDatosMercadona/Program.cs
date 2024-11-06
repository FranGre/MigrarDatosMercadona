using MigracionDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrarDatosMercadona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var csvOrigen = @"C:\Users\J\Downloads\customers-100.csv";
            var csvDestino = @"C:\Users\J\Downloads\newcustomers-100.csv";

            // Csv.GenerarNuevoCsvLimpio(csvOrigen, csvDestino);

            var clientes = Csv.ObtenerClientes(csvDestino);

            var migracion = new Migracion();
            migracion.InsertarDatos(clientes);
            // el problema es que se me cierra
        }
    }
}

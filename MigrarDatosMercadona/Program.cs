using MigracionDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrarDatosMercadona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var directorioRaizproyecto = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            var csvOrigen = $"{directorioRaizproyecto}/customers-100.csv";
            var csvDestino = $"{directorioRaizproyecto}/c-100.csv";

            Csv.GenerarNuevoCsvLimpio(csvOrigen, csvDestino);

            var clientes = Csv.ObtenerClientes(csvDestino);

            var migracion = new Migracion();
            // a pesar de esta sea mas lenta, es la mas segura.
            // ya que al hacer Add() y SaveChanges() dentro del mismo bucle, en caso de que falle en insertar el campo,
            // permite saber en cual item ha fallado y porque. Ademas me permite debugar dicho item
            migracion.InsertarDatosSaveChangesDentroDelBucle(clientes);
        }
    }
}

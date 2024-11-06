using MigracionDatos.Contexto;
using MigracionDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigracionDatos
{
    internal class Migracion
    {
        private AppDbContexto db = new AppDbContexto();

        public void InsertarDatos(List<Customer> customers)
        {
            if (customers == null || customers.Count == 0)
            {
                Consola.EscribirError("Customers vacios");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var customer in customers)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            stopwatch.Stop();
            Consola.EscribirExito($"Ha tardado {stopwatch.Elapsed.TotalMilliseconds}ms");

        }
    }
}

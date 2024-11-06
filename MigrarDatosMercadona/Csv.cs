using MigracionDatos.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigracionDatos
{
    internal class Csv
    {
        private const char SEPARATOR = ',';
        private const int INDEX = 0;
        private const int CUSTOMER_ID = 1;
        private const int FIRST_NAME = 2;
        private const int LAST_NAME = 3;
        private const int COMPANY = 4;
        private const int CITY = 5;
        private const int COUNTRY = 6;
        private const int PHONE1 = 7;
        private const int PHONE2 = 8;
        private const int EMAIL = 9;
        private const int SUBSCRIPDION_DATE = 10;
        private const int WEBSITE = 11;

        public static void GenerarNuevoCsvLimpio(string rutaCsvOrigen, string rutaCsvExportar)
        {
            if (!File.Exists(rutaCsvOrigen))
            {
                Consola.EscribirError("Fichero no existe");
                return;
            }

            StreamReader reader = new StreamReader(File.OpenRead(rutaCsvOrigen));
            StreamWriter writer = new StreamWriter(File.OpenWrite(rutaCsvExportar));
            bool esPrimeraLinea = true;

            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();

                if (esPrimeraLinea)
                {
                    writer.WriteLine(linea);
                    esPrimeraLinea = false;
                    continue;
                }

                var lineaSplit = linea.Split(SEPARATOR);

                writer.WriteLine(string.Join(SEPARATOR.ToString(),
                    new string[] {
                    lineaSplit[INDEX],
                    Guid.NewGuid().ToString(),
                    lineaSplit[FIRST_NAME],
                    lineaSplit[LAST_NAME],
                    lineaSplit[COMPANY],
                    lineaSplit[CITY],
                    lineaSplit[COUNTRY],
                    lineaSplit[PHONE1],
                    lineaSplit[PHONE2],
                    lineaSplit[EMAIL],
                    lineaSplit[SUBSCRIPDION_DATE],
                    lineaSplit[WEBSITE]
                    })
                );
            }
            reader.Close();
            writer.Close();

            Consola.EscribirExito("Nuevo csv exportado corrrectamente");
        }

        public static List<Customer> ObtenerClientes(string rutaCsv)
        {
            if (!File.Exists(rutaCsv))
            {
                Consola.EscribirError("Fichero no existe");
                return null;
            }

            StreamReader reader = new StreamReader(File.OpenRead(rutaCsv));
            List<Customer> customers = new List<Customer>();
            bool esPrimeraLinea = true;

            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();

                if (esPrimeraLinea)
                {
                    esPrimeraLinea = false;
                    continue;
                }

                var lineaSplit = linea.Split(SEPARATOR);
                Customer customer = new Customer
                {
                    Id = Guid.Parse(lineaSplit[CUSTOMER_ID]),
                    FirstName = lineaSplit[FIRST_NAME],
                    LastName = lineaSplit[LAST_NAME],
                    Company = lineaSplit[COMPANY],
                    City = lineaSplit[CITY],
                    Country = lineaSplit[COUNTRY],
                    Phone1 = lineaSplit[PHONE1],
                    Phone2 = lineaSplit[PHONE2],
                    Email = lineaSplit[EMAIL],
                    SubscriptionDate = Convert.ToDateTime(lineaSplit[SUBSCRIPDION_DATE]),
                    Website = lineaSplit[WEBSITE]
                };
                customers.Add(customer);
            }
            Consola.EscribirExito("Customers Convertidos Correctamente :)");
            reader.Close();
            return customers;
        }
    }
}

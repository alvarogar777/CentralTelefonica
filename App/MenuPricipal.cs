using System;
using static System.Console;
using CentralTelefonica.Entidades;
using System.Collections.Generic;
using CentralTelefonica.Util;

namespace CentralTelefonica.App
{
    public class MenuPricipal
    {
        private const float precioUnoDepartamental = 0.65f;
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 0.49f;
        public List<Llamada> ListaDeLlamadas { get; set; }

        public MenuPricipal()
        {
            this.ListaDeLlamadas = new List<Llamada>();
        }

        public void MostrarMenu()
        {
            int opcion = 0;

            do
            {
                try
                {
                    WriteLine("1. Registrar LLamada Local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamadas departamentales");
                    WriteLine("5. Costo total de las lladadas");
                    WriteLine("6. Mostrar resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opcion====>");
                    string valor = ReadLine();
                    opcion = Convert.ToInt16(valor);
                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalleDoWhile();
                        //NumeroImpares();
                    }

                }
                catch (Exception e)
                {
                    if (e is OptionMenuException)
                    {
                        Write(e.Message);
                    }
                    //throw new OptionMenuException(); 
                    //WriteLine($"Error: {e.Message}");
                    opcion = 100;

                }
            } while (opcion != 0);

        }

        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
            Llamada llamada = null;

            WriteLine("Ingrese el numero de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el numeor de destino");
            numeroDestino = ReadLine();
            WriteLine("Duracion de la llamada");
            duracion = ReadLine();
            //WriteLine("Tipo de llamada: \n 1.Local \n 2.Depto");
            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                /*llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion= Convert.ToDouble(duracion);*/
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                /*lamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion= Convert.ToDouble(duracion);*/
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0;
            }
            else
            {
                WriteLine("Tipo de llamada no registrada");
            }
            this.ListaDeLlamadas.Add(llamada);
        }

        public void MostrarDetalleWhile()
        {
            int i = 0;
            while (this.ListaDeLlamadas.Count > i)
            {
                Write(this.ListaDeLlamadas[i]);
                i++;
            }
        }

        public void MostrarDetalleDoWhile()
        {
            int i = 0;
            do
            {
                WriteLine(this.ListaDeLlamadas[i]);
                i++;
            } while (this.ListaDeLlamadas.Count > i);
        }

        public void MostrarDetalleFor()
        {
            for (int i = 0; i < this.ListaDeLlamadas.Count; i++)
            {
                WriteLine(this.ListaDeLlamadas[i]);
            }
        }

        public void MostrarDetalleForeach()
        {
            foreach (var llamada in this.ListaDeLlamadas)
            {
                WriteLine(llamada);
            }
        }

        public void NumeroImpares()
        {
            int i = 1;
            int o = 10;
            while (i <= 15)
            {
                if ((i % 2) != 1 & o == 10)
                {
                    i++;
                    continue;
                }
                WriteLine($"Nummero impar {i}");
                i++;
            }

        }
    }
}
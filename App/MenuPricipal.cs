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
        private const float precioLocal = 1.25f;
        public List<Llamada> ListaDeLlamadas { get; set; }

        public MenuPricipal()
        {
            this.ListaDeLlamadas = new List<Llamada>();
        }

        public void MostrarMenu()
        {
            int opcion = 100;

            do
            {
                try
                { 
                    //Clear();
                    WriteLine("1. Registrar LLamada Local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamadas departamentales");
                    WriteLine("5. Costo total de las lladadas");
                    WriteLine("6. Mostrar resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opcion====>");
                    string valor = ReadLine();
                    if (EsNumero(valor)==true)
                    {
                        opcion=Convert.ToInt16(valor);
                    }
                    
                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if(opcion == 3)
                    {
                        MostrarCostoLlamadasLocales();
                    }
                    else if (opcion ==4)
                    {
                        MostrarDetalleLlamadaDepto();
                    }
                    else if (opcion == 6)
                    {                        
                        MostrarDetalleForeach();
                    }

                }
                catch (OptionMenuException e)
                {                  
                        WriteLine(e.Message);
                }
            } while (opcion != 0);

        }

        public Boolean EsNumero(string valor){
            Boolean resultado=false;
            try
            {
                
                int numero;
                numero = Convert.ToInt16(valor);
                resultado = true;
            }
            catch (System.Exception)
            {
                
                throw new OptionMenuException();
            }
            return resultado;
        }

        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
            Llamada llamada = null;

            WriteLine("Ingrese el numero de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el numero de destino");
            numeroDestino = ReadLine();
            WriteLine("Duracion de la llamada");
            duracion = ReadLine();

            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = CalcularFranja(DateTime.Now);
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

        public void MostrarCostoLlamadasLocales()
        {
            double tiempoLlamada = 0;
            double costoTotal = 0.0;
            foreach (Llamada elemento in this.ListaDeLlamadas)
            {
                
                if (elemento.GetType() == typeof(LlamadaLocal))
                {
                    tiempoLlamada+= elemento.Duracion;
                    costoTotal += elemento.CalcularPrecio();
                }
                
            }
            WriteLine($"Costo minuto: {precioLocal}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamada}");
            WriteLine($"Costo Total de llamadas locales: {costoTotal}");

        }
        
        public void MostrarDetalleLlamadaDepto()
        {
            double tiempoLlamadaFranjaUno = 0;
            double tiempoLlamadaFranjaDos = 0;
            double tiempoLlamadaFranjaTres = 0;
            double costoTotalFranjaUno = 0.0;
            double costoTotalFranjaDos = 0.0;
            double costoTotalFranjaTres = 0.0;
            foreach (var elemento in this.ListaDeLlamadas)
            {
                if(elemento.GetType() == typeof(LlamadaDepartamental))
                {
                    switch (((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                            tiempoLlamadaFranjaUno += elemento.Duracion;
                            costoTotalFranjaUno += elemento.CalcularPrecio();
                            break;    
                        case 1:
                            tiempoLlamadaFranjaDos+= elemento.Duracion;
                            costoTotalFranjaDos += elemento.CalcularPrecio();
                            break; 
                        case 2:
                            tiempoLlamadaFranjaTres += elemento.Duracion;
                            costoTotalFranjaTres += elemento.CalcularPrecio();
                            break;                     
                        default:
                            break;
                    }
                    
                }
            }
            WriteLine("Franja: 1");
            WriteLine($"Costo minuto: {precioUnoDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaUno}");
            WriteLine($"Costo Total de llamadas locales: {costoTotalFranjaUno}");

            WriteLine("Franja: 2");
            WriteLine($"Costo minuto: {precioDosDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaDos}");
            WriteLine($"Costo Total de llamadas locales: {costoTotalFranjaDos}");

            WriteLine("Franja: 3");
            WriteLine($"Costo minuto: {precioTresDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaTres}");
            WriteLine($"Costo Total de llamadas locales: {costoTotalFranjaTres}");

        }

        public int CalcularFranja(DateTime fecha){            
            Int16 resultado = 0;
            fecha = DateTime.Now;                     
            int numeroDia =(int)fecha.DayOfWeek;
            int hora = fecha.Hour;
            int minutos = fecha.Minute;

            if (hora >= 6 && hora <= 21)  //si la hora es mayor o igual a las 6 am y es menor o igual a las 21:59 horas
            {
                if (numeroDia >= 1 && numeroDia <= 5) // valida si el dia esta entre lunes hasta el viernes
                {
                    resultado = 0;  // Franja 0 = lunes(6:00) - viernes(21:59)             
                }
                else if (numeroDia == 6 || numeroDia == 0 ) // valida si es domingo o sabado 
                {
                    resultado = 2; // Franja 2 = sabado(6:00 - 21:59) - domingo(6:00 - 21:59)
                }
            }
            else if(hora >= 22 || hora <= 5) // la hora que valida es de 22 horas hasta las 5:59
            { 
                if ((numeroDia >= 1 && numeroDia <= 5) & hora >=22 ) //valida si el dia esta entre lunes y viernes despues de las 22 horas
                { 
                    resultado = 1; // Franja 1 = lunes(22:00) - viernes(5:59)
                }
                else if (numeroDia >= 2 && numeroDia <= 5) // valida entre el martes y viernes desde las 6:00
                {
                    resultado = 1; // Franja 1 = martes(0:00) - viernes(5:59)
                }
                else if(numeroDia == 5 || numeroDia == 6 || numeroDia == 0 || numeroDia == 1 )
                {
                    resultado = 2; // Franja 2 = viernes(22:00) al sabado(5:59) - sabado(22:00) al domingo(5:59) - domingo(22:00) al lunes(5:59)
                }
                
            }
            return resultado;
        }
        /*public void NumeroImpares()
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

        } */
    }
}
using System;
using CentralTelefonica.Entidades;
using System.Collections.Generic;

namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            LlamadaDepartamental llamadaDepto = new LlamadaDepartamental();
            llamadaDepto.NumeroDestino="123";
            llamadaDepto.NumeroOrigen="456";
            llamadaDepto.Franja =0;
            llamadaDepto.Duracion=10;
            llamadaDepto.PrecioUno=1.5;
            LlamadaLocal llamadaLocal= new LlamadaLocal();
            llamadaLocal.NumeroDestino="789";
            llamadaLocal.NumeroOrigen="1011";
            llamadaLocal.Duracion=5;
            llamadaLocal.Precio=0.96;
            LlamadaLocal otraLocal = new LlamadaLocal();
            otraLocal.NumeroDestino="1213";
            otraLocal.NumeroOrigen="1415";
            otraLocal.Duracion=25;
            otraLocal.Precio=0.96;

            List<Llamada> llamadasReallizadas = new List<Llamada>();
            llamadasReallizadas.Add(llamadaDepto);
            llamadasReallizadas.Add(llamadaLocal);
            llamadasReallizadas.Add(otraLocal);

            foreach (Llamada item in llamadasReallizadas)
            {   
                if (item  is LlamadaLocal)
                {
                    Console.WriteLine($"Llamada Local ({item}) Precio: {item.CalcularPrecio()}"); 
                }
                else if(item is LlamadaDepartamental)
                {
                    Console.WriteLine($"Llamada Depto ({item}) Precio: {item.CalcularPrecio()}"); 
                }
                           
            }
        }
    }
}

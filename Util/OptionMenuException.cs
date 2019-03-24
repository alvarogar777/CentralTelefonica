using System;
namespace CentralTelefonica.Util
{
    public class OptionMenuException : Exception
    {
        private string  message="Error, debe ingresar una funcion valida";
        public override string  Message
        {
            get { return message;}
        }
        
        
    }
}
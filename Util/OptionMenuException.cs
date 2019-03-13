using System;
namespace CentralTelefonica.Util
{
    public class OptionMenuException : Exception
    {
        private string  message="Error, debe ingresar un numero no un caracter";
        public override string  Message
        {
            get { return message;}
        }
        
        
    }
}
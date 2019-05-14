using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    public class C420Exception : Exception
    {
        private Appareil appareil;
        private Zone zone;

        public C420Exception(string message) : base(message)
        {
        }      
        public C420Exception(string message, Exception innerException)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
        internal C420Exception(string message, Zone zone)
        {      
           
        }
        internal C420Exception(string message, Appareil appareil)
        {
            
        }
    }
}

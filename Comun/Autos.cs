using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaAutos.Comun
{
    public class Autos
    {
        public Autos()
        {
                
        }

        private int _AutoId;

        public int AutoId
        {
            get { return _AutoId; }
            set { _AutoId = value; }
        }

        private string _Marca;
        
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        
        private decimal _Precio;

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        public Autos(int AutoId, string Marca, decimal Precio)
        {
            this.AutoId = AutoId;
            this.Marca = Marca;
            this.Precio = Precio;

        }
    }
}
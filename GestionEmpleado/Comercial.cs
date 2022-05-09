using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class Comercial: Empleado
    {
        private float comision;
        private int ventas;

        public Comercial(string dni, string nombre, int edad,
            string estado, float sueldo, string categoria, Departamento unDepartemento, int ventas)
            : base(dni, nombre, edad, estado, sueldo, categoria, unDepartemento)
        {
            this.comision = 0;
            this.ventas = ventas;
        }

        public float Comision { get => comision; set => comision = value; }
        public int Ventas
        {
            get { return ventas; }
            set
            {
                if (value <= 100 && value >= 0)
                {

                }
                ventas = value; 
            }
        }
        
        public void CalcularComision()
        {
            if (Ventas >= 80)
            {
                Comision = 250;
            }
            else if (Ventas >= 50 && Ventas < 80 )
            {
                Comision = 100;
            }

        }

        public override float CalcularNomina()
        {
            float resultado;
            float impuestos;
            float sueldoTotal = Sueldo + Comision;


            if (sueldoTotal >= 20000)
            {
                impuestos = sueldoTotal * 0.25f;
            }
            else if (sueldoTotal >= 15000)
            {

                impuestos = sueldoTotal * 0.20f;
            }
            else if (sueldoTotal >= 10000)
            {
                impuestos = sueldoTotal * 0.10f;
            }
            else
            {
                impuestos = 0;
            }

            resultado = (sueldoTotal + impuestos)/14;

            return resultado;
        }

        public override string ToString()
        {
            return base.ToString() + Ventas +"\n"; 
        }
    }
}

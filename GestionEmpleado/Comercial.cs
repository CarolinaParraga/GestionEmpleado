using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    //almacena los datos del tipo empleado comercial
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
        
        //método para calcular la comisión del comercial
        public int CalcularComision(int ventas)
        {
            int comision = 0;
            if (ventas >= 80)
            {
                comision = 250;
            }
            else if (ventas >= 50 && ventas < 80 )
            {
                comision = 100;
            }
            return comision;

        }

        //redefine método para calcular nómina
        public override float CalcularNomina(int dato)
        {
            float resultado;
            float impuestos;
            float sueldoTotal = Sueldo + dato;


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

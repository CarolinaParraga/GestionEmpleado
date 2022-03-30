using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class JefeDepartamento: Empleado
    {
        private int antiguedad;
        private int plus;

        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public int Plus { get => plus; set => plus = value; }
        
        public JefeDepartamento(string dni, string nombre, int edad,
            string estado, float sueldo, string categoria, Departamento unDepartemento, int antiguedad)
            : base(dni, nombre, edad, estado, sueldo, categoria, unDepartemento)
        {
            this.antiguedad = antiguedad;
            this.plus = 100;
        }

        public void CalcularPlus()
        {
            if (Antiguedad > 5 && Antiguedad <= 10)
            {
                Plus = 150;
            }
            else if (Antiguedad > 10)
            {
                Plus = 200;
            }
        }

        public override float CalcularNomina()
        {
            float resultado;
            float impuestos;
            float sueldoTotal = Sueldo + Plus;


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

            resultado = sueldoTotal + impuestos;

            return resultado;
        }

        public override string ToString()
        {
            return base.ToString() + Antiguedad;
        }
    }
}

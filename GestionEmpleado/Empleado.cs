using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class Empleado : Persona
    {
        private float sueldo;
        private string categoria;
        private Departamento unDepartamento;//asociacion

        public Empleado(string dni, string nombre, int edad,
            string estado, float sueldo, string categoria, Departamento d)
            : base(dni, nombre, edad, estado)

        {
            this.sueldo = sueldo;
            this.categoria = categoria;
            this.unDepartamento = d;
        }

        //public float Sueldo { get => sueldo; set => sueldo = value; }

        public float Sueldo
        {
            get { return sueldo; }
            set
            {
                if (value <= 30000 && value >= 12000)
                {

                }
                sueldo = value;
            }
        }
        public string Categoria { get => categoria; set => categoria = value; }
        public Departamento UnDepartamento { get => unDepartamento; set => unDepartamento = value; }

        public virtual float CalcularNomina(int dato)
        {
            float resultado;
            float impuestos;
            
            if (Sueldo >= 20000)
            {
                impuestos = Sueldo * 0.25f;
            }
            else if (Sueldo >= 15000)
            {

                impuestos = Sueldo * 0.20f;
            }
            else if (Sueldo >= 10000)
            {
                impuestos = Sueldo * 0.10f;
            }
            else
            {
                impuestos = 0;
            }

            resultado = (Sueldo + impuestos + dato)/14;

            return resultado;
        }

        public override bool Contiene(string texto)
        {
            if (base.Contiene(texto) ||
                    Categoria.ToLower().Contains(texto.ToLower())
                    || UnDepartamento.ToString().ToLower().Contains(texto.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Sueldo + "\n    " + Categoria
                + "\n    " + UnDepartamento + "\n    ";
        }
    }
}


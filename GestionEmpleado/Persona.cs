using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
     abstract class Persona: IComparable<Empleado>
    {
        protected string dni;
        protected string nombre;
        protected int edad;
        protected string estado;

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Estado { get => estado; set => estado = value; }

        public Persona(string dni, string nombre, int edad, string estado)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.edad = edad;
            this.estado = estado;
        }

        public override string ToString()
        {
            return GetType().Name + "," + dni + "," + nombre + "," + edad + "," + estado + ",";
        }

        public virtual bool Contiene(string texto)
        {
            if (Nombre.ToLower().Contains(texto.ToLower()) ||
                    Dni.ToLower().Contains(texto.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Empleado other)
        {
            return String.Compare(Nombre, other.Nombre, true);
        }
    }
}

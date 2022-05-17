using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    //clase que almacena los datos de una persona genérica
     abstract class Persona: IComparable<Empleado>
    {
        protected string dni;
        protected string nombre;
        protected int edad;
        protected string estado;

        public string Dni 
        {
            get
            {
                return dni;
            }
            set 
            {
                if (value.ToString().Length == 9)
                {
                    dni = value;
                }
            }
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad 
        {
            get 
            { 
                return edad; 
            }
            set
            {
                if (value <= 99 && value >= 18)
                {
                    edad = value;
                }

            }
        }
        public string Estado 
        {
            get { return estado; }
            set 
            {
                if (value == "soltera" || value == "casada" || value == "divorcida" || value == "viuda")
                {

                }
                estado = value; 
            }
        }

        public Persona(string dni, string nombre, int edad, string estado)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.edad = edad;
            this.estado = estado;
        }

        public override string ToString()
        {
            return GetType().Name + "\n    " + dni + "\n    " 
                + nombre + "\n    " + edad + "\n    " + estado + "\n    ";
        }

        //método para saber si la lista contiene nombre o dni
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

        //método para ordenar la lista por nombre
        public int CompareTo(Empleado other)
        {
            return String.Compare(Nombre, other.Nombre, true);
        }
    }
}

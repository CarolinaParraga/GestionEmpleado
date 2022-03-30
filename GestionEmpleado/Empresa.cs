using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class Empresa
    {
        public const int MAXIMO_DEPARTAMENTOS = 5;
        public struct tipoDireccion
        {
            public string calle;
            public int numero;
            public string localidad;
            public int codigoPostal;
            public string provincia;
        }

        private string nombre;
        private string cif;
        private tipoDireccion direccion;
        private Departamento[] departamentos; //asociacion, almacena los departamento de la empresa
        private int contadorDepartamentos;
        

        public string Nombre { get => nombre; set => nombre = value; }
        public string Cif { get => cif; set => cif = value; }
        public tipoDireccion Direccion { get => direccion; set => direccion = value; }
        internal Departamento[] Departamentos { get => departamentos; set => departamentos = value; }

        public Empresa(string nombre, string cif)
        {
            this.nombre = nombre;
            this.cif = cif;
            departamentos = new Departamento[MAXIMO_DEPARTAMENTOS];//almacena los departamento de la empresa
            contadorDepartamentos = 0;
            direccion.calle = "Avenida Las Flores";
            direccion.numero = 10;
            direccion.localidad = "San Vicente";
            direccion.codigoPostal = 03006;
            direccion.provincia = "Alicante";

        }

        public bool NuevoDepartamento(Departamento d)
        {
            bool resultado = false;

            if (contadorDepartamentos < MAXIMO_DEPARTAMENTOS)
            {
                departamentos[contadorDepartamentos] = d;
                contadorDepartamentos++;
                d.UnaEmpresa = this;
                resultado = true;
            }

            return resultado;
        }


        public bool QuitarDepartamento(Departamento d)
        {
            bool encontrado = false;
            int i = 0;

            while (i < contadorDepartamentos && !encontrado)
            {
                if (departamentos[i].Id == d.Id)
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }

            }

            if (encontrado)
            {
                for (int j = i; j < contadorDepartamentos; j++)
                {
                    departamentos[j] = departamentos[j + 1];
                }
                contadorDepartamentos--;
            }
            return encontrado;
        }

        public void MostrarDepartamentos()
        {
            for (int i = 0; i < contadorDepartamentos; i++)
            {
                Console.WriteLine("    " + (i + 1) + "." + departamentos[i].ToString());
            }
        }

        public override string ToString()
        {
            
            return "    Empresa: " + nombre + "\n\n" + "    CIF: " + cif + "\n" + 
                "    Calle: " + direccion.calle + ", " + direccion.numero + 
                "\n" + "    Localidad: " + direccion.localidad + "\n" +
                "    Código postal: "+ direccion.codigoPostal + "\n" +
                "    Provincia: " + direccion.provincia;
        }
    }
}

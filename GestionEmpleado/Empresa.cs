using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    //clases que almacena los datos de la empresa
    //la empresa está compuesta por máximo 5 departamentos que se inicializan en el constructor
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
        public Departamento[] Departamentos { get => departamentos; set => departamentos = value; }

        public Empresa(string nombre, string cif)
        {
            this.nombre = nombre;
            this.cif = cif;
            departamentos = CargarDepartamentos();//almacena los departamento de la empresa
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
                for (int j = i; j < contadorDepartamentos - 1; j++)
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

        //método para añadir departamento al empleado
        public string DevolverDepartamento(int posicion)
        {
            string resultado = ""; 
            for (int i = 0; i < departamentos.Length; i++)
            {
                switch (posicion)
                {
                    case 0:
                        resultado = departamentos[0].ToString();
                        break;
                    case 1:
                        resultado = departamentos[1].ToString();
                        break;
                    case 2:
                        resultado = departamentos[2].ToString();
                        break;
                    case 3:
                        resultado = departamentos[3].ToString();
                        break;
                    case 4:
                        resultado = departamentos[4].ToString();
                        break;
                }
            }
            return resultado;
        }

        public Departamento[] CargarDepartamentos()
        {
            Departamento[] departamentos = new Departamento[MAXIMO_DEPARTAMENTOS];
            int contador = 0;
            
            string directorio = @".\Archivos";

            if (Directory.Exists(directorio))
            {
                if (!File.Exists("Guardar.txt"))
                {
                    return departamentos;
                }
                try
                {
                    StreamReader fichero = new StreamReader(@".\Archivos\Guardar.txt");
                    string linea;
                    string idDepartamento;
                    string nombreDepartamento;

                    do
                    {
                        linea = fichero.ReadLine();
                        if (linea != null)
                        {
                            string[] datosLinea = linea.Split(",");
                            idDepartamento = datosLinea[0];
                            nombreDepartamento = datosLinea[1];
                            departamentos[contador] = new Departamento(idDepartamento, nombreDepartamento);
                            contador++;
                        }

                    }
                    while (linea != null);
                    fichero.Close();


                    /*foreach (var linea in lineas)
                    {
                        var valores = linea.Split(",");
                        idDepartamento = valores[0];
                        nombreDepartamento = valores[1];
                        departamentos[contador] = new Departamento(idDepartamento, nombreDepartamento);
                        contador++;
                    }*/
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }

            }
            return departamentos;
        }

        public void GuardarDepartamento(Departamento d)
        {
            string directorio = @".\Archivos";

            if (Directory.Exists(directorio))
            {
                try
                {
                    StreamWriter fichero = new StreamWriter(@".\Archivos\Guardar.txt", true);
                    
                        fichero.WriteLine(d.Id + "," + d.Nombre);
                    
                    fichero.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
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

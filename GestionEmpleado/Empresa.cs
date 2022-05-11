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

        public string[] CargarDepartamentos()
        {
            string[] lineas = new string[MAXIMO_DEPARTAMENTOS];
            try
            {
                if (File.Exists(@".\Archivos\Guardar.txt"))
                {
                    lineas = File.ReadAllLines(@".\Archivos\Guardar.txt");
                }
                else
                {
                    Console.WriteLine("IMPORTANTE: no hay departamentos creados.");
                }
               
            }
            catch (Exception e)
            {
                Console.Write("Error: {0}", e.Message);
            }
             
            return lineas;


            /*foreach (var linea in lineas)
            {
                string[] datoslinea = linea.Split(",");
                //Console.WriteLine(datoslinea[0]);
                //Console.WriteLine(datoslinea[1]);
                id = datoslinea[0];
                nombre = datoslinea[1];
                //Console.WriteLine(id);
                //Console.WriteLine(nombre);
                departamentos[contador] = new Departamento(id, nombre);
                contador++;
            }
            
            foreach (var item in departamentos)
            {
                Console.WriteLine(item);
            }*/
            

        }

        public void GuardarDepartamento(Departamento d)
        {
            string directorio = @".\Archivos";

            if (Directory.Exists(directorio))
            {
                try
                {
                    StreamWriter fichero = new StreamWriter(@".\Archivos\Guardar.txt");
                    
                        fichero.WriteLine(d.Id + "," + d.Nombre);
                    
                    fichero.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            DirectoryInfo dir = new DirectoryInfo(directorio);
            FileInfo[] infoFicheros = dir.GetFiles();
            foreach (FileInfo infoUnFich in infoFicheros)
            {
                Console.WriteLine("    Guardado en fichero: {0}, de tamaño {1}, creado {2}",
                infoUnFich.Name,
                infoUnFich.Length,
                infoUnFich.CreationTime);
            }


        }

        public void GuardarDepartamentos()
        {
            StreamWriter fichero = new StreamWriter(@".\Archivos\Guardar.txt");
            for (int i = 0; i < contadorDepartamentos; i++)
            {
                fichero.WriteLine(departamentos[i].ToString());
            }
            fichero.Close();
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

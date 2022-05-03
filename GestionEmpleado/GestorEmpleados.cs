using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class GestorEmpleados
    {

        public void Ejecutar()
        {
            List<Empleado> empleados = Cargar();
            bool salir = false;
            //List<Empleado> empleados = new List<Empleado>();

            Empresa nuevaEmpresa = new Empresa("Inmobiliaria Vistas al Mar", "B76365789");
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Bienvenido al gestor de empleados de: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(nuevaEmpresa);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
          



            /*nuevaEmpresa.Departamentos[0] = new Departamento("D-1", "Contabilidad");
            nuevaEmpresa.NuevoDepartamento(nuevaEmpresa.Departamentos[0]);
            nuevaEmpresa.Departamentos[1] = new Departamento("D-2", "Ventas");
            nuevaEmpresa.NuevoDepartamento(nuevaEmpresa.Departamentos[1]);
            nuevaEmpresa.Departamentos[2] = new Departamento("D-3", "Alquileres");
            nuevaEmpresa.NuevoDepartamento(nuevaEmpresa.Departamentos[2]);
            nuevaEmpresa.Departamentos[3] = new Departamento("D-4", "Marketing");
            nuevaEmpresa.NuevoDepartamento(nuevaEmpresa.Departamentos[3]);
            nuevaEmpresa.Departamentos[4] = new Departamento("D-5", "Administración");
            nuevaEmpresa.NuevoDepartamento(nuevaEmpresa.Departamentos[4]);*/
            //nuevaEmpresa.MostrarDepartamentos();
            



            do
            {
                
                MostrarMenu();
                

                string opcion = Console.ReadLine().ToUpper();
                switch (opcion)
                {
                    case "1":
                        AnyadirDepartamento(nuevaEmpresa);
                        break;
                    case "2":
                        EliminarDepartamento(nuevaEmpresa);
                        break;
                    case "3":
                        AnyadirEmpleado(empleados, nuevaEmpresa);
                        break;
                    case "4":
                        Mostrar(empleados);
                        break;
                    case "5":
                        Buscar(empleados);
                        break;
                    case "6":
                        Modificar(empleados);
                        break;
                    case "7":
                        Eliminar(empleados);
                        break;
                    case "8":
                        Ordenar(empleados);
                        break;
                    case "9":
                        MostrarNomina(empleados);
                        break;
                    case "0":
                        salir = true;
                        break;
                }

            } while (!salir);
            
            Guardar(empleados); 
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("Hasta la próxima!!!!!!!", 40, 16);
            Console.ResetColor();

        }

        public void Guardar(List<Empleado> empleados)
        {
            try
            {
                StreamWriter fichero = new StreamWriter("empleados.txt");
               
                fichero.WriteLine(empleados.Count);//cantidad de datos que hay en la lista
                for (int i = 0; i < empleados.Count; i++)
                {
                    fichero.WriteLine(empleados[i].GetType().Name);
                    fichero.WriteLine(empleados[i].Dni);
                    fichero.WriteLine(empleados[i].Nombre);
                    fichero.WriteLine(empleados[i].Edad);
                    fichero.WriteLine(empleados[i].Estado);
                    fichero.WriteLine(empleados[i].Sueldo);
                    fichero.WriteLine(empleados[i].Categoria);
                    fichero.WriteLine(empleados[i].UnDepartamento);

                    if (empleados[i] is Comercial)
                    {
                        fichero.WriteLine(((Comercial)empleados[i]).Ventas);
                    }
                    else if (empleados[i] is JefeDepartamento)
                    {
                        fichero.WriteLine(((JefeDepartamento)empleados[i]).Antiguedad);
                    }
                    else
                    {
                        fichero.WriteLine(0);
                    }
                    fichero.WriteLine();
                }
                fichero.Close();
            }
            /*catch (IOException)
            {
                Console.WriteLine("Error de escritura");
            }*/
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public List<Empleado> Cargar()
        {
            List<Empleado> empleados = new List<Empleado>();
            Departamento d;

            if (!File.Exists("empleados.txt"))
            {
                return empleados;
            }
            try
            {
                StreamReader fichero = new StreamReader("empleados.txt");
                int cantidad = Convert.ToInt32(fichero.ReadLine());
                /*Console.WriteLine(cantidad);
                string tipo = fichero.ReadLine();
                Console.WriteLine(tipo);
                string dni = fichero.ReadLine();
                Console.WriteLine(dni);
                string nombre = fichero.ReadLine();
                Console.WriteLine(nombre);
                int edad = Convert.ToInt32(fichero.ReadLine());
                Console.WriteLine(edad);
                string estado = fichero.ReadLine();
                Console.WriteLine(estado);
                float sueldo = Convert.ToSingle(fichero.ReadLine());
                Console.WriteLine(sueldo);
                string categoria = fichero.ReadLine();
                Console.WriteLine(categoria);
                string linea = fichero.ReadLine();
                Console.WriteLine(linea);
                string[] departamento = linea.Split(",");
                string idDepartamento = departamento[0];
                Console.WriteLine(idDepartamento);
                string nombreDepartamento = departamento[1];
                Console.WriteLine(nombreDepartamento);
                int auxiliar = Convert.ToInt32(fichero.ReadLine());
                Console.WriteLine(auxiliar);*/
                

                for (int i = 0; i < cantidad; i++)
                {
                    string tipo = fichero.ReadLine();
                    string dni = fichero.ReadLine();
                    string nombre = fichero.ReadLine();
                    int edad = Convert.ToInt32(fichero.ReadLine());
                    string estado = fichero.ReadLine();
                    float sueldo = Convert.ToSingle(fichero.ReadLine());
                    string categoria = fichero.ReadLine();
                    string linea = fichero.ReadLine();
                    string[] departamento = linea.Split(",");
                    string idDepartamento = departamento[0];
                    string nombreDepartamento = departamento[1];
                    d = new Departamento(idDepartamento, nombreDepartamento);
                    int auxiliar = Convert.ToInt32(fichero.ReadLine());
                    string separador = fichero.ReadLine();

                if (auxiliar >= 50)
                {
                    empleados.Add(new Comercial(dni, nombre, edad, estado,sueldo, categoria, d, auxiliar));
                }
                else if (auxiliar < 50 && auxiliar > 0)
                {
                    empleados.Add(new JefeDepartamento(dni, nombre, edad, estado, sueldo, categoria, d, auxiliar));
                }

                else
                {
                    empleados.Add(new Empleado(dni, nombre, edad, estado, sueldo, categoria, d));
                }

            }
                fichero.Close();
            }
            catch (IOException x)
            {
                Console.WriteLine("Error DOS");
                Console.WriteLine("Error UNO " + x.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error UNO " + e.Message);
            }


            return empleados;
        }

        private void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteAt("*******************", 40, 0);
            WriteAt("Gestor empleado", 42, 1);
            WriteAt("*******************", 40, 2);
            WriteAt("1.Añadir nuevo departamento", 40, 3);
            WriteAt("2.Eliminar un departamento", 40, 4);
            WriteAt("3.Anyadir nuevo empleado", 40, 5);
            WriteAt("4.Mostra datos de empleados", 40, 6);
            WriteAt("5.Buscar empleado", 40, 7);
            WriteAt("6.Modificar empleado", 40, 8);
            WriteAt("7.Eliminar empleado", 40, 9);
            WriteAt("8.Ordenar empleados", 40, 10);
            WriteAt("9.Mostrar Nómina de empleado", 40, 11);
            WriteAt("0.Salir", 40, 12);
            Console.WriteLine();
            Console.ResetColor();
            WriteAt("Introduzca una opción del 0 al 9: ", 40, 14);
            Console.ResetColor();
            
         

        }
        //añade un nuevo departemnto a la empresa
        private void AnyadirDepartamento(Empresa nuevaEmpresa)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    AÑADIR DEPARTAMENTO");
            
      
            string id;
            string nombre;
            Departamento d;
            try
            {
                do
                {
                    id = PedirCadenaNoVacia("ID (introduzca la letra D más un dígito" +
                    "separados por un guión, ejemplo 'D-7'): ").ToLower();
                    if (CodigoDepartamento(id))
                    {
                        nombre = PedirCadenaNoVacia("nombre departamento: ").ToLower();
                        d = new Departamento(id, nombre);
                        if (nuevaEmpresa.NuevoDepartamento(d))
                        {
                            Console.WriteLine("    El departamento se ha añadido correctamente a la empresa");

                        }
                        else
                        {
                            Console.WriteLine("    No se pueden añadir más departamentos a la empresa");
                        }
                    }
                } while (!CodigoDepartamento(id));
            }
            catch (Exception e)
            {

                Console.WriteLine("    ERROR: {0} \n    El código de departemento no es correcto ", 
                    e.Message);
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();

        }

        //elimina un departemento de la empresa
        private void EliminarDepartamento(Empresa nuevaEmpresa)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    ELIMINAR DEPARTAMENTO");
            Console.WriteLine("    Introduzca los datos del departamente que quiere eliminar.");
            Console.WriteLine();
            nuevaEmpresa.MostrarDepartamentos();
            string id;
            string nombre;
            Departamento d;
            try
            {
                do
                {
                    id = PedirCadenaNoVacia("ID (introduzca la letra D más un dígito" +
                    "separados por un guión, ejemplo 'D-7'): ").ToLower();
                    if (CodigoDepartamento(id))
                    {
                        nombre = PedirCadenaNoVacia("nombre departamento: ").ToLower();
                        d = new Departamento(id, nombre);
                        if (nuevaEmpresa.QuitarDepartamento(d))
                        {
                            Console.WriteLine("    El departamento se ha eliminado correctamente");
                            nuevaEmpresa.MostrarDepartamentos();

                        }
                        else
                        {
                            Console.WriteLine("    El departamento no se ha eliminado correctamente");
                        }
                    }
                } while (!CodigoDepartamento(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("    ERROR: {0} \n    El código de departemento no es correcto ",
                     e.Message);
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
        }

        private void AnyadirEmpleado(List<Empleado> empleados, Empresa nuevaEmpresa)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    AÑADIR EMPLEADO");
            Empleado aux;//para crear un empleado
            Departamento d;//para asociar al departemento
            bool dniOK;

            string tipoEmpleado = PedirDato(" el tipo de empleado (e) Empleado, " +
                "(c) Comercial, (j) Jefe de Departamento: ").ToLower();
            string dni;
            do
            {
                dniOK = true;
                dni = PedirCadenaNoVacia("DNI: ");
                for (int i = 0; i < empleados.Count; i++)
                {
                    if (ExisteDNI(empleados, dni))
                {
                        Console.WriteLine("Error. DNI repetido. Prueba de nuevo.");
                        dniOK = false;
                    }
                }
                
            } while (!dniOK);

            //string dni = PedirCadenaNoVacia("DNI: ");
            string nombre = PedirCadenaNoVacia("nombre: ");
            int edad = PedirEntero("edad:", 18, 99);
            string estado = PedirCadenaNoVacia("estado: ");
            float sueldo = PedirFLoat("sueldo: ", 12000, 30000);
            string categoria = PedirCadenaNoVacia("categoría: ");
            Console.WriteLine();
            //muestra los datos del departamento para incluirlos en el empleado
            Console.WriteLine("    Estos son los departamentos de la empresa:");
            Console.WriteLine();
            nuevaEmpresa.MostrarDepartamentos();
            Console.WriteLine();
            int registro = PedirEntero("posición del departamento del nuevo empleado: ", 1, 5) - 1;
            string id;
            string nombreDepartamento;
            
            switch (registro)
            {
                case 0:
                    id = "D1";
                    nombreDepartamento = "Contabilidad";
                    d = new Departamento(id, nombreDepartamento);
                    if (tipoEmpleado == "e")
                    {
                        aux = new Empleado(dni, nombre, edad, estado,
                        sueldo, categoria, d);
                        empleados.Add(aux);
                    }
                    else if (tipoEmpleado == "c")
                    {
                        int ventas = PedirEntero("ventas", 0, 100);
                        aux = new Comercial(dni, nombre, edad, estado,
                           sueldo, categoria, d, ventas);
                        empleados.Add(aux);
                    }
                    else
                    {
                        int antiguedad = PedirEntero("antigüedad", 0, 100);
                        aux = new JefeDepartamento(dni, nombre, edad, estado,
                            sueldo, categoria, d, antiguedad);
                        empleados.Add(aux);
                    }
                    break;
                case 1:
                    id = "D2";
                    nombreDepartamento = "Ventas";
                    d = new Departamento(id, nombreDepartamento);
                    if (tipoEmpleado == "e")
                    {
                        aux = new Empleado(dni, nombre, edad, estado,
                        sueldo, categoria, d);
                        empleados.Add(aux);
                    }
                    else if (tipoEmpleado == "c")
                    {
                        int ventas = PedirEntero("ventas", 0, 100);
                        aux = new Comercial(dni, nombre, edad, estado,
                           sueldo, categoria, d, ventas);
                        empleados.Add(aux);
                    }
                    else
                    {
                        int antiguedad = PedirEntero("antigüedad", 0, 100);
                        aux = new JefeDepartamento(dni, nombre, edad, estado,
                            sueldo, categoria, d, antiguedad);
                        empleados.Add(aux);
                    }
                    break;
                case 2:
                    id = "D3";
                    nombreDepartamento = "Alquileres";
                    d = new Departamento(id, nombreDepartamento);
                    if (tipoEmpleado == "e")
                    {
                        aux = new Empleado(dni, nombre, edad, estado,
                        sueldo, categoria, d);
                        empleados.Add(aux);
                    }
                    else if (tipoEmpleado == "c")
                    {
                        int ventas = PedirEntero("ventas", 0, 100);
                        aux = new Comercial(dni, nombre, edad, estado,
                           sueldo, categoria, d, ventas);
                        empleados.Add(aux);
                    }
                    else
                    {
                        int antiguedad = PedirEntero("antigüedad", 0, 100);
                        aux = new JefeDepartamento(dni, nombre, edad, estado,
                            sueldo, categoria, d, antiguedad);
                        empleados.Add(aux);
                    }
                    break;
                case 3:
                    id = "D4";
                    nombreDepartamento = "Marketing";
                    d = new Departamento(id, nombreDepartamento);
                    if (tipoEmpleado == "e")
                    {
                        aux = new Empleado(dni, nombre, edad, estado,
                        sueldo, categoria, d);
                        empleados.Add(aux);
                    }
                    else if (tipoEmpleado == "c")
                    {
                        int ventas = PedirEntero("ventas", 0, 100);
                        aux = new Comercial(dni, nombre, edad, estado,
                           sueldo, categoria, d, ventas);
                        empleados.Add(aux);
                    }
                    else
                    {
                        int antiguedad = PedirEntero("antigüedad", 0, 100);
                        aux = new JefeDepartamento(dni, nombre, edad, estado,
                            sueldo, categoria, d, antiguedad);
                        empleados.Add(aux);
                    }
                    break;
                case 4:
                    id = "D5";
                    nombreDepartamento = "Administracion";
                    d = new Departamento(id, nombreDepartamento);
                    if (tipoEmpleado == "e")
                    {
                        aux = new Empleado(dni, nombre, edad, estado,
                        sueldo, categoria, d);
                        empleados.Add(aux);
                    }
                    else if (tipoEmpleado == "c")
                    {
                        int ventas = PedirEntero("ventas", 0, 100);
                        aux = new Comercial(dni, nombre, edad, estado,
                           sueldo, categoria, d, ventas);
                        empleados.Add(aux);
                    }
                    else
                    {
                        int antiguedad = PedirEntero("antigüedad", 0, 100);
                        aux = new JefeDepartamento(dni, nombre, edad, estado,
                            sueldo, categoria, d, antiguedad);
                        empleados.Add(aux);
                    }
                    break;
            }

            Guardar(empleados);

            Console.Write("    Empleado añadido, pulse enter para continuar: ");
            Console.ReadLine();
            
        }

        private void Mostrar(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    MOSTRAR DATOS DE EMPLEADO:");
            Console.WriteLine();
            Console.WriteLine();

            if (empleados.Count > 0)
            {
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.WriteLine("    " + (i + 1) + "." + empleados[i]);
                    if (i % 24 == 23)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("    Pulsa intro para continuar");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                AvisarListaVacia();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
        }

        private void Buscar(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    BUSCAR EMPLEADO");
            if (empleados.Count > 0)
            {
                bool encontrado = false;
                string textoBuscar = PedirCadenaNoVacia("texto de busqueda").ToLower();

                for (int i = 0; i < empleados.Count; i++)
                {
                    if (empleados[i].Contiene(textoBuscar))
                    {
                        Console.WriteLine((i + 1) + "." + empleados[i]);
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("    No se ha encontrado coincidencia");
                }
            }
            else
            {
                AvisarListaVacia();
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
        }

        private void Modificar(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    MODIFICAR EMPLEADO");
            Buscar(empleados);

            if (empleados.Count > 0)
            {
                int tamanyo = empleados.Count;
                int registro = PedirEntero("registro a modificar", 1, tamanyo) - 1;
                if (registro >= 0 && registro < empleados.Count)
                {
                    Console.WriteLine("    DNI" + empleados[registro].Dni);
                    string dni = PedirDato("dni o intro para continuar");
                    if (dni != " ")
                    {
                        empleados[registro].Dni = dni;
                    }
                    Console.WriteLine("    Nombre" + empleados[registro].Nombre);
                    string nombre = PedirDato("nombre o intro para continuar");
                    if (nombre != " ")
                    {
                        empleados[registro].Nombre = nombre;
                    }
                    Console.WriteLine("    Edad" + empleados[registro].Edad);
                    int edad = PedirEntero("año o intro para continuar", 18, 99);
                    if (edad < 100 && edad > 17)
                    {
                        empleados[registro].Edad = Convert.ToInt32(edad);
                    }
                    Console.WriteLine("    Estado" + empleados[registro].Estado);
                    string estado = PedirDato("estado o intro para continuar");
                    if (estado != " ")
                    {
                        empleados[registro].Estado = estado;
                    }
                    Console.WriteLine("    Departamento" + empleados[registro].UnDepartamento);
                    string id = PedirDato("id del Departamento o intro para continuar");
                    if (id != " ")
                    {
                        empleados[registro].UnDepartamento.Id = id;
                    }
                    string nombreDepartamento = PedirDato("nombre del Departamento o intro para continuar");
                    if (nombreDepartamento != " ")
                    {
                        empleados[registro].UnDepartamento.Nombre = nombreDepartamento;
                    }
                    //lenguajes[registro] is Imperativo
                    if (empleados[registro].GetType() == typeof(Comercial))
                    {
                        Console.WriteLine("    Ventas" + ((Comercial)empleados[registro]).Ventas);
                        string ventas = PedirDato("ventas o intro para continuar");
                        if (ventas != " ")
                        {
                            ((Comercial)empleados[registro]).Ventas = Convert.ToInt32(ventas);
                        }
                    }
                    if (empleados[registro] is JefeDepartamento)
                    {
                        Console.WriteLine("    Antigüedad" + ((JefeDepartamento)empleados[registro]).Antiguedad);
                        string antiguedad = PedirDato("antigüedad o intro para continuar");
                        if (antiguedad != "")
                        {
                            ((JefeDepartamento)empleados[registro]).Antiguedad = Convert.ToInt32(antiguedad);
                        }
                    }
                }
                else
                {
                    AvisarRegistroIncorrecto();
                }
            }
            else
            {
                AvisarListaVacia();
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
            //Guardar(empleados);
        }

        private void Eliminar(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    ELIMINAR EMPLEADO");
            Buscar(empleados);

            if (empleados.Count > 0)
            {
                int tamanyo = empleados.Count;
                int registro = PedirEntero("registro a modificar", 1, tamanyo) - 1;
                if (registro >= 0 && registro < empleados.Count)
                {
                    Console.WriteLine(empleados[registro]);
                    string confirmacion = PedirDato("(s) para confirmar, " +
                        "intro para cancelar").ToLower();
                    if (confirmacion == "s")
                    {
                        empleados.RemoveAt(registro);
                        
                        Console.WriteLine("    Registro eliminado");
                    }
                    else
                    {
                        Console.WriteLine("    Borrado cancelado");
                    }
                }
                else
                {
                    AvisarRegistroIncorrecto();
                }
            }
            else
            {
                AvisarListaVacia();
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
            //Guardar(empleados);
        }

        private void Ordenar(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    ORDENAR EMPLEADOS");
            if (empleados.Count > 0)
            {
                empleados.Sort();
                Console.WriteLine("    Lista ordenada");
            }
            else
            {
                AvisarListaVacia();
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
        }

        private void MostrarNomina(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    MOSTRAR NÓMINA DE EMPLEADO");
            DateTime hoy = DateTime.Now;
            DateTime mesAnterior = hoy.AddMonths(-1);
            if (empleados.Count > 0)
            {
                float totalNomina;
                bool encontrado = false;
                string textoBuscar = PedirCadenaNoVacia("texto de busqueda").ToLower();

                for (int i = 0; i < empleados.Count; i++)
                {
                    if (empleados[i].Contiene(textoBuscar))
                    {
                        totalNomina = empleados[i].CalcularNomina();
                        Console.WriteLine("    Nomina de mes de {0}", mesAnterior.ToString("Y"));
                        Console.WriteLine("    Fecha: {0}", hoy.ToString("d"));
                        Console.WriteLine("    Empleado: {0}", empleados[i].Nombre);
                        Console.WriteLine("    Total nómina: {0}", totalNomina.ToString("N2"));
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("    No se ha encontrado coincidencia");
                }
            }
            else
            {
                AvisarListaVacia();
            }
            Console.Write("    Pulse enter para continuar");
            Console.ReadLine();
        }

        private string PedirDato(string mensaje)
        {
            Console.Write("    Introduce " + mensaje);
            return Console.ReadLine();

        }

        private void AvisarListaVacia()
        {
            Console.WriteLine("    No hay datos almacenados");
        }

        private void AvisarOpcionIncorrecta()
        {
            Console.WriteLine("    Opción incorrecta");
        }

        private void AvisarRegistroIncorrecto()
        {
            Console.WriteLine("    Número de reguistro incorrecto");
        }

        private int PedirEntero(string mensaje, int minimo, int maximo)
        {
            int resultado;

            do
            {
                Console.Write("    Introduce " + mensaje);
            } while (!Int32.TryParse(Console.ReadLine(), out resultado) ||
                    resultado < minimo || resultado > maximo);

            return resultado;
        }

        private float PedirFLoat(string mensaje, float minimo, float maximo)
        {
            Single resultado;

            do
            {
                Console.Write("    Introduce " + mensaje);
            } while (!Single.TryParse(Console.ReadLine(), out resultado) ||
                    resultado < minimo || resultado > maximo);

            return resultado;
        }

        private string PedirCadenaNoVacia(string mensaje)
        {
            bool error;
            string texto;

            do
            {
                error = false;
                Console.Write("    Introduce " + mensaje);
                texto = Console.ReadLine();
                if (String.IsNullOrEmpty(texto))
                {
                    error = true;
                    Console.WriteLine("    ERROR: No se puede dejar vacio el dato solicitado");
                }
            } while (error);

            return texto;
        }

        public void WriteAt(string s, int x, int y)
        {
            int origCol = 0;
            int origRow = 5;
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private bool ExisteDNI(List<Empleado> empleados, string buscaDNI)
        {
            bool repetido = false;
            

            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].Contiene(buscaDNI))
                {
                    repetido = true;
                }
            }
            
            return repetido;
        }

        public bool CodigoDepartamento(string codigo)
        {
            bool codigo_OK = false;
            string[] caracteresCodigo = codigo.Split("-");
            int digito = Int32.Parse(caracteresCodigo[1]);
            
            if (caracteresCodigo[0] == "d" 
                && digito < 10 && digito > 0)
            {
                codigo_OK = true;
            }
            return codigo_OK;
            
        }






    }
}

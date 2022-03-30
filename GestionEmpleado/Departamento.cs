using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class Departamento
    {
        private string id;
        private string nombre;
        private Empresa unaEmpresa;//asociacion empresa en la que está el departamento
        //private List<Empleado> empleados; //asociacion, almacena los empleados del departamento

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
       
        public Empresa UnaEmpresa { get => unaEmpresa; set => unaEmpresa = value; }

        public Departamento(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            //empleados = new List<Empleado>();//lista vacia para añadir los empleados del departamento
            //unaEmpresa.NuevoDepartamento(this);//añadimos el departamento a la empresa
        }

        //alta de un empleado en el departamento
        /*public void altaEmpleado(Empleado emp)
        {
            if (!empleados.Contains(emp))
            {
                empleados.Add(emp);
                emp.UnDepartamento = this;//el empleado refleja el alta
            }
        }

        //baja empleado del departamento
        public void bajaEmpleado(Empleado emp)
        {
            if (empleados.Contains(emp))
            {
                empleados.Remove(emp);
                emp.UnDepartamento = null;//el empleado refleja la baja
            }
        }*/

        public override string ToString()
        {
            string resultado = id + "," + nombre + ",";
            /*for (int i = 0; i < empleados.Count; i++)
            {
                resultado += empleados[i].Nombre;
            }*/
            
                return resultado;
        }
    }

    
}

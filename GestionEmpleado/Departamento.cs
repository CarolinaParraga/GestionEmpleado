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
     
        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
       
        public Empresa UnaEmpresa { get => unaEmpresa; set => unaEmpresa = value; }

        public Departamento(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            string resultado = id + "," + nombre;
            
                return resultado;
        }
    }

    
}

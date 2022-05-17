using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    //clase que almacena los datos de los departamentos de la empresa
    class Departamento
    {
        private string id;
        private string nombre;
        private Empresa unaEmpresa;
     
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    class Contrato
    {
        private DateTime fecha;
        private Empleado empleado; //asociacion
        private Empresa empresa;//asociacion

        public Contrato(Empresa empresa, Empleado empleado)
        {
            this.empleado = empleado;
            this.empresa = empresa;
            this.fecha = DateTime.Now;//string Date = DateTime.Now.ToString("dd-MM-yyyy");
        }

        public override string ToString()
        {
            return "Contrato: " + fecha + "," + empleado + "," + empresa;
        }
    }
}

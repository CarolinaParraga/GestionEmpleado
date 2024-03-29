﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleado
{
    //almacena datos de empleado jefe de departamento
    class JefeDepartamento: Empleado
    {
        private int antiguedad;
        private int plus;

        public int Antiguedad
        {
            get 
            {
                return antiguedad; 
            }
            set 
            {
                if (value < 50 && value >= 0)
                {
                    antiguedad = value;
                }
            }
        }
        public int Plus { get => plus; set => plus = value; }
        
        public JefeDepartamento(string dni, string nombre, int edad,
            string estado, float sueldo, string categoria, Departamento unDepartemento, int antiguedad)
            : base(dni, nombre, edad, estado, sueldo, categoria, unDepartemento)
        {
            this.antiguedad = antiguedad;
            this.plus = 100;
        }

        //método para calcular el plus de jefe de departamento
        public int CalcularPlus(int antiguedad)
        {
            int plus = 100;
            if (antiguedad > 5 && antiguedad <= 10)
            {
                plus = 150;
            }
            else if (antiguedad > 10)
            {
                plus = 200;
            }

            return plus;
        }

        //redefine método para calcular nómina
        public override float CalcularNomina( int dato)
        {
            float resultado;
            float impuestos;
            float sueldoTotal = Sueldo + dato;


            if (sueldoTotal >= 20000)
            {
                impuestos = sueldoTotal * 0.25f;
            }
            else if (sueldoTotal >= 15000)
            {

                impuestos = sueldoTotal * 0.20f;
            }
            else if (sueldoTotal >= 10000)
            {
                impuestos = sueldoTotal * 0.10f;
            }
            else
            {
                impuestos = 0;
            }

            resultado = (sueldoTotal + impuestos)/14;

            return resultado;
        }

        public override string ToString()
        {
            return base.ToString() + Antiguedad + "\n";
        }
    }
}

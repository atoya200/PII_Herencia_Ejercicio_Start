using System.Collections.Generic;
using System;
namespace UCURide
{
    public class Vehiculo
    {
        public string Marca { get; }
        public string Modelo { get; }
        public string Matricula { get; }
        public int CapacidadPasajeros { get; }


        private Vehiculo(string marca, string modelo, string matricula, int cap)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Matricula = matricula;
            this.CapacidadPasajeros = cap;
        }

        public static Vehiculo CrearVehiculo(string marca, string modelo, string matricula, int cap)
        {
            if (Validacion.ValidarMarca(marca) && Validacion.ValidarModelo(modelo) && Validacion.ValidarMatricula(matricula) && cap >= 2)
            {
                return new Vehiculo(marca, modelo, matricula, cap);
            }
            else
            {
                return null;
            }
        }

    }
}
using System;
using CognitiveCoreUCU;

namespace UCURide
{
    public abstract class Conductor : Usuario
    {

        public string Bio { get; set; }
        public Vehiculo Vehiculo { get; }


        protected Conductor(string nombre, string apellido, string cedula, string pass, string pathFoto, string bio, Vehiculo vehiculo, string presentacion) : base(nombre, apellido, cedula, pass, pathFoto, presentacion)
        {
            this.Vehiculo = vehiculo;
            this.Bio = bio;
        }

        public abstract void SubirPasajero(Pasajero pasajero);
        public abstract void BajarPasajero(Pasajero pasajero);
        public abstract void MostrarOcupantes();

        

        
    }
}
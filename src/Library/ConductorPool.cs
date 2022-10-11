using System.Collections.Generic;
using System.Text;
using System;
namespace UCURide
{
     public class ConductorPool : Conductor
    {

        public int Capacidad {get; private set;}

        public List<Pasajero> PasajerosABordo {get; }

       
         public static ConductorPool RegistrarConductor(string nombre, string apellido, string cedula, string pass, string pathFoto, string bio, Vehiculo transporte)
        {
            string presentacion = $"Bienvenido {nombre} {apellido}, es un gusto contar contigo\n \"{bio}\"";
            if (Validacion.ValidarNombre(nombre) && Validacion.ValidarApellido(apellido) && Validacion.ValidarCI(cedula) && Validacion.ValidarPassword(pass) && Validacion.ValidarFotoConductor(pathFoto) && Validacion.ValidarBio(bio))
            {
                return new ConductorPool(nombre, apellido, cedula, pass, pathFoto, bio, transporte, presentacion);
            }
            else
            {
                return null;
            }

        }

        private ConductorPool(string nombre, string apellido, string cedula, string pass, string pathFoto, string bio, Vehiculo vehiculo, string presentacion) : base(nombre, apellido, cedula, pass, pathFoto, bio, vehiculo, presentacion)
        {
            this.PasajerosABordo = new List<Pasajero>();
            this.Capacidad = vehiculo.CapacidadPasajeros;
            Console.WriteLine("Estoy listo para trabajar y llevar a varias personas a la vez");

        }
         public override void SubirPasajero(Pasajero pasajero)
         {
            if(Capacidad > PasajerosABordo.Count)
                this.PasajerosABordo.Add(pasajero);
            else
                Console.WriteLine("No se pueden subir más personas, voy lleno");
         }
         
        public override void BajarPasajero(Pasajero pasajero)
        {
           this.PasajerosABordo.Remove(pasajero);
           if(PasajerosABordo.Count == 0)
                Console.WriteLine("Estoy totalmente libre");
        }
        public override void MostrarOcupantes()
        {
            StringBuilder texto = new StringBuilder();
            foreach(Pasajero pasajero in this.PasajerosABordo)
            {
                texto.Append($"\nPasajero {pasajero.Nombre} {pasajero.Apellido} esta a bordo");
            }
            Console.WriteLine(texto.ToString());
        }


        
    }
}
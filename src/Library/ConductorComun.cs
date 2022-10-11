using System;
namespace UCURide
{
     public class ConductorComun : Conductor
    {

        public Pasajero PasajeroABordo {get; private set;}

        

        public static  ConductorComun RegistrarConductor(string nombre, string apellido, string cedula, string pass, string pathFoto, string bio, Vehiculo transporte)
        {
            string presentacion = $"Bienvenido {nombre} {apellido}, es un gusto contar contigo\n \"{bio}\"";
            if (Validacion.ValidarNombre(nombre) && Validacion.ValidarApellido(apellido) && Validacion.ValidarCI(cedula) && Validacion.ValidarPassword(pass) && Validacion.ValidarFotoConductor(pathFoto) && Validacion.ValidarBio(bio))
            {
                return new ConductorComun(nombre, apellido, cedula, pass, pathFoto, bio, transporte, presentacion);
            }
            else
            {
                return null;
            }

        }

        private ConductorComun(string nombre, string apellido, string cedula, string pass, string pathFoto, string bio, Vehiculo vehiculo, string presentacion) : base(nombre, apellido, cedula, pass, pathFoto, bio, vehiculo, presentacion)
        {
            Console.WriteLine("Estoy listo para trabajar, pero solo llevo de a una persona");
        }
         public override void SubirPasajero(Pasajero pasajero)
         {
            if(PasajeroABordo == null)
                this.PasajeroABordo = pasajero;
            else
                Console.WriteLine("No se puede subir alguien más estando ya una persona en el auto. Llevo a de una persona, no soy chofer pool");
         }
        public override void BajarPasajero(Pasajero pasajero)
        {
            if(this.PasajeroABordo == pasajero)
            this.PasajeroABordo = null;
            else
            Console.WriteLine("No hay pasajero a bordo para bajar");
        }
        public override void MostrarOcupantes()
        {
            Console.WriteLine($"Pasajero {this.PasajeroABordo.Nombre} {this.PasajeroABordo.Apellido} esta a bordo");
        }

        
    }
}
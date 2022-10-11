using System;

namespace UCURide
{
    public class Pasajero : Usuario
    {

        private Pasajero(string nombre, string apellido, string cedula, string pass, string pathFoto, string presentacion) :base(nombre, apellido, cedula, pass, pathFoto, presentacion)
        {
            Console.WriteLine("Estoy listo para ir de un lugar a otro de la mano de un conductor voluntario");
        }
       public static Pasajero RegistrarPasajero(string nombre, string apellido, string cedula, string pass, string pathFoto)
        {
            string presentacion = $"{nombre} {apellido}\n";
            if (Validacion.ValidarNombre(nombre) && Validacion.ValidarApellido(apellido) && Validacion.ValidarCI(cedula) && Validacion.ValidarPassword(pass) && Validacion.ValidarFotoPasajero(pathFoto))
            {
                return new Pasajero(nombre, apellido, cedula, pass, pathFoto, presentacion);
            }
            else
            {
                return null;
            }

        }

    }
}
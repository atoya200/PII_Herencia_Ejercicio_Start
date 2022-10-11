using System;
using System.Collections;
using UCURide;

namespace PII_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Usuario pasajero1 =  Pasajero.RegistrarPasajero("Jose", "Perez", "3.418.689-8","Holamundo2?", @"..\..\imagenes\HombreSerio.jpg");
           // Este tiene la foto incorrecta, por lo cual pasajero 2 va a contener un null y no se va a cargar en a lista. Esto lo podemos ver en que no se hace una publicación en su nombre
            Usuario pasajero2 =  Pasajero.RegistrarPasajero("Tomas", "Lopez", "1.977.285-6", "Holamundo2?", @"..\..\imagenes\Leopardo.jpg");
            Usuario pasajero3 =  Pasajero.RegistrarPasajero("Jesica", "Amidal", "4.284.009-6", "Holamundo2?", @"..\..\imagenes\MujerSeria.jpg");
            Vehiculo swift = Vehiculo.CrearVehiculo("Suzuki", "Swift", "AAA 1234", 5);
            Vehiculo alto = Vehiculo.CrearVehiculo("Suzuki", "Alto", "ASA 2234", 5);
            Usuario conductorComun =  ConductorComun.RegistrarConductor("Marcos", "Toledo", "5.647.220-7","ChauMundo32¿",@"..\..\imagenes\HombreSonriente.jpg","Tengo mi licencia de conducir desde los 20 años, soy bueno en esto", swift);
            Usuario conductorPool1 =  ConductorPool.RegistrarConductor("Camila", "Ruffus", "4.695.076-6","ChauMundo32¿", @"..\..\imagenes\MujerSonriente.jpg","Soy profesora de Psicología, espero el viaje sea entretenido", alto);
            UCURideShare rideShare =  UCURideShare.Instancia;
            rideShare.AgregarUsuario(pasajero1);
            rideShare.AgregarUsuario(pasajero2);
            rideShare.AgregarUsuario(pasajero3);
            rideShare.AgregarUsuario(conductorComun);
            rideShare.AgregarUsuario(conductorPool1);

        
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
namespace UCURide
{
    public class UCURideShare_viejo
    {
        private List<Pasajero> Pasajeros {get;}
        private List<Conductor> Conductores {get;}

        public void AgregarPasajero(Pasajero pasajero)
        {
            this.Pasajeros.Add(pasajero);
        }

        public void QuitarPasajero(Pasajero pasajero)
        {
             this.Pasajeros.Remove(pasajero);
        }
        public void AgregarConductor(Conductor conductor)
        {
            this.Conductores.Add(conductor);
        }
        public void QuitarConductor(Conductor conductor)
        {
            this.Conductores.Remove(conductor);
        }

      /*   public string MostrarUsuarios()
        {
            foreach( Usuario us in )
        }

        public string MostrarConductores()
        {
            StringBuilder choferes  = new StringBuilder();
            foreach(Conductor con in Conductores)
            {
                choferes
            }
        }
 */

    }
}
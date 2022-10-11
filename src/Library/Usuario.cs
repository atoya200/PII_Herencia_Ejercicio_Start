using System.Collections.Generic;
using System.Collections;
using CognitiveCoreUCU;
using TwitterUCU;
using System;
 
namespace UCURide
{
    public class Usuario
    {
        public string Nombre { get; }
        public string Apellido { get; }
        protected string Cedula { get; }
        protected string Pass { get; }
        public string PathFoto { get; }
        protected List<int> Calificaciones { get; }
        
        // Para armar el texto que tiene que poner en la publicación de Twiter.
        protected string Presentacion {get;}

        protected int calificacion;
        public int Calificacion
        {
            get
            {
                return this.calificacion;
            }
            set
            {
                // Revisar mañana temprano
                int total = 0;
                foreach (int val in Calificaciones)
                {
                    total += val;
                }
                this.calificacion = total / 5;
            }
        }

      

        protected Usuario(string nombre, string apellido, string cedula, string pass, string pathFoto, string presentacion)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Cedula = cedula;
            this.Pass = pass;
            this.PathFoto = pathFoto;
            this.Presentacion = presentacion;
            Calificaciones = new List<int>{0};

        }
        public void PublicarRegistro()
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(this.Presentacion, $"{this.PathFoto}"));
        }

          public void CalificarUsuario(Usuario usuario, int puntuacion)
        {
          
            switch (Validacion.ValidarCalificacion(puntuacion))
            {
                case 1:
                    usuario.Calificaciones.Add(puntuacion);
                    break;
                case 0:
                    usuario.Calificaciones.Add(5);
                    break;
                case -1:
                    usuario.Calificaciones.Add(0);
                    break;
            }
        }


    }  
}
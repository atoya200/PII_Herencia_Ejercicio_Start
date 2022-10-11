using System;
using System.Text;
using System.Collections.Generic;
namespace UCURide
{
    public class UCURideShare
    {
        private List<Usuario> Usuarios { get; }

        private static UCURideShare instancia;

        public static UCURideShare Instancia 
        {get{
           if(instancia == null)
            {
                instancia = new UCURideShare();
            }
            return instancia;
        }
        }
       

        private UCURideShare()
        {
            this.Usuarios = new List<Usuario>();
        }

        public void AgregarUsuario(Usuario user)
        {
            if (user != null && !(Usuarios.Contains(user)))
            {
                this.Usuarios.Add(user);
                user.PublicarRegistro();
            }
        }

        public void QuitarUsuario(Usuario user)
        {
            this.Usuarios.Remove(user);
        }


        public void MostrarUsuarios()
        {
            StringBuilder infoUsuarios = new StringBuilder();
            foreach (Usuario us in this.Usuarios)
            {
                infoUsuarios.Append($"\n{us.Nombre} {us.Apellido}, su califación es {us.Calificacion}");
            }
            Console.WriteLine(infoUsuarios.ToString());
        }




    }
}
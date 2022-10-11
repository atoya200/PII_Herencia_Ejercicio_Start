using System.Collections.Generic;
using System.Collections;
using CognitiveCoreUCU;
using System;
namespace  UCURide
{
    public class Validacion
    {
        
        public static bool ValidarNombre(string nombre)
        {
            if (nombre == null || nombre.Length == 0 || FormatoIncorrecto(nombre))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidarApellido(string apellido)
        {
            if (apellido == null || apellido.Length == 0 || FormatoIncorrecto(apellido))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidarCI(string ced)
        {
            long tempOut;
            string id = ced;
            // Quitar puntos y guiones
            id = id.Replace(".", "");
            id = id.Replace("-", "");

            // Validar largo
            if (id.Length == 8 && long.TryParse(id, out tempOut))
            {
                //var idAsCharArray = id.ToArray();
                ArrayList idAsCharArray = new ArrayList();
                List<int> idAsIntArray = new List<int>();
                List<int> referenceArray = new List<int>{2,9,8,7,6,3,4};
                foreach(char c in id)
                {
                    idAsCharArray.Add(c);
                    idAsIntArray.Add(int.Parse(c.ToString()));
                }
                //var idAsIntArray = idAsCharArray.Select(c => int.Parse(c.ToString())).ToArray();
                var inputCheckDigit = idAsIntArray[7];

                // Calcular número verificador
                int checkSum = 0;
                for (int i = 0; i < referenceArray.Count; i++)
                {
                    checkSum = checkSum + (idAsIntArray[i] * referenceArray[i]);
                }

                int checkDigit = 10 - (checkSum % 10);

                if (checkDigit == 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit != inputCheckDigit)
                {
                    /// Número verificador ingresado inválido
                    return false;
                }
            }
            else
            {
                // Formato de cédula de identidad inválido
                return false;
            }

            return true;
        }

        public static bool ValidarPassword(string pass)
        {
            if (pass == null || pass.Length < 8 || FormatoIncorrecto(pass))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool FormatoIncorrecto(string texto)
        {
            List<char> letras = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<char> letrasMin = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> algunosSimbolos = new List<char>() { ' ', '-', '?', '¿', ',','.' };
            List<char> conTilde = new List<char> { 'á', 'é', 'í', 'ó', 'ú', 'Á', 'É', 'Ú', 'Í', 'Ó' };
            // Le quitamos los posibles espacios que pueda llegar a tener adelante y atras.
            texto = texto.Trim();

            // Una var para ir revisando que todos los caracteres esten correctos.
            bool formatoIncorrecto = true;
            foreach (char c in texto)
            {
                if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c) || algunosSimbolos.Contains(c) || conTilde.Contains(c))
                {
                    formatoIncorrecto = false;
                }
                else
                {
                    return true;
                }
            }
            return formatoIncorrecto;
        }

        public static bool ValidarBio(string bio)
        {
            if (bio.Length < 10 || bio.Length > 250 || FormatoIncorrecto(bio))
            {
                return false;
            }
            else
                return true;
        }

        public static int ValidarCalificacion(int puntaje)
        {
            if(puntaje >= 0 && puntaje <=5)
            {
                return 1;
            }
            else
            {
                /*
                 Como el usuario en cuestión pudo haber querido poner más de 5 o menos de 0 no sería justo
                 mandar todos los puntajes que se salen de rango a 0, entonces validamos cual es cual 
                 y devolvemos una opción númerica que se controlará en el método de calificar. 
                */
                if(puntaje > 5)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
        public static  bool ValidarFotoPasajero(string rutaFoto)
        {
            CognitiveFace cog = new CognitiveFace(true, System.Drawing.Color.GreenYellow);
            cog.Recognize($"{rutaFoto}");
            if (cog.FaceFound)
                return true;
            else
            {
                Console.WriteLine("Su foto no tiene una cara, por favor para la próxima use una foto en la que pueda verse su rostro");
                return false;
            }
        }

        public static bool ValidarFotoConductor(string rutaFoto)
        {
            CognitiveFace cog = new CognitiveFace(true, System.Drawing.Color.GreenYellow);
            cog.Recognize($"{rutaFoto}");
            if (cog.FaceFound)
            {
                if (cog.SmileFound)
                {
                    Console.WriteLine("Se encontro un rostro sonriente, es una buena foto");
                    return true;
                }
                else
                {
                    Console.WriteLine("Por más que su foto contenga su rostro, debe sonreír, debe ser un conductor alegre. Por favor sonría en la próxima ocasión");
                    return false;
                }
            }
            else
                Console.WriteLine("La foto que uso no tiene su rostro, no es valida, ponga su rostro para la próxima vez");
            return false;
        }

                public static bool ValidarMarca(string marca)
        {
            if(marca == null || marca.Length < 3 || FormatoIncorrecto(marca))
            {
                Console.WriteLine("El formato de la marca es incorrecto, ingrese una marca valida");
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool ValidarModelo(string modelo)
        {
            if(modelo == null || modelo.Length < 3 || FormatoIncorrecto(modelo))
            {
                Console.WriteLine("El formato del modelo es incorrecto, ingrese un modelo valido");
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool ValidarMatricula(string matricula)
        {
            List<char> letrasMayus = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            matricula = matricula.Trim();
            if(matricula != null && matricula.Length == 8)
            {
                bool contieneTresLetras = letrasMayus.Contains(matricula[0]) && letrasMayus.Contains(matricula[1]) && letrasMayus.Contains(matricula[2]);
                bool contieneCuatroNumeros = numeros.Contains(matricula[4]) && numeros.Contains(matricula[5]) && numeros.Contains(matricula[6]) && numeros.Contains(matricula[7]);
                if (contieneTresLetras && matricula[3] == ' ' && contieneCuatroNumeros)
                    return true;
                else
                    Console.WriteLine("Los caracateres que introdujo como parte de la matricula son errones, revise las mayúsculas, el espacio y la cantidad de números");
                    return false;

            }
            else
                Console.WriteLine("La matricula introducida no cumple con el foramto pedido");
                return false;
        }
    }    


    
}
using Entidades.Interfaces;
using Entidades.Modelos;

namespace Entidades.Excepciones
{
    public class ServidorPublicolnvalidoException : Exception
    {
        public ServidorPublicolnvalidoException(string message) : base(message)
        {
            try
            {
                // Aquí va el código que comprueba si el servidor público es válido
                throw new ServidorPublicolnvalidoException("El servidor público no es válido.");
            }
            catch (ServidorPublicolnvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ServidorPublicolnvalidoException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}


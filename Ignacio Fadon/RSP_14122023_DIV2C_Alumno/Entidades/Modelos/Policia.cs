using Entidades.Enumerados;
using Entidades.Excepciones;
using Entidades.Interfaces;

namespace Entidades.Modelos
{
    public class Policia : IServidorPublico
    {

        private static List<EEmergencia> emergenciasAtendibles;

    
        
            public string Imagen => $"./assets/{this.GetType().Name}.gif";

            private string[] tiposDeEmergenciaValidos = { "Robo", "Accidente" };

            public void AtenderEmergencia(Emergencia emergencia)
            {
                if (!tiposDeEmergenciaValidos.Contains(emergencia.GetType().Name))
                {
                    throw new ServidorPublicoInvalidoException("El servidor público no puede atender este tipo de emergencias.");
                }

                // Lógica para atender una emergencia
                emergencia.EstaAtendida = true;
                Console.WriteLine("Policía atendiendo la emergencia.");
           
        
    }


}
}

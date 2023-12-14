using Entidades.Interfaces;

namespace Entidades.Modelos
{
    public class Paramedico : IServidorPublico
    {
        public string Imagen => $"./assets/{this.GetType().Name}.gif";

        public void AtenderEmergencia(Emergencia emergencia)
        {
            // Lógica para atender una emergencia
            emergencia.EstaAtendida = true;
            Console.WriteLine("Paramédico atendiendo la emergencia.");
        }
    }
}



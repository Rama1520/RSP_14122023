using Entidades.Enumerados;
using Entidades.MetodosDeExtension;

namespace Entidades.Modelos
{
    public class Emergencia
    {
        private EEmergencia tipo;
        private DateTime inicio;
        private bool estaAtendida;
        private double estadoEmergencia;

        public bool EstaAtendida { get => estaAtendida; set => estaAtendida = value; }
        public EEmergencia Tipo { get => tipo; }
        public string Imagen { get => $"./assets/{tipo}.gif"; }
        public DateTime Inicio { get => inicio; }
        public double EstadoEmergencia { get => estadoEmergencia; }
        public static double TiempoLimiteEnSegundos { get; private set; }
        public double SegundosTranscurridos => TiempoExtension.SegundosTranscurridos(inicio);

        static Emergencia()
        {
            TiempoLimiteEnSegundos = 30;
        }

        public Emergencia(EEmergencia tipo)
        {
            this.tipo = tipo;
        }

        public void EmitirAlerta()
        {
            inicio = DateTime.Now;
        }

        public void ActualizarEstadoEmergencia()
        {
            estadoEmergencia = 1 - (SegundosTranscurridos / TiempoLimiteEnSegundos);
        }
    }
}


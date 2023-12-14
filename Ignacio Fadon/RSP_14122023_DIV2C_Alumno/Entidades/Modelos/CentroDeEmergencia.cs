using Entidades.Enumerados;
using Entidades.Excepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;


namespace Entidades.Modelos
{
    public class CentroDeEmergencia
    {
        public delegate void EmergenciaEnCursoEventHandler(Emergencia emergencia);
        public delegate void EstadoEmergenciaEnCursoEventHandler(string estado);
        public delegate void ServidorInvalidoEventHandler(string mensaje);

        public event EmergenciaEnCursoEventHandler OnEmergenciaEnCurso;
        public event EstadoEmergenciaEnCursoEventHandler OnEstadoEmergenciaEnCurso;
        public event ServidorInvalidoEventHandler OnServidorInvalido;

        private bool cancelacionRequerida = false;
        private Emergencia emergenciaEnCurso;
        private List<Emergencia> emergenciasAtendidas = new List<Emergencia>();

        public void HabilitarIngreso()
        {
            while (!cancelacionRequerida)
            {
                GenerarEmergenciaAleatoria();
                OnEmergenciaEnCurso?.Invoke(emergenciaEnCurso);
                DarSeguimientoAEmergencia();
            }
        }

        public void DeshabilitarIngreso()
        {
            cancelacionRequerida = true;
        }

        public void EnviarServidorPublico<T>(T servidorPublico) where T : IServidorPublico
        {
            Thread hiloServidor = new Thread(() =>
            {
                try
                {
                    Thread.Sleep(3000); // Dormir durante 3 segundos
                    servidorPublico.AtenderEmergencia(emergenciaEnCurso);
                    emergenciasAtendidas.Add(emergenciaEnCurso);
                }
                catch (ServidorPublicoInvalidoException ex)
                {
                    OnServidorInvalido?.Invoke($"Error: {ex.Message}");
                }
            });

            hiloServidor.Start();
        }

        private void GenerarEmergenciaAleatoria()
        {
            // Lógica para generar una emergencia aleatoria
           
            Array valoresEmergencia = Enum.GetValues(typeof(EEmergencia));
            Random random = new Random();
            EEmergencia emergenciaAleatoria = (EEmergencia)valoresEmergencia.GetValue(random.Next(valoresEmergencia.Length));

            emergenciaEnCurso = new Emergencia(emergenciaAleatoria);
        }

        private void DarSeguimientoAEmergencia()
        {
            while (!cancelacionRequerida &&
                   emergenciaEnCurso.SegundosTranscurridos < Emergencia.TiempoLimiteEnSegundos &&
                   !emergenciaEnCurso.EstaAtendida)
            {
                Thread.Sleep(1000); // Dormir durante 1 segundo

                emergenciaEnCurso.ActualizarEstadoEmergencia();
                OnEstadoEmergenciaEnCurso?.Invoke(emergenciaEnCurso.Estado);
            }
        }
    }
}




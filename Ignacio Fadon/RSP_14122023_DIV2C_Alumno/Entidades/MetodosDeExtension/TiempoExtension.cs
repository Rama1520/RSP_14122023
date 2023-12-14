namespace Entidades.MetodosDeExtension
{
    public static class TiempoExtension
    {
        public static int SegundosTranscurridos(this DateTime inicio)
        {
            // Retorna la diferencia en segundos entre la hora actual y la de inicio
            TimeSpan diferencia = DateTime.Now - inicio;
            return (int)diferencia.TotalSeconds;
        }
    }
}

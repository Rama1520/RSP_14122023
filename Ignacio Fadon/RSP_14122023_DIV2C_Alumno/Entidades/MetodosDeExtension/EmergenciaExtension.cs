    using System;
    using System.Collections.Generic;
    using System.Linq;
using Entidades.Enumerados;


namespace Entidades.MetodosDeExtension
{

   

    public static class ListExtensions
    {
        public static bool ValidarEmergencia(this List<EEmergencia> emergencias, EEmergencia valor)
        {
            // Utiliza el método Any para verificar si existe el valor dado en la lista
            return emergencias.Any(emergencia => emergencia == valor);
        }
    }
}

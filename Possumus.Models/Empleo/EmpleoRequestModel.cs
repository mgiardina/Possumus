using System;

namespace Possumus.Models.Empleo
{
    public class EmpleoRequestModel
    {
        public string Empresa { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }
    }
}

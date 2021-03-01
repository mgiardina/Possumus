using System;

namespace Possumus.Models.Empleo
{
    public class EmpleoModel
    {
        public string Empresa { get; set; }

        public long CandidatoId { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }
    }
}

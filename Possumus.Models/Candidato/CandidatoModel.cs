using Possumus.Models.Empleo;
using System;
using System.Collections.Generic;

namespace Possumus.Models.Candidato
{
    public class CandidatoModel
    {
        public long Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public ICollection<EmpleoModel> Empleos { get; set; }

    }
}

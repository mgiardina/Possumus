using Possumus.Models.Empleo;
using System;
using System.Collections.Generic;

namespace Possumus.Models.Candidato
{
    public class CandidatoRequestModel
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public ICollection<EmpleoRequestModel> Empleos { get; set; }

    }
}

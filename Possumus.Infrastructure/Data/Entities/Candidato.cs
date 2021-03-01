using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Possumus.Infrastructure.Data.Entities
{
    public class Candidato
    {
        [Key]
        public long Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public ICollection<Empleo> Empleos { get; set; }

    }
}

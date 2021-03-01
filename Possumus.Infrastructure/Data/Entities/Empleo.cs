using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Possumus.Infrastructure.Data.Entities
{
    public class Empleo
    {
        [Key]
        public long Id { get; set; }

        public long CandidatoId { get; set; }

        public string Empresa { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }        

    }
}

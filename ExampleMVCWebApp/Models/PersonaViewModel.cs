using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleMVCWebApp.Models
{
    public class PersonaViewModel
    {
        public static int NextId;
        public int PersonaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }

        public PersonaViewModel()
        {
            NextId++;
        }
    }
}
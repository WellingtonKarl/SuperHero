using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Web.Models
{
    public class CharactersViewModel
    {

        public string FrontConver { get; set; }

        public string Path { get; set; }

        public string Descrition { get; set; }

        public IEnumerable<SelectListItem> NameSuperHero { get; set; }
    }
}

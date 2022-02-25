using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace VishvaShahChair.Models
{
    public class ChairErgonomicDesignViewModel
    {
        public List<Chair> Chairs { get; set; }
        public SelectList ErgonomicDesigns { get; set; }
        public string ChairErgonomicDesign { get; set; }
        public string SearchString { get; set; }
    }
}

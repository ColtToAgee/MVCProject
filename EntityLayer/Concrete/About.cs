using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(200)]
        public string AboutDetails1 { get; set; }
        [StringLength(200)]
        public string AboutDetails2 { get; set; }
        public string AboutImage1 { get; set; }
        public int AboutImage2 { get; set; }    

    }
}

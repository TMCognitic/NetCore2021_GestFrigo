using GestFrigo.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestFrigo.Models.Forms
{
    public class AddProductForm
    {
        [Required]
        [StringLength(150)]
        [ProductNotExists]
        public string Name { get; set; }
    }
}
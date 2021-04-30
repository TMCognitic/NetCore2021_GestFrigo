using GestFrigo.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestFrigo.Models.Forms
{
    public class AddContentForm
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [ValidateExpirationDate(nameof(AddedDate))]
        public DateTime ExpirationDate { get; set; }
        public List<SelectListItem> Products { get; set; }
        public AddContentForm()
        {
            AddedDate = DateTime.Now.Date;
        }
    }
}
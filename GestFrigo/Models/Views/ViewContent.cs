using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestFrigo.Models.Views
{
    public class ViewContent
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Added Date")]
        public DateTime AddedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Expiration")]
        public DateTime ExpirationDate { get; set; }
    }
}
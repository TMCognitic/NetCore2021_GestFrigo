using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Global.Entities
{
    public class Content
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } //Vue V_Content de la DB vers la vue
        public DateTime AddedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}

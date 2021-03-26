using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ItemProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public decimal UnitaryValue { get; set; }

        public int Amount { get; set; } = 1;

        public decimal TotalValue { get; set; }


    }
}

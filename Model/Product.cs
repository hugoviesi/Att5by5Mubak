using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public decimal UnitaryPrice { get; set; }

        public virtual Category Category { get; set; }

    }
}

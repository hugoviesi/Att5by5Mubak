using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string ZipCode { get; set; }

        public string Locale { get; set; }

        public string Region { get; set; }

    }
}
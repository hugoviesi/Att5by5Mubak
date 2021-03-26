using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Situation { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public virtual List<Address> Address { get; set; }

        public virtual List<Phone> Phone { get; set; }

        public string Permission { get; set; }

        public string Email { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace CodeShare_Library.Models
{
    public class Users
    {
        [Key]
        public long UsersId { get; set; }

        public string Name { get; set; }

        public string Date_registration {  get; set; }


    }
}

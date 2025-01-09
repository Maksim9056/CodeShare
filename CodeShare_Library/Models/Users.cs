using System.ComponentModel.DataAnnotations;

namespace CodeShare_Library.Models
{
    public class Users
    {
        [Key]
        public long UsersId { get; set; }

        public string UsersName { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string Phone {  get; set; }
        public string Email {get;set;}
        public  string Password { get; set; }
        public string CreateAt {  get; set; }
        public string UpdatedAt{ get; set; }


    }
}

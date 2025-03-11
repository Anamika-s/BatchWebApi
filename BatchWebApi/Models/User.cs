using System.ComponentModel.DataAnnotations.Schema;

namespace BatchWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public int CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public int? UpdatedBy { get; set; }
        //public DateTime? UpdatedOn { get; set; }

        //public bool IsActive { get; set; }  // is used for soft delete

        // add foreign key
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        // adding fkey , self join
        [ForeignKey("ManagerId")]
        public int? ManagerId { get; set; }
        public User? Manager { get; set; }


    }

}

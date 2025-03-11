
namespace BatchWebApi.Models
{
    // parent table  1 to many relationship
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // link tables

        public List<User>? Users { get; set; }
    }
}

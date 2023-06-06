using isk.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace isk.GeneralAPI.DAL.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string HomeTown { get; set; }
    }
}

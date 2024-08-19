using System.ComponentModel.DataAnnotations;

namespace UserService.Domain
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        //public byte[] Photograph { get; set; }

    }
}

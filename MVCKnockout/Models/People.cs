using Microsoft.Build.Framework;

namespace MVCKnockout.Models
{
    public class People
    {
        public int id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

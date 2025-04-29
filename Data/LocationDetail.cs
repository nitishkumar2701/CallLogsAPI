using System.ComponentModel.DataAnnotations;

namespace CallLogsAPI.Data
{
    public class LocationDetail
    {
        [Key]
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
    }
}
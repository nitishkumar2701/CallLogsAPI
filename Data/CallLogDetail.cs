using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace CallLogsAPI.Data
{
    public class CallLogDetail
    {
        [Key]
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string FromName { get; set; }
        public long FromNumber { get; set; }
        public string ToName { get; set; }
        public long ToNumber { get; set; }
    }
}

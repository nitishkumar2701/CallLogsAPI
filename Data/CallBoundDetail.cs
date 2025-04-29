using System.ComponentModel.DataAnnotations;

namespace CallLogsAPI.Data
{
    public class CallBoundDetail
    {
        [Key]
        public int UserId { get; set; }
        public int InboundCallsCount { get; set; }
        public int OutboundCallsCount { get; set; }
    }
}

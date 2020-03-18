using System;

namespace MessageApplication.Web.Domain
{
    public class Invitation
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public int Author { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

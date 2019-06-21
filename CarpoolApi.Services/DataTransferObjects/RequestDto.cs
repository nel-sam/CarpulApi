namespace CarpoolApi.Service.DataTransferObjects
{
    public class RequestDto
    {
        public RequestDto() { }

        public RequestDto(string firstName, string lastName, string message, string approval, string action, int carpoolId)
        {
            Message = message;
            Approval = approval;
			Action = action;
            CarpoolId = carpoolId;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public string Approval { get; set; }
		public string Action { get; set; }
		public int CarpoolId { get; set; }
    }
}

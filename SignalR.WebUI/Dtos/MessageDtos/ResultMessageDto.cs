namespace SignalR.WebUI.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
    }
}

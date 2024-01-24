namespace SignalR.WebUI.Dtos.DiscountDtos
{
	public class ResultDiscount
	{
		public int DiscountID { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
	}
}

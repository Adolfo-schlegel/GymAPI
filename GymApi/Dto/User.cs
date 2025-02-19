namespace GymApi.Dto
{
	public class User
	{
		public string? user_code { get; set; }
		public List<int>? door_access { get; set; }
		public bool? allowed { get; set; }
	}
}


namespace CodewarsAPI_ASPNET
{
	public class User
	{
        public User()
        {
        }

        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public int? Honor { get; set; }
        public string? Clan { get; set; }
        public int? LeaderboardPosition { get; set; }
        public List<object>? Skills { get; set; }
        public Ranks? Ranks { get; set; }
        public CodeChallenges? CodeChallenges { get; set; }
        public string? JSON { get; set; }

		public static List<User> UsersList { get; set; } = new List<User>();
    }
}
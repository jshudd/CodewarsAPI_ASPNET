using System;
namespace CodewarsAPI_ASPNET
{
	public class User
	{
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public int? Honor { get; set; }
        public string Clan { get; set; }
        public int? LeaderboardPosition { get; set; }
        public List<object> Skills { get; set; }
        public Ranks Ranks { get; set; }
        public CodeChallenges CodeChallenges { get; set; }
    }
}


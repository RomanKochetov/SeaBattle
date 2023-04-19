namespace SeaBattle.Data
{
    public static class TeamData
    {
        public static string TeamOne;
        public static long TeamOneScore = 0;
        
        public static string TeamTwo;
        public static long TeamTwoScore = 0;

        public static bool IsOneTeamTurn;

        public static void SetTeams(string one, string two)
        {
            TeamOne = one;
            TeamTwo = two;
        }

        public static void AddScore(long amount)
        {
            if (IsOneTeamTurn) TeamOneScore += amount;
            else TeamTwoScore += amount;
        }

        public static bool HasTeams()
        {
            return TeamOne != null && TeamTwo != null;
        }
    }
}

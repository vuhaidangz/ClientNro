public class Member
{
	public int ID;

	public short head;

	public short headICON = -1;

	public short leg;

	public short body;

	public string name;

	public sbyte role;

	public string powerPoint;

	public int donate;

	public int receive_donate;

	public int curClanPoint;

	public int clanPoint;

	public int lastRequest;

	public string joinTime;

	public static string getRole(int r)
	{
		switch (r)
		{
		case 0:
			return mResources.clan_leader;
		case 1:
			return mResources.clan_coleader;
		case 2:
			return mResources.member;
		default:
			return string.Empty;
		}
	}
}

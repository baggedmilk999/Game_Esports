namespace Game_Esports;
using MySql.Data.MySqlClient;

public partial class PlayerInfo : ContentPage
{
	public PlayerInfo()
	{
		InitializeComponent();
	}

	private void LookupStudentInfo_Clicked(object sender, EventArgs e)
	{
        string cs = @"server=192.169.144.133;userid=mcctc2;password=mcctcrocks;database=sr_team_2";
        using var con = new MySqlConnection(cs);
        con.Open();
        string sql = $@"SELECT * FROM UserTable WHERE PlayerID = '{LookupID.Text}';";
        using var cmd = new MySqlCommand(sql, con);
        using MySqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            FirstNameLookup.Text = rdr.GetString(1);
            LastNameLookup.Text = rdr.GetString(2);
            PhoneNumberLookup.Text = rdr.GetString(3);
            DiscordIDLookup.Text = rdr.GetString(4);
            GameLookup.Text = rdr.GetString(5);
        }
        con.Close();
    }
}
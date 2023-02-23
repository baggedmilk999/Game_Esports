namespace Game_Esports;
using MySql.Data.MySqlClient;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}
	private void SubmitStudentInfo_Clicked(object sender, EventArgs e)
    {
        string cs = @"server=192.169.144.133;userid=mcctc2;password=mcctcrocks;database=sr_team_2";
        using var con = new MySqlConnection(cs);
        con.Open();
        using var cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $@"INSERT IGNORE INTO UserTable(PlayerID, FirstName, LastName, PhoneNumber, DiscordID, GameEntry) VALUES ({PlayerID.Text},'{FirstName.Text}','{LastName.Text}','{PhoneNumber.Text}','{DiscordID.Text}','{EsportsGame.GetValue}') ON DUPLICATE KEY UPDATE FirstName='{FirstName.Text}', LastName='{LastName.Text}', PhoneNumber='{PhoneNumber.Text}', DiscordID='{DiscordID.Text}', GameEntry='{EsportsGame.GetValue}';";
        cmd.ExecuteNonQuery();
        con.Close();
    }
}


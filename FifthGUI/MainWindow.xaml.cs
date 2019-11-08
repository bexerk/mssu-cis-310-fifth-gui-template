using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace FifthGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<string> playerList;

        public MainWindow()
        {
            InitializeComponent();
            playerList = new List<string>();
        }

        private string CreateHOFPlayersSQLString()
        {
            string sql = "SELECT Master.namefirst, Master.namelast FROM HallOfFame JOIN Master ON HallOfFame.playerID = Master.playerID GROUP BY Master.playerID ORDER BY Master.namelast;";
            return sql;
        }

        private void hof_button_Click(object sender, RoutedEventArgs e)
        {
            //Student A - uncomment the next line
            executeSQL(CreateHOFPlayersSQLString());
        }

        private void manager_button_Click(object sender, RoutedEventArgs e)
        {
            //Student B = uncomment the next line
            executeSQL(CreateManagersSQLString());
        }

        private void executeSQL(string sql)
        {
            DataTable dt = new DataTable();

            //Change this if you put your program on a Flash Drive!
            string datasource = @"Data Source=..\..\lahman2016.sqlite;";

            //This is the SQL query to get the players who have hit more than 60 doubles in a single season
            //Keep if you want, but you'll evetually replace this with a new query
            using (SQLiteConnection conn = new SQLiteConnection(datasource))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            playerList.Clear();
            foreach (DataRow row in dt.Rows)
            {
                playerList.Add(row[0].ToString() + ' ' + row[1].ToString());
            }
            populateList();
        }

        private void populateList()
        {
            outputListBox.Items.Clear();
            foreach (string s in playerList)
            {
                outputListBox.Items.Add(s);
            }
        }
        private static string CreateManagersSQLString()
        {
            string sql = "Write an SQL query to display the first and last names of all of the managers. The playerID field in the HallOfFame table is a foreign key to the Master table. Recall that the Master table stores the personal information about all of the players.";
            return sql;
        }
    }
}

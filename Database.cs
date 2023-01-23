using System;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lakopark {
    public sealed class Database {

        public static MySqlConnection Connection { get; private set; }
        public static MySqlCommand SqlCommand { get; private set; }

        static Database() {
            try {
                (Connection = new MySqlConnection("server=localhost;user=root;database=lakopark;")).Open();
                SqlCommand = Connection.CreateCommand();
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Adatbázis kapcsolódás sikertelen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private Database() {
        }

        public static MySqlDataReader PerformSqlQuery(string cmd, params object[] values) {
            SqlCommand.CommandText = cmd;
            SqlCommand.Parameters.Clear();

            for (int i = 0; i < values.Length; i++) {
                SqlCommand.Parameters.AddWithValue($"@{i}", values[i]);
            }

            try {
                return SqlCommand.ExecuteReader();
            } catch (DbException ex) {
                MessageBox.Show($"Hiba lépett fel az adatbázis parancs végrehajtásakor: {ex.Message}\n{ex.StackTrace}", "Adatbázis hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public static async Task<bool> PerformSqlCommand(string cmd, params object[] values) {
            SqlCommand.CommandText = cmd;
            SqlCommand.Parameters.Clear();

            for (int i = 0; i < values.Length; i++) {
                SqlCommand.Parameters.AddWithValue($"@{i}", values[i]);
            }

            try {
                if ((await SqlCommand.ExecuteNonQueryAsync()) != 1) {
                    return false;
                }
            } catch (DbException ex) {
                MessageBox.Show($"Hiba lépett fel az adatbázis parancs végrehajtásakor: : {ex.Message}\n{ex.StackTrace}", "Adatbázis hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}

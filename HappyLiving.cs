using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lakopark {
    public sealed class HappyLiving {

        public List<Lakopark> lakoparkok { get; } = new List<Lakopark>();

        public HappyLiving() {
            List<Lakopark> temp = new List<Lakopark>();

            using (MySqlDataReader reader = Database.PerformSqlQuery("select * from lakopark;")) {
                while (reader.Read()) {
                    temp.Add(new Lakopark(reader.GetString("nev"), reader.GetInt32("utcakSzama"), reader.GetInt32("hazakSzama"), null));
                }
            }

            foreach (Lakopark lakopark in temp) {
                int[,] hazak = new int[lakopark.utcakSzama, lakopark.maxHazSzam];

                using (MySqlDataReader reader2 = Database.PerformSqlQuery("select * from hazak where lakopark = @0;", lakopark.nev)) {
                    while (reader2.Read()) {
                        hazak[reader2.GetInt32("utca") - 1, reader2.GetInt32("hazszam") - 1] = reader2.GetInt32("emelet");
                    }
                }

                lakoparkok.Add(new Lakopark(lakopark.nev, lakopark.utcakSzama, lakopark.maxHazSzam, hazak));
            }
        }

        public bool SaveData() {
            try {
                string name = Form1.GetResourceFileByName("lakoparkok.txt");

                File.Copy(name, $"lakoparkok_{DateTime.Now:yyyyMMdd_hhmm}.txt");

                using (StreamWriter writer = new StreamWriter(name)) {
                    foreach (Lakopark lakopark in lakoparkok) {
                        writer.WriteLine(lakopark.nev);
                        writer.WriteLine($"{lakopark.utcakSzama};{lakopark.maxHazSzam}");

                        int secondLength = lakopark.hazak.GetLength(1);
                        int firstLength = lakopark.hazak.GetLength(0);

                        for (int i = 0; i < firstLength; i++) {
                            for (int j = 0; j < secondLength; j++) {
                                writer.WriteLine(string.Join(";", i, j, lakopark.hazak[i, j]));
                            }
                        }

                        writer.WriteLine();
                    }
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show($"Hiba lépett fel a fájl mentésekor: {ex.Message}\n{ex.StackTrace}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}

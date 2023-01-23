using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<bool> SaveData() {
            await Database.PerformSqlCommand("truncate table `datas`;");

            foreach (Lakopark lakopark in lakoparkok) {
                int secondLength = lakopark.hazak.GetLength(1);
                int firstLength = lakopark.hazak.GetLength(0);

                for (int i = 0; i < firstLength; i++) {
                    for (int j = 0; j < secondLength; j++) {
                        if (!(await Database.PerformSqlCommand("insert into `datas` (nev, utcakSzama, maxHazSzam, utca, hazszam, emelet) values (@0, @1, @2, @3, @4, @5);",
                                lakopark.nev, lakopark.utcakSzama, lakopark.maxHazSzam, i + 1, j + 1, lakopark.hazak[i, j] + 1))) {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}

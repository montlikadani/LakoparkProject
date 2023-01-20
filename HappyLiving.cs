using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lakopark {
    public sealed class HappyLiving {

        public List<Lakopark> lakoparkok { get; } = new List<Lakopark>();

        public HappyLiving(string filenev) {
            try {
                using (StreamReader reader = File.OpenText(filenev)) {
                    while (!reader.EndOfStream) {
                        string name = reader.ReadLine();
                        string[] split = reader.ReadLine().Split(';');
                        int utcakSzama = int.Parse(split[0]);
                        int hazakSzama = int.Parse(split[1]);
                        int[,] hazak = new int[utcakSzama, hazakSzama];

                        string line;
                        while (!string.IsNullOrEmpty(line = reader.ReadLine())) {
                            split = line.Split(';');
                            hazak[int.Parse(split[0]) - 1, int.Parse(split[1]) - 1] = int.Parse(split[2]);
                        }

                        lakoparkok.Add(new Lakopark(name, utcakSzama, hazakSzama, hazak));
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"Hiba lépett fel a fájl betöltésekor: {ex.Message}\n{ex.StackTrace}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
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

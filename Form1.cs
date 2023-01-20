using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lakopark {
    public partial class Form1 : Form {

        public HappyLiving Living { get; private set; }

        private int currentPark = 0;
        private readonly List<Image> houseLevels = new List<Image>(4);

        public Form1() {
            InitializeComponent();

            Living = new HappyLiving(GetResourceFileByName("lakoparkok.txt"));

            houseLevels.Add(Properties.Resources.kereszt);
            houseLevels.Add(Properties.Resources.Haz1);
            houseLevels.Add(Properties.Resources.Haz2);
            houseLevels.Add(Properties.Resources.Haz3);

            UpdatePanelItems();
        }

        public static string GetResourceFileByName(string name) {
            return string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")), name);
        }

        private void UpdatePanelItems() {
            Lakopark lakopark = Living.lakoparkok[currentPark];

            Text = $"{lakopark.nev} lakópark";

            if (currentPark == 0) {
                leftButton.Hide();
            } else if (currentPark == Living.lakoparkok.Count - 1) {
                rightButton.Hide();
            } else {
                leftButton.Show();
                rightButton.Show();
            }

            Control.ControlCollection controlCollection = panelPictureBox.Controls;

            iconBox.BackgroundImage = lakopark.SourcePark;
            controlCollection.Clear();

            int buttonSize = 50;
            int secondLength = lakopark.hazak.GetLength(1);
            int firstLength = lakopark.hazak.GetLength(0);

            for (int i = 0; i < secondLength; i++) {
                for (int j = 0; j < firstLength; j++) {
                    PictureBox pictureBox = new PictureBox() {
                        BackgroundImage = houseLevels[lakopark.hazak[j, i]],
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = new KeyValuePair<int, int>(i, j),
                        Cursor = Cursors.Hand
                    };

                    pictureBox.SetBounds(i * buttonSize, j * buttonSize, buttonSize, buttonSize);

                    pictureBox.Click += (o, e) => {
                        if (o is PictureBox clicked && clicked.Tag is KeyValuePair<int, int> pair) {
                            lakopark.IncreaseHouseLevel(pair.Value, pair.Key);
                            clicked.BackgroundImage = houseLevels[lakopark.hazak[pair.Value, pair.Key]];
                        }
                    };

                    controlCollection.Add(pictureBox);
                }
            }
        }

        private void leftButton_Click(object sender, EventArgs e) {
            currentPark--;
            UpdatePanelItems();
        }

        private void rightButton_Click(object sender, EventArgs e) {
            currentPark++;
            UpdatePanelItems();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (Living.SaveData()) {
                MessageBox.Show("Sikeres mentés", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonStatistics_Click(object sender, EventArgs e) {
            try {
                string name = $"statisztika_{DateTime.Now:yyyyMMdd}.txt";

                using (StreamWriter writer = new StreamWriter(name)) {
                    writer.WriteLine("Statisztika\n");

                    foreach (Lakopark lakopark in Living.lakoparkok) {
                        int streetNumber = lakopark.StreetFullyBuiltWithHouses();

                        if (streetNumber != -1) {
                            writer.WriteLine($"A {lakopark.nev} lakópark {streetNumber}. utcája teljesen beépített\n");
                            break;
                        }
                    }

                    Lakopark park = Living.lakoparkok.OrderBy(s => s.GetRatioOfBuiltHouses()).Last();

                    writer.WriteLine($"A legjobban beépített a {park.nev} lakópark {park.RatioOfBuiltHouses * 100}% beépítettséggel.");
                    writer.WriteLine($"\nA HappyLiving cégnek összes bevétele {Living.lakoparkok.Sum(a => a.CountIncome())} Ft");
                }

                System.Diagnostics.Process.Start("notepad.exe", $"{Directory.GetCurrentDirectory()}\\{name}");
            } catch (Exception ex) {
                MessageBox.Show($"Hiba lépett fel a statisztikai adatok mentésekor: {ex.Message}\n{ex.StackTrace}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

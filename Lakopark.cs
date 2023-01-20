using System.Drawing;

namespace Lakopark {
    public sealed class Lakopark {

        public int[,] hazak { get; }
        public int maxHazSzam { get; }
        public string nev { get; }
        public int utcakSzama { get; }
        
        public Image SourcePark { get; }
        public double RatioOfBuiltHouses { get; private set; } = 0.0;

        public Lakopark(string nev, int utcakSzama, int maxHazSzam, int[,] hazak) {
            this.nev = nev;
            this.utcakSzama = utcakSzama;
            this.maxHazSzam = maxHazSzam;
            this.hazak = hazak;

            SourcePark = Image.FromFile(Form1.GetResourceFileByName($"{nev}.jpg"));
        }

        public void IncreaseHouseLevel(int utca, int haz) {
            hazak[utca, haz] = (hazak[utca, haz] == 3) ? 0 : ++hazak[utca, haz];
        }

        public int StreetFullyBuiltWithHouses() {
            int secondLength = hazak.GetLength(1);
            int firstLength = hazak.GetLength(0);

            for (int i = 0; i < firstLength; i++) {
                for (int j = 0; j < secondLength; j++) {
                    if (hazak[i, j] != 0) {
                        return i + 1;
                    }
                }

                if (secondLength == 0) {
                    return i + 1;
                }
            }

            return -1;
        }

        public double GetRatioOfBuiltHouses() {
            double amount = 0.0;
            int secondLength = hazak.GetLength(1);
            int firstLength = hazak.GetLength(0);

            for (int i = 0; i < firstLength; i++) {
                for (int j = 0; j < secondLength; j++) {
                    if (hazak[i, j] != 0) {
                        amount++;
                    }
                }
            }

            return RatioOfBuiltHouses = amount / (firstLength * secondLength);
        }

        public double CountIncome() {
            double income = 0.0;
            int secondLength = hazak.GetLength(1);
            int firstLength = hazak.GetLength(0);

            for (int i = 0; i < firstLength; i++) {
                for (int j = 0; j < secondLength; j++) {
                    switch (hazak[i, j]) {
                        case 1:
                            income += 80;
                            break;
                        case 2:
                            income += 150; // 80 + 70
                            break;
                        case 3:
                            income += 200; // 80 + 70 + 50
                            break;
                        default:
                            break;
                    }
                }
            }

            return income * 300000;
        }
    }
}

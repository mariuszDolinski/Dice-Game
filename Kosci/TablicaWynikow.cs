using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Kosci
{
    class TablicaWynikow
    {
        private Label[,] tablica;

        public Label[,] Tablica
        {
            get { return tablica; }
            set { tablica = value; }
        }

        public TablicaWynikow()
        {
            tablica = new Label[5, 19];
            for (int i = 0; i < 5; i++)
            {
                
                for (int j = 0; j < 19; j++)
                {
                    tablica[i, j] = new Label();
                    tablica[i, j].BorderStyle = BorderStyle.None;
                    tablica[i, j].BackColor = Color.Azure;
                    tablica[i, j].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                    if (i == 0)
                    {
                        tablica[i, j].Location = new Point(3 + i * 135, 3 + j * 20);
                        tablica[i, j].Size = new Size(124, 19);
                        tablica[i, j].TextAlign = ContentAlignment.MiddleLeft;
                    }
                    else
                    {
                        tablica[i, j].Location = new Point(92 + i * 36, 3 + j * 20);
                        tablica[i, j].Size = new Size(35, 19);
                        tablica[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }
            inicujTabele();
        }

        private void inicujTabele()
        {
            tablica[0, 1].Text = "Jedynki";
            tablica[0, 2].Text = "Dwójki";
            tablica[0, 3].Text = "Trójki";
            tablica[0, 4].Text = "Czwórki";
            tablica[0, 5].Text = "Piątki";
            tablica[0, 6].Text = "Szóstki";
            tablica[0, 7].Text = "Suma";
            tablica[0, 8].Text = "Bonus";
            tablica[0, 9].Text = "Dwie pary";
            tablica[0, 10].Text = "3 takie same";
            tablica[0, 11].Text = "4 takie same";
            tablica[0, 12].Text = "Strit";
            tablica[0, 13].Text = "Full";
            tablica[0, 14].Text = "5 takich samych";
            tablica[0, 15].Text = "Szansa";
            tablica[0, 16].Text = "Suma";
            tablica[0, 17].Text = "Bonus";
            tablica[0, 18].Text = "Wynik";
            tablica[1, 0].Text = "I";
            tablica[2, 0].Text = "II";
            tablica[3, 0].Text = "III";
            tablica[4, 0].Text = "IV";

            for (int i = 0; i < 5; i++)
            {
                tablica[i, 7].BackColor = Color.LightSteelBlue;
                tablica[i, 8].BackColor = Color.LightSteelBlue;
                tablica[i, 0].BackColor = Color.LightSteelBlue;
                tablica[i, 16].BackColor = Color.LightSteelBlue;
                tablica[i, 17].BackColor = Color.LightSteelBlue;
                tablica[i, 18].BackColor = Color.Gray;
            }
        }
    }
}

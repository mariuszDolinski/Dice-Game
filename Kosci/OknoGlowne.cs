using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


// do poprawki - ostatnią ture moze grac tylko pierwszy gracz
//             - mozna usunąć gracza w trakcie gry
//             - przycisk Rozpocznij grę powinien zmienic się na zakoncz grę po rozpoczęciu gry i na odwrót 

namespace Kosci
{
    public partial class OknoGlowne : Form
    {

        private TablicaWynikow tab;
        private Panel panel;
        private Panel panelKL;
        private Panel panelKW;
        private Panel panelGra;
        private Panel[] gracz;
        private Label nrTury;
        private MojPrzycisk rzut;
        private MojPrzycisk nowaGra;
        private Label[] kosciLos;
        private Label[] kosciWyb;
        private Label[] numer;
        private TextBox[] nazwa;
        private MojPrzycisk[] dodajGracza;
        private Label[] nazwaGracza;
        //private Label pomoc;

        Random losuj;

        private int[] wynikRzutu;
        private int[] ileRazy;
        private bool[] wybrane;
        private bool[,] wybraneKategorie;

        private int[] bonus1, bonus2, bonus3;
        private int[] suma1, suma2;
        private int[] wynik;
        private bool gra;
        private int tura;
        private int nrRzutu;
        private bool kolejnaTura;
        private int[] piatki;
        private bool[] gracze;
        private int aktualnyGracz;
        private int pierwszyGracz;
        private int ostatniGracz;
        private int[] dodaj; // 1 - dodaj gracza, 2 - usuń gracza, 0 - pozostałe

        public OknoGlowne()
        {
            InitializeComponent();

            tab = new TablicaWynikow();
            panel = new Panel();
            panelKL = new Panel();
            panelKW = new Panel();
            panelGra = new Panel();
            nrTury = new Label();
            rzut = new MojPrzycisk();
            nowaGra = new MojPrzycisk();
            //pomoc = new Label();


            losuj = new Random();
            wynikRzutu = new int[5];
            ileRazy = new int[6];
            wybrane = new bool[5];
            wybraneKategorie = new bool[4,19];

            panel.Location = new Point(2, 2);
            panel.Size = new Size(274, 385);
            panel.BackColor = Color.Black;
            panelKL.Location = new Point(281, 2);
            panelKL.Size = new Size(239, 51);
            panelKL.BackColor = Color.Black;
            panelGra.Location = new Point(281, 56);
            panelGra.Size = new Size(panelKL.Width, 27);
            panelGra.BackColor = Color.Black;

            nrTury.Location = new Point(2, 2);
            nrTury.Size = new Size(7 * panelKL.Width / 10 - 3, 23);
            nrTury.TextAlign = ContentAlignment.MiddleCenter;
            nrTury.BackColor = Color.LemonChiffon;
            

            rzut.Location = new Point(2 + nrTury.Width + 2, 2);
            rzut.Size = new Size(3 * panelKL.Width / 10 - 1, 24);
            rzut.Text = "Rzuć";
            rzut.BackColor = SystemColors.Control;
            rzut.MouseClick += new MouseEventHandler(rzut_MouseClick);

            panelGra.Controls.Add(nrTury);
            panelGra.Controls.Add(rzut);
            
            panelKW.Location = new Point(281, panelGra.Location.Y + panelGra.Size.Height + 3);
            panelKW.Size = new Size(239, 51);
            panelKW.BackColor = Color.Black;

            nowaGra.Location = new Point(281 + (10 * panelKW.Size.Width / 100), panelKW.Location.Y + panelKW.Size.Height + 6);
            nowaGra.Size = new Size(80 * panelKW.Size.Width / 100, rzut.Size.Height);
            nowaGra.Text = "Rozpocznij grę";
            nowaGra.MouseClick += new MouseEventHandler(nowaGra_MouseClick);

            bonus1 = new int[4];
            bonus2 = new int[4];
            bonus3 = new int[4];
            suma1 = new int[4];
            suma2 = new int[4];
            wynik = new int[4];
            gracze = new bool[4];
            dodaj = new int[4];
            piatki = new int[4];
            kosciLos = new Label[5];
            kosciWyb = new Label[5];
            gracz = new Panel[4];
            numer = new Label[4];
            nazwa = new TextBox[4];
            nazwaGracza = new Label[4];
            dodajGracza = new MojPrzycisk[4];
            for (int i = 0; i < 5; i++)
            {
                kosciLos[i] = new Label();
                kosciWyb[i] = new Label();
                kosciLos[i].Location = new Point(2 + 47 * i, 2);
                kosciLos[i].Size = new Size(47, 47);
                kosciLos[i].Tag = i;
                kosciWyb[i].Tag = i;
                kosciLos[i].MouseClick += new MouseEventHandler(OknoGlowne_MouseClick);
                kosciWyb[i].MouseClick +=new MouseEventHandler(OknoGlowne02_MouseClick);
                kosciWyb[i].Location = new Point(2 + 47 * i, 2);
                kosciWyb[i].Size = new Size(47, 47);
                panelKL.Controls.Add(kosciLos[i]);
                panelKW.Controls.Add(kosciWyb[i]);
                if (i < 4)
                {
                    gracz[i] = new Panel();
                    numer[i] = new Label();
                    nazwa[i] = new TextBox();
                    dodajGracza[i] = new MojPrzycisk();
                    nazwaGracza[i] = new Label();

                    gracz[i].Location = new Point(281, nowaGra.Location.Y + nowaGra.Height + 6 + (33 * i));
                    gracz[i].Size = new Size(panelKW.Width, 27);
                    gracz[i].BackColor = Color.Black;

                    numer[i].Location = new Point(2, 2);
                    numer[i].Size = new Size((2 * gracz[i].Width) / 10, gracz[i].Height - 4);
                    numer[i].BackColor = Color.LightSteelBlue;
                    numer[i].TextAlign = ContentAlignment.MiddleCenter;
                    numer[i].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                    switch (i)
                    {
                        case 0: numer[i].Text = "I"; break;
                        case 1: numer[i].Text = "II"; break;
                        case 2: numer[i].Text = "III"; break;
                        case 3: numer[i].Text = "IV"; break;
                    }

                    nazwa[i].Location = new Point(numer[i].Location.X + numer[i].Width + 2, 3);
                    nazwa[i].Size = new Size((5 * gracz[i].Width) / 10, gracz[i].Height - 4);
                    nazwa[i].Visible = false;

                    nazwaGracza[i].Location = new Point(nazwa[i].Location.X, 2);
                    nazwaGracza[i].Size = new Size(nazwa[i].Width, numer[i].Height);
                    nazwaGracza[i].BackColor = Color.LemonChiffon;
                    nazwaGracza[i].Tag = i;
                    nazwaGracza[i].TextAlign = ContentAlignment.MiddleCenter;
                    nazwaGracza[i].Font = new Font("Verdana", 10, FontStyle.Bold);
                    nazwaGracza[i].MouseDoubleClick += new MouseEventHandler(nazwaGracza_MouseDoubleClick);

                    dodajGracza[i].Location = new Point(nazwa[i].Location.X + nazwa[i].Width + 2, 2);
                    dodajGracza[i].Size = new Size((3 * gracz[i].Width) / 10 - 5, gracz[i].Height - 3);
                    dodajGracza[i].Text = "Dodaj";
                    dodajGracza[i].BackColor = SystemColors.Control;
                    dodajGracza[i].Tag = i;
                    dodajGracza[i].MouseClick +=new MouseEventHandler(dodajGracza_MouseClick);

                    dodaj[i] = 0;
                    gracze[i] = false;    

                    this.Controls.Add(gracz[i]);
                    gracz[i].Controls.Add(numer[i]);
                    gracz[i].Controls.Add(nazwa[i]);
                    gracz[i].Controls.Add(dodajGracza[i]);
                    gracz[i].Controls.Add(nazwaGracza[i]);
                }
            }
            inicjujGre();
            nrTury.Text = "";
            gra = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    tab.Tablica[i, j].Tag = new PozycjaPola() { X = i, Y = j };
                    if(i != 0 && j != 0) tab.Tablica[i, j].Text = "";
                    if (j == 7 || j == 8 || j == 16 || j == 17 || j == 18)
                    {
                        if (i != 0)
                        {
                            tab.Tablica[i, j].Text = "0";
                        }
                    }
                    panel.Controls.Add(tab.Tablica[i, j]);
                    if (i > 0)
                    {
                        tab.Tablica[i, j].MouseEnter += new EventHandler(OknoGlowne_MouseEnter);
                        tab.Tablica[i, j].MouseLeave += new EventHandler(OknoGlowne_MouseLeave);
                        tab.Tablica[i,j].MouseClick +=new MouseEventHandler(tablica_MouseClick);
                    }
                }
            }
            this.Controls.Add(panel);
            this.Controls.Add(panelKL);
            this.Controls.Add(panelGra);
            this.Controls.Add(panelKW);
            this.Controls.Add(nowaGra);
        }

        void nazwaGracza_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!gra)
            {
                Label l = new Label();
                l = (Label)sender;
                int i = (int)l.Tag;

                nazwaGracza[i].Visible = false;
                nazwa[i].Visible = true;
                dodajGracza[i].Text = "Dodaj";
                dodaj[i] = 1;
            }
        }

        void nowaGra_MouseClick(object sender, MouseEventArgs e)
        {
            if (iloscGraczy() > 0)
            {
                gra = true;
                nrTury.Text = "Tura: " + tura.ToString() + "   Rzuty: " + nrRzutu.ToString();
                inicjujGre();
            }
            else
            {
                MessageBox.Show("Brak graczy !!!");
            }
        }

        void dodajGracza_MouseClick(object sender, MouseEventArgs e)
        {
            MojPrzycisk p = new MojPrzycisk();
            p = (MojPrzycisk)sender;
            int i = (int)p.Tag;

            if (dodaj[i] != 0 && nazwa[i].Text.Length > 2)
            {
                if (dodaj[i] == 1)
                {
                    dodajGracza[i].Text = "Usuń";
                    nazwaGracza[i].Text = nazwa[i].Text;
                    nazwa[i].Visible = false;
                    nazwaGracza[i].Visible = true;
                    dodaj[i] = 2;
                    gracze[i] = true;
                }
                else if (dodaj[i] == 2)
                {
                    dodajGracza[i].Text = "Dodaj";
                    nazwaGracza[i].Text = "";
                    dodaj[i] = 0;
                    gracze[i] = false;
                }

            }
        }

        private int iloscGraczy()
        {
            int wynik = 0;
            for (int i = 0; i < 4; i++)
            {
                if (gracze[i]) wynik++;
            }
            return wynik;
        }

        private void ustawKoloryGraczy(int g)
        {
            for (int i = 1; i < 5; i++)
            {
                if (i == g)
                {
                    tab.Tablica[g, 0].BackColor = Color.Orange;
                    nazwaGracza[g - 1].BackColor = Color.Orange;
                }
                else
                {
                    tab.Tablica[i, 0].BackColor = Color.LightSteelBlue;
                    nazwaGracza[i - 1].BackColor = Color.LemonChiffon;
                }
            }
        }

        private void zmienAktualnegoGracza()
        {
            for (int i = 0; i < 4; i++)
            {
                aktualnyGracz++;
                if (aktualnyGracz < 5)
                {
                    if (gracze[aktualnyGracz - 1])
                    {
                        ustawKoloryGraczy(aktualnyGracz);
                        return;
                    }
                }
                else
                {
                    aktualnyGracz = 0;
                    i--;
                }
            }
        }

        private int znajdzPierwszegogracza()
        {
            for (int i = 0; i < 4; i++)
            {
                if (gracze[i]) return i + 1;
            }
            return 0;
        }

        private int znajdzOstatniegoGracza()
        {
            for (int i = 3; i >= 0; i--)
            {
                if (gracze[i]) return i + 1;
            }
            return 0;
        }

        private void inicjujGre()
        {
            gra = true;
            tura = 1;
            nrRzutu = 0;
            aktualnyGracz = znajdzPierwszegogracza();
            pierwszyGracz = aktualnyGracz;
            ostatniGracz = znajdzOstatniegoGracza();
            ustawKoloryGraczy(aktualnyGracz);
            kolejnaTura = false;

            nrTury.Text = "Tura: " + tura.ToString() + "   Rzuty: " + nrRzutu.ToString();

            for (int i = 0; i < 5; i++)
            {
                wybrane[i] = false;
                wynikRzutu[i] = 1;
                ileRazy[i] = 0;
                kosciLos[i].Image = Properties.Resources.pusty;
                kosciWyb[i].Image = Properties.Resources.pusty;
                if (i < 4)
                {
                    bonus1[i] = 0; bonus2[i] = 0; bonus3[i] = 0;
                    suma1[i] = 0; suma2[i] = 0;
                    wynik[i] = 0;
                    piatki[i] = 0;
                }
            }
            ileRazy[5] = 0;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0 || i == 7 || i == 8 || i == 16 || i == 17 || i == 18)
                    {
                        wybraneKategorie[j, i] = true;
                    }
                    else
                    {
                        wybraneKategorie[j, i] = false;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (i != 0 && j != 0) tab.Tablica[i, j].Text = "";
                    if (j == 7 || j == 8 || j == 16 || j == 17 || j == 18)
                    {
                        if (i != 0)
                        {
                            tab.Tablica[i, j].Text = "0";
                        }
                    }
                }
            }
        }

        void zakonczGre()
        {
            gra = false;
            nrTury.Text = "Koniec gry !";
            for (int i = 0; i < 5; i++)
            {
                wybrane[i] = false;
                kosciWyb[i].Image = Properties.Resources.pusty;
                kosciLos[i].Image = Properties.Resources.pusty;
            }
        }

        void OknoGlowne_MouseLeave(object sender, EventArgs e)
        {
            if (gra && !kolejnaTura)
            {
                Label pole = new Label();
                pole = (Label)sender;
                int i, j;
                i = ((PozycjaPola)pole.Tag).X;
                j = ((PozycjaPola)pole.Tag).Y;

                if (i == aktualnyGracz && !wybraneKategorie[i - 1, j])
                    tab.Tablica[i, j].Text = "";
            }
        }

        void OknoGlowne_MouseEnter(object sender, EventArgs e)
        {
            if (gra && !kolejnaTura)
            {
                Label pole = new Label();
                pole = (Label)sender;
                int i, j;
                i = ((PozycjaPola)pole.Tag).X;
                j = ((PozycjaPola)pole.Tag).Y;

                if (i == aktualnyGracz && !wybraneKategorie[i - 1, j])
                {
                    obliczPunkty(i, j, 0);
                }
            }
        }

        private void obliczPunkty(int i, int j, int p)
        {
            int punkty = 0;
            int b = 0;
            if (p == 0)
            {
                switch (j)
                {
                    case 1: tab.Tablica[i, j].Text = ileRazy[0].ToString(); break;
                    case 2: tab.Tablica[i, j].Text = (ileRazy[1] * 2).ToString(); break;
                    case 3: tab.Tablica[i, j].Text = (ileRazy[2] * 3).ToString(); break;
                    case 4: tab.Tablica[i, j].Text = (ileRazy[3] * 4).ToString(); break;
                    case 5: tab.Tablica[i, j].Text = (ileRazy[4] * 5).ToString(); break;
                    case 6: tab.Tablica[i, j].Text = (ileRazy[5] * 6).ToString(); break;
                    case 9: if (sprawdzCzyPary())
                        {
                            punkty = 20 + (5 * (3 - nrRzutu));
                            tab.Tablica[i, j].Text = punkty.ToString(); ;
                        }
                        else tab.Tablica[i, j].Text = "0"; break;
                    case 10: if (sprawdzCzyTrojka())
                        {
                            punkty = 25 + (5 * (3 - nrRzutu));
                            tab.Tablica[i, j].Text = punkty.ToString(); ;
                        }
                        else tab.Tablica[i, j].Text = "0"; break;
                    case 11: if (sprawdzCzyCzworka())
                        {
                            punkty = 35 + (5 * (3 - nrRzutu));
                            tab.Tablica[i, j].Text = punkty.ToString(); ;
                        }
                        else tab.Tablica[i, j].Text = "0"; break;
                    case 12: if (sprawdzCzyStrit())
                        {
                            punkty = 30 + (5 * (3 - nrRzutu));
                            tab.Tablica[i, j].Text = punkty.ToString(); ;
                        }
                        else tab.Tablica[i, j].Text = "0"; break;
                    case 13: if (sprawdzCzyFull())
                        {
                            punkty = 30 + (5 * (3 - nrRzutu));
                            tab.Tablica[i, j].Text = punkty.ToString(); ;
                        }
                        else tab.Tablica[i, j].Text = "0"; break;
                    case 14: if (sprawdzCzyPiatka())
                        {
                            punkty = 50 + (5 * (3 - nrRzutu));
                            tab.Tablica[i, j].Text = punkty.ToString(); ;
                        }
                        else tab.Tablica[i, j].Text = "0"; break;
                    case 15: tab.Tablica[i, j].Text = szansa().ToString(); break;
                }
            }
            else
            {
                switch (j)
                {
                    case 1: punkty = ileRazy[0]; b = 1; break;
                    case 2: punkty = ileRazy[1] * 2; b = 1; break;
                    case 3: punkty = ileRazy[2] * 3; b = 1; break;
                    case 4: punkty = ileRazy[3] * 4; b = 1; break;
                    case 5: punkty = ileRazy[4] * 5; b = 1; break;
                    case 6: punkty = ileRazy[5] * 6; b = 1; break;
                    case 9: if (sprawdzCzyPary()) punkty = 20 + (5 * (3 - nrRzutu));
                        else tab.Tablica[i, j].Text = "0"; b = 0; break;
                    case 10: if (sprawdzCzyTrojka()) punkty = 25 + (5 * (3 - nrRzutu));
                        else tab.Tablica[i, j].Text = "0"; b = 0; break;
                    case 11: if (sprawdzCzyCzworka()) punkty = 35 + (5 * (3 - nrRzutu));
                        else tab.Tablica[i, j].Text = "0"; b = 0; break;
                    case 12: if (sprawdzCzyStrit()) punkty = 30 + (5 * (3 - nrRzutu));
                        else tab.Tablica[i, j].Text = "0"; b = 0; break;
                    case 13: if (sprawdzCzyFull()) punkty = 30 + (5 * (3 - nrRzutu));
                        else tab.Tablica[i, j].Text = "0"; b = 0; break;
                    case 14: if (sprawdzCzyPiatka()) punkty = 50 + (5 * (3 - nrRzutu));
                        else tab.Tablica[i, j].Text = "0"; b = 0; break;
                    case 15: punkty = szansa(); b = 0; break;
                }
                if (b == 1) suma1[i - 1] += punkty; else suma2[i - 1] += punkty;
                if (sprawdzCzyBonus1() && bonus1[i - 1] == 0) bonus1[i - 1] = 20;
                if (sprawdzCzyBonus2() && bonus2[i - 1] != 30) bonus2[i - 1] += 30;
                if (sprawdzCzyBonus3()) bonus3[i - 1] += 40;
                policzWynik();
                tab.Tablica[i, 7].Text = suma1[i - 1].ToString();
                tab.Tablica[i, 8].Text = bonus1[i - 1].ToString();
                tab.Tablica[i, 16].Text = suma2[i - 1].ToString();
                tab.Tablica[i, 17].Text = (bonus2[i - 1] + bonus3[i - 1]).ToString();
                tab.Tablica[i, 18].Text = wynik[i - 1].ToString();
                nrRzutu = 4;
            }
        }

        private bool sprawdzCzyBonus1()
        {
            if (suma1[aktualnyGracz - 1] >= 60) return true;
            return false;
        }

        private void policzWynik()
        {
            int i = aktualnyGracz - 1;
            wynik[i] = suma1[i] + suma2[i] + bonus1[i] + bonus2[i] + bonus3[i];
        }

        private bool sprawdzCzyBonus2()
        {
            if (tab.Tablica[1, 9].Text != "" && tab.Tablica[1, 9].Text != "0"
                && tab.Tablica[1, 10].Text != "" && tab.Tablica[1, 10].Text != "0"
                && tab.Tablica[1, 11].Text != "" && tab.Tablica[1, 11].Text != "0"
                && tab.Tablica[1, 12].Text != "" && tab.Tablica[1, 12].Text != "0"
                && tab.Tablica[1, 13].Text != "" && tab.Tablica[1, 13].Text != "0"
                && tab.Tablica[1, 14].Text != "" && tab.Tablica[1, 14].Text != "0"
                && tab.Tablica[1, 15].Text != "" && tab.Tablica[1, 15].Text != "0") 
                return true;
            return false;
        }

        private bool sprawdzCzyBonus3()
        {
            if (sprawdzCzyPiatka() && piatki[aktualnyGracz - 1] > 1) return true;
            return false;
        }

        void tablica_MouseClick(object sender, MouseEventArgs e)
        {
            if (gra && !kolejnaTura)
            {
                if (sprawdzCzyPiatka() && tab.Tablica[aktualnyGracz, 14].Text != "" 
                    && tab.Tablica[aktualnyGracz, 14].Text != "0") piatki[aktualnyGracz - 1]++;
                Label pole = new Label();
                pole = (Label)sender;
                int i, j;
                i = ((PozycjaPola)pole.Tag).X;
                j = ((PozycjaPola)pole.Tag).Y;


                if (i == aktualnyGracz && !wybraneKategorie[i - 1, j])
                {
                    wybraneKategorie[i - 1, j] = true;
                    obliczPunkty(i, j, 1);
                    if (tura == 13) zakonczGre();
                }
                zmienAktualnegoGracza();
                kolejnaTura = true;
            }
        }

        void OknoGlowne_MouseClick(object sender, MouseEventArgs e)
        {
            Label kosc = new Label();
            kosc = (Label)sender;
            int i = (int)kosc.Tag;

            if (!wybrane[i])
            {
                kosciWyb[i].Image = kosciLos[i].Image;
                kosciLos[i].Image = Properties.Resources.pusty;
                wybrane[i] = true;
            }
        }

        void OknoGlowne02_MouseClick(object sender, MouseEventArgs e)
        {
            Label kosc = new Label();
            kosc = (Label)sender;
            int i = (int)kosc.Tag;

            if (wybrane[i])
            {
                kosciLos[i].Image = kosciWyb[i].Image;
                kosciWyb[i].Image = Properties.Resources.pusty;
                wybrane[i] = false;
            }
        }

        void rzut_MouseClick(object sender, MouseEventArgs e)
        {
            kolejnaTura = false;
            if (gra && nrRzutu != 3)
            {
                if (tura < 14 || aktualnyGracz != pierwszyGracz)
                {
                    if (nrRzutu == 4)
                    {
                        nrRzutu = 1;
                        //zmienAktualnegoGracza();
                        if(aktualnyGracz == pierwszyGracz) tura++;
                        for (int i = 0; i < 5; i++)
                        {
                            wybrane[i] = false;
                            kosciWyb[i].Image = Properties.Resources.pusty;
                        }
                        if (tura != 14)
                        {
                            nrTury.Text = "Tura: " + tura.ToString() + "   Rzuty: " + nrRzutu.ToString();
                            wykonajRzut();
                            wyswietlRzut();
                        }
                        else
                        {
                            zakonczGre();
                        }
                    } 
                    else
                    {
                        nrRzutu++;
                        nrTury.Text = "Tura: " + tura.ToString() + "   Rzuty: " + nrRzutu.ToString();
                        wykonajRzut();
                        wyswietlRzut();
                    }                                      
                }
                else
                {
                    zakonczGre();
                }
            }
        }

        private void wykonajRzut()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!wybrane[i])
                {
                    wynikRzutu[i] = losuj.Next(6) + 1;
                }
            }
            zliczPowtorzenia();
        }

        private void wyswietlRzut()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!wybrane[i])
                {
                    switch (wynikRzutu[i])
                    {
                        case 1: kosciLos[i].Image = Properties.Resources.kosci01; break;
                        case 2: kosciLos[i].Image = Properties.Resources.kosci02; break;
                        case 3: kosciLos[i].Image = Properties.Resources.kosci03; break;
                        case 4: kosciLos[i].Image = Properties.Resources.kosci04; break;
                        case 5: kosciLos[i].Image = Properties.Resources.kosci05; break;
                        case 6: kosciLos[i].Image = Properties.Resources.kosci06; break;
                    }
                }
            }
        }

        private void zliczPowtorzenia()
        {
            int l;
            for (int i = 1; i < 7; i++)
            {
                l = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (wynikRzutu[j] == i) l++;
                }
                ileRazy[i - 1] = l;
            }
        }

        private bool sprawdzCzyPary()
        {
            int pary = 0;
            if (sprawdzCzyPiatka()) return true;
            for (int i = 0; i < 6; i++)
            {
                if (ileRazy[i] >= 2)
                {
                    pary++;
                }
                if (pary == 2) return true;
            }
            return false;
        }

        private bool sprawdzCzyTrojka()
        {
            for (int i = 0; i < 6; i++)
            {
                if (ileRazy[i] >= 3) return true;
            }
            return false;
        }

        private bool sprawdzCzyCzworka()
        {
            for (int i = 0; i < 6; i++)
            {
                if (ileRazy[i] >= 4) return true;
            }
            return false;
        }

        private bool sprawdzCzyStrit()
        {
            if (sprawdzCzyPiatka()) return true;
            if (ileRazy[0] == 1 && ileRazy[1] == 1 && ileRazy[2] == 1 &&
                ileRazy[3] == 1 && ileRazy[4] == 1) return true;
            if (ileRazy[5] == 1 && ileRazy[1] == 1 && ileRazy[2] == 1 &&
                ileRazy[3] == 1 && ileRazy[4] == 1) return true;
            return false;
        }

        private bool sprawdzCzyFull()
        {
            int trzy = 0, dwa = 0;
            if (sprawdzCzyPiatka()) return true;
            for (int i = 0; i < 6; i++)
            {
                if (ileRazy[i] == 3) trzy = 1;
                if (ileRazy[i] == 2) dwa = 1;
                if (dwa == 1 && trzy == 1) return true;
            }
            return false;
        }

        private bool sprawdzCzyPiatka()
        {
            for (int i = 0; i < 6; i++)
            {
                if (ileRazy[i] == 5) return true;
            }
            return false;
        }

        private int szansa()
        {
            int suma = 0;
            for (int i = 0; i < 5; i++)
            {
                suma += wynikRzutu[i];
            }
            return suma;
        }
    }



}

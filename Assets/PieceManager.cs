//Karol Mirek 
//Projekt
//Klasa która służy na poprawne ustawienie figur na planszy oraz
//za logikę zmiany stron
// 2018.06.03


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Assets
{
    public class PieceManager : MonoBehaviour
    {
        //pola
        public GameObject Pionek;
        public bool KoniecGry = false;
        private List<Piece> BialeFigury = null;
        private List<Piece> CzarneFigury = null;

        //Tablica zawierająca ustawienie figur
        private string[] op = new string[24]
        {
            "W","Ko","UpB","B","UpK","K","Q","F","B","UpB","Ko","W",
            "M","M","M","M","M","M","M","M","M","M","M","M",
            
        };
        
        
        //Słownik
        private Dictionary<string, Type> Slownik =
            new Dictionary<string, Type>()
        {
            {"W",typeof(Wieza) },
            {"Ko",typeof(Kon)},
            {"UpB",typeof(UpGoniec) },
            {"B",typeof(Goniec) },
            {"UpK",typeof(UpKrol) },
            {"K",typeof(Krol) },
            {"M",typeof(Pionek) },
            {"F",typeof(Klaun) },
            {"Q",typeof(Krolowa) }
        };
        

        //Ustawia figury w miejscu startowym
        public void UstawienieFigur (Board plansza)
        {
            
            BialeFigury = StworzObiekt
                (Color.white, new Color32(80, 124, 159, 255), plansza);
            CzarneFigury = StworzObiekt
                (Color.black, new Color32(30, 255, 0, 255), plansza);
            for (int i = 0; i < 12; i++)
            {
                if (i != 6)
                {
                    if (i != 0 && i!= 11)
                    {
                        BialeFigury[i + 12].Ustaw(plansza.tablica[i, 1]);
                        CzarneFigury[i + 12].Ustaw(plansza.tablica[i, 6]);
                    }
                    BialeFigury[i].Ustaw(plansza.tablica[i, 0]);
                    CzarneFigury[i].Ustaw(plansza.tablica[i, 7]);
                } 
            }

            BialeFigury[12].Ustaw(plansza.tablica[0, 3]);
            CzarneFigury[12].Ustaw(plansza.tablica[0, 4]);
            BialeFigury[23].Ustaw(plansza.tablica[11, 3]);
            CzarneFigury[23].Ustaw(plansza.tablica[11, 4]);
            BialeFigury[6].Ustaw(plansza.tablica[6, 2]);
            CzarneFigury[6].Ustaw(plansza.tablica[6, 5]);
            BialeFigury[18].Ustaw(plansza.tablica[6, 3]);
            CzarneFigury[18].Ustaw(plansza.tablica[6, 4]);


            ZmianaStron(Color.black);
        }
        //Zwraca listę figur 
        private List<Piece> StworzObiekt(Color teamColor,
            Color32 SpriteColor, Board board)
        {
            List<Piece> figury = new List<Piece>();
            for (int i = 0; i < op.Length; i++)
            {
                    //Tworzymy nowy obiekt
                    GameObject nowyobiekt = Instantiate(Pionek);
                    nowyobiekt.transform.SetParent(transform);
                    
                    //skalujemy obiekt
                    nowyobiekt.transform.localScale = new Vector3(1, 1, 1);
                    nowyobiekt.transform.localRotation = Quaternion.identity;
                    //Typ obiektu
                    string klucz = op[i];
                    Type klasa = Slownik[klucz];
                    //Dodajemy do listy
                    Piece nowaFigura = (Piece)nowyobiekt.AddComponent(klasa);
                    figury.Add(nowaFigura);
                    //Konfiguracja
                    nowaFigura.Ustawienie(teamColor, SpriteColor, this);
                
            }

            return figury;
        }
        
        //Aktywuje możliwość ruchu figur odpowiedniego gracza
        private void Aktywne (List<Piece> figury, bool war)
        {
            foreach (Piece piece in figury)
                piece.enabled = war;
        }
        //Zmienia ture gracza
        public void ZmianaStron(Color kolor)
        {
            if(KoniecGry)
                {
                OdNowa();
                KoniecGry = false;
                kolor = Color.black;
                }
            bool isBlackTurn = kolor == Color.white ? true : false;
            Aktywne(BialeFigury, !isBlackTurn);
            Aktywne(CzarneFigury, isBlackTurn);

        }

        //Resetuje grę na początek
        public void OdNowa()
        {
            foreach (Piece piece in BialeFigury)
                piece.Reset();

            foreach (Piece piece in CzarneFigury)
                piece.Reset();

        }
    }
}

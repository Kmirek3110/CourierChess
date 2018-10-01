//Karol Mirek 
//Projekt
// //Klasa odpowiadająca za figurę pionek
// 2018.06.03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class Pionek :Piece
    {
        public override void Ustawienie(Color newTeamColor,
            Color32 newSpriteColor, PieceManager newPieceManager)
        {
            base.Ustawienie(newTeamColor, newSpriteColor, newPieceManager);
            if (Kolor == Color.white)
            {
                ruch = new Vector3Int(0, 1, 1);
            }
            else
                ruch = new Vector3Int(0, -1, -1);
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Pionek");
        }
        //Sprawdzamy stan pól
        private bool Stan(int celX,int celY,StanPola stanCelu)
        {
            StanPola stan = StanPola.Brak;
            stan = Pole.plansza.TestStanu(celX, celY, this);
            if(stan== stanCelu)
            {
                Podswietlane.Add(Pole.plansza.tablica[celX, celY]);
                return true;
            }
            return false;

        }
        //Nadciążona metoda
        protected override void SprawdzSciezke()
        {
            int x = Pole.Pozycja.x;
            int y = Pole.Pozycja.y;
            Stan(x - ruch.z, y + ruch.z, StanPola.Przeciwnik);
            if(Stan(x,y+ruch.y,StanPola.Wolna))
            {
                Stan(x, y + ruch.z , StanPola.Wolna);
            }
            Stan(x + ruch.z, y + ruch.z, StanPola.Przeciwnik);
        }

    }
}

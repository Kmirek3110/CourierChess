//Karol Mirek 
//Projekt
//Klasa odpowiadająca za figurę koń
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
    class Kon : Piece
    {
        //Ustawia wartości klasy
        public override void Ustawienie(Color newTeamColor,
            Color32 newSpriteColor, PieceManager newPieceManager)
        {
            base.Ustawienie(newTeamColor, newSpriteColor, newPieceManager);
            
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Kon");


        }
        private void Sciezka()
        {
            int x = Pole.Pozycja.x;
            int y = Pole.Pozycja.y;
            Test(x + 1, y + 2);
            Test(x - 1, y + 2);
            Test(x + 2, y - 1);
            Test(x + 2, y + 1);
            Test(x - 1, y - 2);
            Test(x + 1, y + 2);
            Test(x - 2, y + 1);
            Test(x - 2, y - 1);
            Test(x + 1, y - 2);

        }
        protected override void SprawdzSciezke()
        {
            Sciezka();
        }
        private void Test(int x, int y)
        {
            StanPola stan = StanPola.Brak;
            stan = Pole.plansza.TestStanu(x, y, this);
            if (stan != StanPola.Sojusznik && stan != StanPola.Zasieg)
                Podswietlane.Add(Pole.plansza.tablica[x, y]);
        }

    }
}

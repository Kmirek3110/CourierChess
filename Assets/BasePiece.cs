//Karol Mirek 
//Projekt
//Abstrakcyjna klasa figura
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
    public abstract class Piece : EventTrigger
    {
        //Pola
        public Color Kolor = Color.clear;

        protected Cell PodstawowePole = null;
        protected Cell Pole = null;

        protected RectTransform mRectTransform = null;
        protected PieceManager ustawienie;

        protected Vector3Int ruch = Vector3Int.one;
        protected List<Cell> Podswietlane = new List<Cell>();

        protected Cell Ruch = null;

        //Ustawia wartość pól
        public virtual void Ustawienie(Color nowykolor,
            Color32 kolorSprite,PieceManager noweUstawienie)
        {
            ustawienie = noweUstawienie;
            Kolor = nowykolor;
            GetComponent<Image>().color = kolorSprite;
            mRectTransform = GetComponent<RectTransform>();
        }

        //Zmienia położenie figury
        public void Ustaw(Cell nowePole)
        {
            Pole = nowePole;
            PodstawowePole = nowePole;
            Pole.pionek = this;
            transform.position = nowePole.transform.position;
            gameObject.SetActive(true);
        }

        //Dodaje do listy pozycje pól na które może przejść
        private void StworzSciezke(int kierunekX,int kierunekY,int ruch)
        {
            int x = Pole.Pozycja.x;
            int y = Pole.Pozycja.y;
             for(int i = 1;i<=ruch;i++)
           {
                x += kierunekX;
                y += kierunekY;
                StanPola cellState = StanPola.Brak;
                cellState = Pole.plansza.TestStanu(x, y, this);
                if(cellState==StanPola.Przeciwnik)
                    Podswietlane.Add(Pole.plansza.tablica[x, y]);
                if (cellState != StanPola.Wolna)
                    break;

                Podswietlane.Add(Pole.plansza.tablica[x, y]);

            }
            
        }

        //Metoda sprawdzająca wszystkie kierunki ruchu
        protected virtual void SprawdzSciezke()
        {
            StworzSciezke(1, 0, ruch.x);
            StworzSciezke(-1, 0, ruch.x);
            StworzSciezke(0, 1, ruch.y);
            StworzSciezke(0,-1, ruch.y);
            StworzSciezke(-1, -1, ruch.z);
            StworzSciezke(1, -1, ruch.z);
            StworzSciezke(-1, 1, ruch.z);
            StworzSciezke(1, 1, ruch.z);
        }
        //"Podświetla" pola z listy 
        protected void PokazDostepne()
        {
            foreach (Cell a in Podswietlane)
            {
                if (a.obraz != null)
                    a.obraz.enabled = false;
            }   
        }
        //Efekt przeciwny do metody PokazDostepne
        protected void  Wyczysc()
        {
            foreach(Cell a in Podswietlane)
                    a.obraz.enabled = true;
            Podswietlane.Clear();
        }
        //Ruch figury
        protected virtual void  Zamiana()
        {

            if (Ruch != null)
                Ruch.UsunPionek();

                Pole.pionek = null;
                Pole = Ruch;

                Pole.pionek = this;

                transform.position = Pole.transform.position;
                Ruch = null;
         
        }

        //Metody interfejsu EventTrigger "Wyzwalacz wydarzeń"
        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            SprawdzSciezke();     
            PokazDostepne();
        }
         public override void OnDrag(PointerEventData eventData)
         {
                    base.OnDrag(eventData);
                    transform.position += (Vector3)eventData.delta;
            foreach(Cell cell in Podswietlane)
            {
                if(RectTransformUtility.RectangleContainsScreenPoint
                    (cell.mRectTransform,Input.mousePosition))
                {
                    Ruch = cell;
                    break;
                }
                Ruch = null;

            }
         }
         public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            
            Wyczysc();
            if(!Ruch)
            {
                transform.position = Pole.gameObject.transform.position;
                return;
            }
            Zamiana();
            ustawienie.ZmianaStron(Kolor);
        }
        //Ustawienie początkowe figur
        public void Reset()
        {
            Zniszcz();
            Ustaw(PodstawowePole);
        }
        //Usuwanie figury z planszy
        public virtual void Zniszcz()
        {
            Pole.pionek = null;
            gameObject.SetActive(false);
        }
    }
}

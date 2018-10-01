//Karol Mirek 
//Projekt
// Klasa "Board" plansza do gry
// 2018.06.03

using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//Posiada dane o wartości pola
public enum StanPola
{
    Brak,
    Sojusznik,
    Przeciwnik,
    Wolna,
    Zasieg

}
public class Board : MonoBehaviour {

    public GameObject Komorka;

    public Cell[,] tablica = new Cell[12, 8];
    
    public void Tworz()
    {
        for(int x = 0; x < 12; x++) 
        {
            for(int y = 0; y < 8; y++)
            {
                //Tworzymy pole
                GameObject zapas = Instantiate(Komorka, transform);
                //Pozycja pola
                RectTransform rectTransform = zapas.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);
                
                tablica[x, y] = zapas.GetComponent<Cell>();
                tablica[x, y].Ustawienie(new Vector2Int(x, y), this);

            }

        }
        //Kolorujemy pola nazmiennie
        for(int x=0;x<12;x+=2)
        {
            for(int y=0;y<8;y++)
            {
                int parzysta;
                if (y % 2 != 0)
                     parzysta = 0;
                else
                     parzysta = 1;
                
                int cos = x + parzysta;
                tablica[cos, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
            }

        }
        
    }

    //Metoda zwracająca Stan pola
    public StanPola TestStanu(int celX, int celY, Piece sprawdzana)
    {
        //Sprawdzamy czy nie wychodzi poza zakres
        if (celX < 0 || celX > 11)
            return StanPola.Zasieg;

        if (celY < 0 || celY > 7)
            return StanPola.Zasieg;

        Cell Sprawdzane = tablica[celX, celY];

        if (Sprawdzane.pionek != null)
        {
            if (sprawdzana.Kolor == Sprawdzane.pionek.Kolor)
                return StanPola.Sojusznik;
            if (sprawdzana.Kolor != Sprawdzane.pionek.Kolor)
                return StanPola.Przeciwnik;
        }
        return StanPola.Wolna;
    }


}

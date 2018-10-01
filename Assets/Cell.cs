//Karol Mirek 
//Projekt
// Klasa "Cell" Pole
// 2018.06.03

using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell: MonoBehaviour {

    //Pola
    public Image obraz;
    public Vector2Int Pozycja = Vector2Int.zero;
    public Board plansza = null;
    public RectTransform mRectTransform = null;
    public Piece pionek = null;


    //Ustawia wartość pól
    public void Ustawienie(Vector2Int nowaPozycja,Board nowaPlansza)
    {
        Pozycja = nowaPozycja;
        plansza = nowaPlansza;
        mRectTransform = GetComponent<RectTransform>();
    }

    public void UsunPionek()
    {
        if (pionek != null)
            pionek.Zniszcz ();
    }

}

//Karol Mirek 
//Projekt
// Klasa która służy do rozpoczęcia gry
// 2018.06.03
using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Board plansza;
    public PieceManager ustawienie;

	

    //Metoda rozpoczynająca rozgrywkę
	void Start () {
        
            plansza.Tworz();
            ustawienie.UstawienieFigur(plansza);
        
	    }
	
}

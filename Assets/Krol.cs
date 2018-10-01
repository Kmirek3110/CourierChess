﻿//Karol Mirek 
//Projekt
//Klasa odpowiadająca za figurę król
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
    class Krol:Piece
    //Ustawia wartości klasy
    {
        public override void Ustawienie(Color newTeamColor,
            Color32 newSpriteColor, PieceManager newPieceManager)
        {
            base.Ustawienie(newTeamColor, newSpriteColor, newPieceManager);
            ruch = new Vector3Int(1, 1, 1);
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Krol");
        }
        public override void Zniszcz()
        {
            base.Zniszcz();
            ustawienie.KoniecGry = true;

        }
    }
}

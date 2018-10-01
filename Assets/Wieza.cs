//Karol Mirek 
//Projekt
//Klasa odpowiadająca za figurę wieża
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
    class Wieza :Piece
    {
        //Ustawia wartości klasy
        public override void Ustawienie
            (Color newTeamColor, Color32 newSpriteColor, 
            PieceManager newPieceManager)
        {
            base.Ustawienie(newTeamColor, newSpriteColor, newPieceManager);

            ruch = new Vector3Int(11, 7, 0);
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Wieza");
        }

    }
}

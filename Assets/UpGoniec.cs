//Karol Mirek 
//Projekt
///Klasa odpowiadająca za figurę odwrotnego gońca
// 2018.06.03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    //Ustawia wartości klasy
    class UpGoniec :Piece
    {
        public override void Ustawienie(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
        {
            base.Ustawienie(newTeamColor, newSpriteColor, newPieceManager);

            ruch = new Vector3Int(0, 0, 2);
            GetComponent<Image>().sprite = Resources.Load<Sprite>("UpGoniec");
        }
    }
}

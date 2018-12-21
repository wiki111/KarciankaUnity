using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Actions/Battle Phase Start Check")]
public class BattlePhaseStartCheck : Condition
{
    public override bool IsValid()
    {
        bool isValid = false;
        GameManager gm = GameManager.singleton;

        if(gm.currentPlayer.cardsOnTable.Count > 0)
        {
            isValid = true;
        }

        return isValid;
    }
}

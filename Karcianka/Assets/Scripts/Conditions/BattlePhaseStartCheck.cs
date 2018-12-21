using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Actions/Battle Phase Start Check")]
public class BattlePhaseStartCheck : Condition
{
    public override bool IsValid()
    {
        bool isValid = false;
        GameManager gm = GameManager.singleton;
        PlayerHolder playerHolder = gm.currentPlayer;
        int count = gm.currentPlayer.cardsOnTable.Count;

        for (int i = 0; i < playerHolder.cardsOnTable.Count; i++)
        {
            if (playerHolder.cardsOnTable[i].isFlatfooted)
            {
                count--;
            }
        }
        
        if(count > 0)
        {
            isValid = true;
        }

        return isValid;
    }
}

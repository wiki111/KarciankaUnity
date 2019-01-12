using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Actions/Reset flatfooted")]
public class ResetFlatFootedCards : PlayerAction
{
    public override void Execute(PlayerHolder playerHolder)
    {
        foreach (CardInstance card in playerHolder.cardsOnTable)
        {
            if (card.isFlatfooted)
            {
                card.SetFlatfooted(false);
            }
        }
    }
}

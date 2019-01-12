using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Battle Resolve Phase")]
public class BattleResolvePhase : Phase
{
    public Element attackElement;
    public Element defenceElement;

    public override bool IsComplete()
    {
        PlayerHolder playerHolder = Settings.gameManager.currentPlayer;
        PlayerHolder enemyPlayerHolder = Settings.gameManager.GetEnemyOf(playerHolder);
        if (playerHolder.attackingCards.Count == 0)
        {
            return true;
        }

        for (int i = 0; i < playerHolder.attackingCards.Count; i++)
        {
            CardInstance cardInst = playerHolder.attackingCards[i];
            Card card = cardInst.viz.card;
            CardProperties attackProperty = card.GetProperty(attackElement);
            if (attackProperty == null)
            {
                Debug.LogError("You are attacking with a card that cant attack");
                continue;
            }

            playerHolder.DropCard(cardInst, false);
            playerHolder.currentHolders.SetCardDown(cardInst);
            cardInst.SetFlatfooted(true);
            enemyPlayerHolder.DoDamage(attackProperty.intVal);
        }

        playerHolder.attackingCards.Clear();

        return true;
    }

    public override void OnEndPhase()
    {
    }

    public override void OnStartPhase()
    {
        
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Actions/Select Cards To Attack")]
public class SelectCardsToAttack : Action
{
    public override void Execute(float d)
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = Settings.GetUIObjects();
            
            foreach (RaycastResult result in results)
            {
                CardInstance cardInst = result.gameObject.GetComponentInParent<CardInstance>();
                PlayerHolder player = Settings.gameManager.currentPlayer;
                if (player.cardsOnTable.Contains(cardInst))
                {
                    if (cardInst.CanAttack())
                    {
                        player.attackingCards.Add(cardInst);
                        player.currentHolders.SetCardOnBattleLine(cardInst);
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}

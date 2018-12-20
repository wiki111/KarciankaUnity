using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game Elements/Hand Card" )]
public class HandCard : GE_Logic
{
    public CardVariable currentCard;
    public SO.GameEvent onSelectCard;
    public State holdingCard;

    public override void OnClick(CardInstance cardInstance)
    {
        Debug.Log("This card is on hand and it was clicked");
        currentCard.Set(cardInstance);
        Settings.gameManager.SetState(holdingCard);
        onSelectCard.Raise();
    }

    public override void OnHighlight(CardInstance cardInstance)
    {
        Debug.Log("This card is on hand and it was highlighted");
    }
}

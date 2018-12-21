using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName ="Areas/DropAreaWhenHoldingCard")]
public class DropAreaLogic : AreaLogic
{
    public CardVariable card;
    public CardType creatureType;
    public CardType resourceType;
    public SO.TransformVariable areaGrid;
    public SO.TransformVariable resourcesGrid;
    public GE_Logic cardDownLogic;
    
    public override void Execute()
    {
        if (card.Get() == null)
            return;

        if(card.Get().viz.card.cardType == creatureType)
        {
            Debug.Log("Place card down on the table.");
            bool canUse = Settings.gameManager.currentPlayer.CanUseCard(card.Get().viz.card);
            if (canUse)
            {
                Settings.DropCreatureCard(card.Get().transform, areaGrid.value.transform, card.Get());
                card.Get().currentLogic = cardDownLogic;
            }
            card.Get().gameObject.SetActive(true);
        }

        if(card.Get().viz.card.cardType == resourceType)
        {
            bool canUse = Settings.gameManager.currentPlayer.CanUseCard(card.Get().viz.card);
            if (canUse)
            {
                Settings.SetParentForCard(card.Get().transform, resourcesGrid.value.transform);
                Settings.gameManager.currentPlayer.AddResourceCard(card.Get().gameObject);
                card.Get().currentLogic = cardDownLogic;
                Settings.RegisterEvent( Settings.gameManager.currentPlayer.username + " dropped resources card " + card.Get().viz.card.name, Settings.gameManager.currentPlayer.playerColor);
            }
            card.Get().gameObject.SetActive(true);
        }
    }
}
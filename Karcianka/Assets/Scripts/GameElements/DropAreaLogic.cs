using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName ="Areas/DropAreaWhenHoldingCard")]
public class DropAreaLogic : AreaLogic
{
    public CardVariable card;
    public CardType creatureType;
    public SO.TransformVariable areaGrid;
    public GE_Logic cardDownLogic;
    public override void Execute()
    {
        if (card.Get() == null)
            return;

        if(card.Get().viz.card.cardType == creatureType)
        {
            Debug.Log("Place card down on the table.");
            Settings.SetParentForCard(card.Get().transform, areaGrid.value.transform);
            card.Get().gameObject.SetActive(true);
            card.Get().currentLogic = cardDownLogic;
        }
    }
}
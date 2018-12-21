using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Holders/Card Holder")]
public class CardHolders : ScriptableObject
{
    public SO.TransformVariable handGrid;
    public SO.TransformVariable tableGrid;
    public SO.TransformVariable resourcesGrid;

    public void LoadPlayer(PlayerHolder playerHolder)
    {
        foreach (CardInstance cardInstance in playerHolder.cardsOnTable)
        {
            Settings.SetParentForCard(cardInstance.viz.gameObject.transform, tableGrid.value.transform);
        }

        foreach (CardInstance cardInstance in playerHolder.cardsOnHand)
        {
            Settings.SetParentForCard(cardInstance.viz.gameObject.transform, handGrid.value.transform);
        }

        foreach (ResourceHolder cardInstance in playerHolder.resourcesList)
        {
            Settings.SetParentForCard(cardInstance.cardObject.transform, resourcesGrid.value.transform);
        }
    }
}

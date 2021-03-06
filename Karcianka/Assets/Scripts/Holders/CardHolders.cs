﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Holders/Card Holder")]
public class CardHolders : ScriptableObject
{
    public SO.TransformVariable handGrid;
    public SO.TransformVariable tableGrid;
    public SO.TransformVariable resourcesGrid;
    public SO.TransformVariable battleLine;

    [System.NonSerialized]
    public PlayerHolder playerHolder;

    public void SetCardOnBattleLine(CardInstance cardInst)
    {
        Vector3 position = cardInst.viz.gameObject.transform.position;
        Settings.SetParentForCard(cardInst.viz.gameObject.transform, battleLine.value.transform);
        position.z = cardInst.viz.gameObject.transform.position.z;
        position.y = cardInst.viz.gameObject.transform.position.y;
        cardInst.viz.gameObject.transform.position = position;
    }

    public void SetCardDown(CardInstance cardInst)
    {
        Settings.SetParentForCard(cardInst.viz.gameObject.transform, tableGrid.value.transform);
    }

    public void LoadPlayer(PlayerHolder playerHolder, PlayerStats stats)
    {
        this.playerHolder = playerHolder;

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

        playerHolder.playerStats = stats;
        playerHolder.LoadPlayerOnStats();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Holders/Player Holder")]
public class PlayerHolder : ScriptableObject {
    public string[] startingCards;
    [System.NonSerialized]
    public List<CardInstance> cardsOnHand = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsOnTable = new List<CardInstance>();
    [System.NonSerialized]
    public List<ResourceHolder> resourcesList = new List<ResourceHolder>();
    [System.NonSerialized]
    public CardHolders currentHolders;
    [System.NonSerialized]
    public int resourcesDroppedInCurrentTurn;
    [System.NonSerialized]
    public List<CardInstance> attackingCards = new List<CardInstance>();
    public bool isHumanPlayer;
    public Color playerColor;

    public GE_Logic handLogic;
    public GE_Logic tableLogic;
    public string username;
    public int resourcesCount
    {
        get { return currentHolders.resourcesGrid.value.GetComponentsInChildren<CardViz>().Length; }
    }
    
    public int resourcesPerTurn = 1;
    


    public void AddResourceCard(GameObject cardObject)
    {
        ResourceHolder resourceHolder = new ResourceHolder();
        resourceHolder.cardObject = cardObject;
        resourcesList.Add(resourceHolder);
    }

    public void DropCard(CardInstance inst)
    {
        if (cardsOnHand.Contains(inst))
        {
            cardsOnHand.Remove(inst);
        }

        cardsOnTable.Add(inst);

        Settings.RegisterEvent(username + " used card " + inst.viz.card.name + " for " + inst.viz.card.cost, playerColor);
    }

    public int NonUsedCards()
    {
        int result = 0;
        for (int i = 0; i < resourcesList.Count; i++)
        {
            if (!resourcesList[i].isTapped)
            {
                result++;
            }
        }
        return result;
    }
    public bool CanUseCard(Card card)
    {
        bool result = false;
        if (card.cardType is CreatureCard || card.cardType is SpellCard)
        {
            int currentResources = NonUsedCards();
            if (card.cost <= currentResources)
            {
                result = true;
            }
        }
        
        if(card.cardType is ResourceCard)
        {
            if(resourcesDroppedInCurrentTurn < resourcesPerTurn)
            {
                resourcesDroppedInCurrentTurn++;
                result = true;
            }
        }
        
        return result;
    }

    public void UseResourcesCards(int amount)
    {
        List<ResourceHolder> unusedResourcesList = GetUnusedResources();
        if (amount <= unusedResourcesList.Count)
        {
            for (int i = 0; i < amount; i++)
            {
                    unusedResourcesList[i].isTapped = true;
                    Vector3 euler = new Vector3(0, 0, 90);
                    unusedResourcesList[i].cardObject.transform.localEulerAngles = euler;
            }
        }
    }

    public List<ResourceHolder> GetUnusedResources()
    {
        List<ResourceHolder> result = new List<ResourceHolder>();
        for (int i = 0; i < resourcesList.Count; i++)
        {
            if (!resourcesList[i].isTapped)
            {
                result.Add(resourcesList[i]);
            }
        }
        return result;
    }

    public void MakeAllResourcesUsable()
    {
        for (int i = 0; i < resourcesList.Count; i++)
        {
            resourcesList[i].isTapped = false;
            Vector3 euler = new Vector3(0, 0, 0);
            resourcesList[i].cardObject.transform.localEulerAngles = euler;
        }
        resourcesDroppedInCurrentTurn = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mangers/Resource Manager")]
public class ResourcesManager : ScriptableObject{
    public Element typeElement;
    public Card[] allCards;
    Dictionary<string, Card> cardsDict = new Dictionary<string, Card>();

    public void Init()
    {
        cardsDict.Clear();
        for (int i = 0; i < allCards.Length; i++)
        {
            cardsDict.Add(allCards[i].name, allCards[i]);
        }
    }

    private Card GetCard(string id)
    {
        Card result = null;
        cardsDict.TryGetValue(id, out result);
        return result;
    }

    public Card GetCardInstance(string id)
    {
        Card originalCard = GetCard(id);
        if (originalCard == null)
            return null;

        Card newInstance = Instantiate(originalCard);
        newInstance.name = originalCard.name;
        return newInstance;
    }
}

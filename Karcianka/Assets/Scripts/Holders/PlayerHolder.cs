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
    public SO.TransformVariable handGrid;
    public SO.TransformVariable tableGrid;
    public GE_Logic handLogic;
    public GE_Logic tableLogic;
}

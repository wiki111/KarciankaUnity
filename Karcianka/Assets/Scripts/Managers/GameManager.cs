using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public State currentState;
    public PlayerHolder currentPlayer;
    public GameObject cardPrefab;

    private void Start()
    {
        Settings.gameManager = this;
        CreateStartingCards();
    }

    private void Update()
    {
        currentState.Tick(Time.deltaTime);
    }

    public void SetState(State state)
    {
        currentState = state;
    }

    void CreateStartingCards()
    {
        //Deck loader
        ResourcesManager rm = Settings.GetResourcesManager();
        for (int i = 0; i < currentPlayer.startingCards.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab) as GameObject;
            CardViz v = go.GetComponent<CardViz>();
            v.LoadCard(rm.GetCardInstance(currentPlayer.startingCards[i]));
            CardInstance instance = go.GetComponent<CardInstance>();
            instance.currentLogic = currentPlayer.handLogic;
            Settings.SetParentForCard(go.transform, currentPlayer.handGrid.value.transform);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public State currentState;
    public PlayerHolder currentPlayer;
    [System.NonSerialized]
    public PlayerHolder[] all_players;
    public GameObject cardPrefab;
    public Turn[] turns;
    public int turnIndex;
    public SO.GameEvent onTurnChanged;
    public SO.GameEvent onPhaseChanged;
    public SO.StringVariable turnText;
    public CardHolders playerOneHolder;
    public CardHolders playerTwoHolder;
    public bool switchPlayer;

    public static GameManager singleton;

    private void Awake()
    {
        singleton = this;
        all_players = new PlayerHolder[turns.Length];
        for (int i = 0; i < turns.Length; i++)
        {
            all_players[i] = turns[i].player;
        }
    }

    private void Start()
    {
        Settings.gameManager = this;
        SetupPlayers();
        CreateStartingCards();
        turnText.value = turns[turnIndex].player.username;
        onTurnChanged.Raise();
    }

    private void Update()
    {
        if (switchPlayer)
        {
            switchPlayer = false;
            playerOneHolder.LoadPlayer(all_players[1]);
            currentPlayer = all_players[1];
            playerTwoHolder.LoadPlayer(all_players[0]);
        }

        bool isComplete = turns[turnIndex].Execute();
        if (isComplete)
        {
            turnIndex++;
            if(turnIndex > turns.Length - 1)
            {
                turnIndex = 0;
            }

            currentPlayer = turns[turnIndex].player;
            //The current player has changed here (?)
            turns[turnIndex].OnTurnStart();
            turnText.value = turns[turnIndex].player.username;
            onTurnChanged.Raise();
        }
        if(currentState != null)
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
        for (int j = 0; j < all_players.Length; j++)
        {
            for (int i = 0; i < all_players[j].startingCards.Length; i++)
            {
                GameObject go = Instantiate(cardPrefab) as GameObject;
                CardViz v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance(all_players[j].startingCards[i]));
                CardInstance instance = go.GetComponent<CardInstance>();
                instance.currentLogic = all_players[j].handLogic;
                Settings.SetParentForCard(go.transform, all_players[j].currentHolders.handGrid.value.transform);
                all_players[j].cardsOnHand.Add(instance);
            }
            Settings.RegisterEvent("Created cards for player " + all_players[j].username, Color.cyan);
        }
    }

    public void EndCurrentPhase()
    {
        Settings.RegisterEvent(turns[turnIndex].name + " is ending. ", Color.cyan );
        turns[turnIndex].EndCurrentPhase();
    }

    void SetupPlayers()
    {
        foreach(PlayerHolder player in all_players)
        {
            if (player.isHumanPlayer)
            {
                player.currentHolders = playerOneHolder;
            }
            else
            {
                player.currentHolders = playerTwoHolder;
            }
        }
    }

    
}

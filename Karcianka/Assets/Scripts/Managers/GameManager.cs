using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public State current;

    private void Start()
    {
        Settings.gameManager = this;
    }

    private void Update()
    {
        current.Tick(Time.deltaTime);
    }

    public void SetState(State state)
    {
        current = state;
    }
}

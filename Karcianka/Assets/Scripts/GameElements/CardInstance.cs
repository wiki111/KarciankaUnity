using UnityEngine;
using System.Collections;

public class CardInstance : MonoBehaviour, IClickable
{
    public GE_Logic currentLogic;
    public CardViz viz;

    void Start()
    {
        viz = GetComponent<CardViz>();
    }

    public void OnClick()
    {
        if (currentLogic == null)
            return;

        currentLogic.OnClick(this);
    }

    public void OnHighlight()
    {
        if (currentLogic == null)
            return;

        currentLogic.OnHighlight(this);
    }
}

using UnityEngine;
using System.Collections;

public class CardInstance : MonoBehaviour, IClickable
{
    public GE_Logic currentLogic;
    public CardViz viz;
    public bool isFlatfooted;

    public void SetFlatfooted(bool isFlat)
    {
        isFlatfooted = isFlat;
        if (isFlatfooted)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
            Debug.Log("Card was flatfooted !");
        }
        else
        {
            transform.localEulerAngles = new Vector3(0,0,0);
        }
        
    }

    void Start()
    {
        viz = GetComponent<CardViz>();
    }

    public bool CanAttack()
    {
        bool result = true;

        if (isFlatfooted)
        {
            result = false;
        }

        if (viz.card.cardType.TypeAllowsForAttack(this))
        {
            result = true;
        }

        return result;
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

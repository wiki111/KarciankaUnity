using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour {

    public CardVariable currentCard;
    public CardViz cardViz;

    private Transform mTransform;

    public void LoadCard()
    {
        if (currentCard.Get() == null)
            return;

        currentCard.Get().gameObject.SetActive(false);
        cardViz.LoadCard(currentCard.Get().viz.card);
        cardViz.gameObject.SetActive(true);
    }

    public void CloseCard()
    {
        cardViz.gameObject.SetActive(false);
    }

    private void Start()
    {
        this.mTransform = this.transform;
        CloseCard();
    }

    // Update is called once per frame
    void Update () {
        mTransform.position = Input.mousePosition;
	}
}

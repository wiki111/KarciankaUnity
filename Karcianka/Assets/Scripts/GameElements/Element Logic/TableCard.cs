using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game Elements/Table Card")]
public class TableCard : GE_Logic
{
    public override void OnClick(CardInstance cardInstance)
    {
        Debug.Log("This card is on table and it was clicked");
    }

    public override void OnHighlight(CardInstance cardInstance)
    {
        Debug.Log("This card is on table and it was highlighted");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Variables/Card Variable")]
public class CardVariable : ScriptableObject {
    private CardInstance value;

    public void Set(CardInstance cardInstance)
    {
        this.value = cardInstance;
    }

    public CardInstance Get()
    {
        return this.value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Settings {

    public static GameManager gameManager;
    private static ResourcesManager _resourcesManager;
    private static ConsoleHook _consoleHook;

    public static void RegisterEvent(string s, Color color = default(Color))
    {
        if(_consoleHook == null)
        {
            _consoleHook = Resources.Load("ConsoleHook") as ConsoleHook;
        }

        _consoleHook.RegisterEvent(s, color);
    }

    public static ResourcesManager GetResourcesManager()
    {
        if(_resourcesManager == null)
        {
            _resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
            _resourcesManager.Init();
        }

        return _resourcesManager;
    }

    public static List<RaycastResult> GetUIObjects()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        return results;
    }

    public static void SetParentForCard(Transform cardTransform, Transform parentTransform)
    {
        cardTransform.SetParent(parentTransform);
        cardTransform.localPosition = Vector3.zero;
        cardTransform.localEulerAngles = Vector3.zero;
        cardTransform.localScale = Vector3.one;
    }

    public static void DropCreatureCard(Transform cardTransform, Transform parentTransform, CardInstance cardInst)
    {
        cardInst.isFlatfooted = true;
        //Any special card on drop abilities
        SetParentForCard(cardTransform, parentTransform);
        if(cardInst.isFlatfooted)
        {
            cardTransform.localEulerAngles = new Vector3(0, 0, 90);
        }
        gameManager.currentPlayer.UseResourcesCards(cardInst.viz.card.cost);
        gameManager.currentPlayer.DropCard(cardInst);
    }
	
}

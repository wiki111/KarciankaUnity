using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Settings {

    public static GameManager gameManager;
    private static ResourcesManager _resourcesManager;

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
	
}

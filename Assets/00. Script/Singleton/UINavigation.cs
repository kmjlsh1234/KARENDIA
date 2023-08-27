using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigation : SingletonBase<UINavigation>
{
    [SerializeField] private Dictionary<UIType.PopupName, GameObject> _UIDictionary = new Dictionary<UIType.PopupName, GameObject>();
    

    void Start()
    {
        UIView[] uiViews = FindObjectsOfType<UIView>();
        foreach (UIView viewItems in uiViews)
        {
            _UIDictionary.Add(viewItems.popupName, viewItems.gameObject);
        }
    }
    public void Push(UIType.PopupName popupName)
    {

        if (_UIDictionary.ContainsKey(popupName))
        {
            GameObject viewObject = _UIDictionary[popupName];
            viewObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            viewObject.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("UITypeError : " + popupName);
        }
    }
    public void Pull(UIType.PopupName popupName)
    {
        if (_UIDictionary.ContainsKey(popupName))
        {
            GameObject viewObject = _UIDictionary[popupName];
            viewObject.gameObject.SetActive(false);
            Debug.Log(viewObject.name);
        }
        else
        {
            Debug.LogWarning("UITypeError : " + popupName);
        }

    }
}

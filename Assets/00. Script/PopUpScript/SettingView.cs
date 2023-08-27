using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SettingView : UIView
{

    

    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        _buttonList[1].onClick.AddListener(() => UINavigation.Instance.Push(UIType.PopupName.OSTView));
        _backButton.onClick.AddListener(() => PlayfabManager.Instance.SetUserData());
        
    }
}

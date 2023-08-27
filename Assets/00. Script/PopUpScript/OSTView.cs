using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OSTView : UIView
{
    //[SerializeField] private Button[] _ostBtn;
    override public void Awake()
    {
        base.Awake();
        _buttonList[0].onClick.AddListener(() => SetData(0));
        _buttonList[1].onClick.AddListener(() => SetData(1));
        _buttonList[2].onClick.AddListener(() => SetData(2));
        _buttonList[3].onClick.AddListener(() => SetData(3));
    }
    
    void SetData(int num)
    {
        DataHandler.Instance.userData.curBGM = num;
        SoundManager.Instance.PlayBGM(num.ToString() + "_BGM");
    }
}

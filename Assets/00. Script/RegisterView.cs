using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RegisterView : UIView
{
    [SerializeField] private TMP_Text inputText;
    [SerializeField] private Button _acceptBtn;
    // Start is called before the first frame update

    override public void Awake()
    {
        _acceptBtn.onClick.AddListener(() => PlayfabManager.Instance.Register(inputText.text));
    }

}

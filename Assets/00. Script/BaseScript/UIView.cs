using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIView : MonoBehaviour
{
    public UIType.PopupName popupName;
    [SerializeField] public Button[] _buttonList;
    public Button _backButton;
    
    // Start is called before the first frame update
    public virtual void Awake()
    {
        for(int i=0; i<_buttonList.Length; i++)
        {
            _buttonList[i].onClick.AddListener(() => SoundManager.Instance.PlaySound("TouchSound"));
        }
        if(_backButton !=null)
        {
            _backButton.onClick.AddListener(() => UINavigation.Instance.Pull(popupName));
            _backButton.onClick.AddListener(() => SoundManager.Instance.PlaySound("TouchSound"));
        }
            
    }
}

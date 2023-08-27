using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ProfileView : UIView
{
    [SerializeField] private TMP_Text _userNameText;
    [SerializeField] private TMP_Text _staminaText;
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _karendiaText;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        /*
        _userNameText.text = DataHandler.Instance.userData.userName;
        _staminaText.text = DataHandler.Instance.userData.stamina + " / 200";
        _goldText.text = DataHandler.Instance.userData.gold.ToString();
        _karendiaText.text = DataHandler.Instance.userData.karendia.ToString();
        */
    }

}

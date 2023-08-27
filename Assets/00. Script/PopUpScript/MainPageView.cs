using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MainPageView : UIView
{
    [SerializeField] private Transform _objectRig;

    private float rotationSpeed = 5f;
    private float mouseX;
    private bool isRotating;

    private void OnEnable()
    {
        View();
    }
    void View()
    {       
        _buttonList[0].onClick.AddListener(() => OnClick_MapView());
        _buttonList[1].onClick.AddListener(() => OnClick_StoryBtn());
        _buttonList[2].onClick.AddListener(() => OnClick_AlbumBtn());
        _buttonList[3].onClick.AddListener(() => OnClick_BlessingBtn());
        _buttonList[4].onClick.AddListener(() => UINavigation.Instance.Push(UIType.PopupName.SettingView));
        SoundManager.Instance.PlayBGM(DataHandler.Instance.userData.curBGM.ToString() + "_BGM");
        _objectRig.localEulerAngles = Vector3.zero;
        isRotating = false;
    }

    public void OnClick_MapView()
    {
        UINavigation.Instance.Push(UIType.PopupName.MapView);
    }

    void OnClick_StoryBtn()
    {
        Debug.Log("StroyBtn Click");
    }

    void OnClick_AlbumBtn()
    {
        Debug.Log("AlbumBtn Click");
    }

    void OnClick_BlessingBtn()
    {
        Debug.Log("BlessingBtn Click");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            mouseX = Input.GetAxis("Mouse X");
            _objectRig.Rotate(Vector3.down, mouseX * rotationSpeed);
        }
    }

    
}

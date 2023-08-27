using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingManager : SingletonBase<LoadingManager>
{
    private GameObject loadingPanel;
    private bool isComplete;
    public void LoadingPanelActivate()
    {
        if(loadingPanel ==null)
            loadingPanel = GameObject.FindGameObjectWithTag("LoadingPanel");


        if (!isComplete)
        {
            isComplete = true;
            loadingPanel.transform.GetChild(0).gameObject.SetActive(true);
            loadingPanel.GetComponent<Image>().raycastTarget = true;
            loadingPanel.GetComponent<Image>().color = new Color(0f,0f,0f,0.8f);
        }
        else
        {
            isComplete = false;
            loadingPanel.transform.GetChild(0).gameObject.SetActive(false);
            loadingPanel.GetComponent<Image>().raycastTarget = false;
            loadingPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        }
    }
}

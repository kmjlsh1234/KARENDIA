using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapView : UIView
{
    [SerializeField] private GameObject MapItem;
    [SerializeField] RectTransform _contentViewRect;

    override public void Awake()
    {
        base.Awake();
        //SetDataAndView();
    }

    private void OnEnable()
    {
        SetDataAndView();
    }
    void SetDataAndView()
    {
        GameObject[] mapItem = new GameObject[20];
        for (int i=0;i<20;i++)
        {
            
            mapItem[i] = Instantiate(MapItem, _contentViewRect);
            mapItem[i].transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DataHandler.Instance.userData.mapInfo[i].mapName;
            mapItem[i].transform.GetChild(0).GetComponent<MapItem>().num = i;
            if (DataHandler.Instance.userData.mapInfo[i].isClear)
                mapItem[i].transform.GetChild(0).GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
}

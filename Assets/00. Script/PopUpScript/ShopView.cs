using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopView : UIView
{
    private int curShopNum = 0;
    [SerializeField] private GameObject[] scrollViewObj;
    [SerializeField] private GameObject ShopItem_Prefab;
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
    }

    void OnEnable()
    {
        curShopNum = 0;
    }
}

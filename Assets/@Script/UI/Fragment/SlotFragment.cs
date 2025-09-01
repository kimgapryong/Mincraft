using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFragment : UI_Base
{
    public Define.Item item;
    private MainCanvas main;
    enum Images
    {
        Select,
        ItemImage,
    }

    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        GetImage((int)Images.Select).gameObject.SetActive(false);
        GetImage((int)Images.ItemImage).gameObject.SetActive(false);
        BindEvent(gameObject, ChagenSelect);

        return true;
    }
    public void SetInfo(MainCanvas main)
    {
        BindImage(typeof(Images));
        this.main = main;
    }

    public void SelectOn()
    {
        GetImage((int)Images.Select).gameObject.SetActive(true);
    }
    public void SelectOff()
    {
        GetImage((int)Images.Select).gameObject.SetActive(false);
    }

    public void ChagenSelect()
    {
        foreach(var slot in main._slot)
            slot.SelectOff();

        if(GetImage((int)Images.Select).gameObject.activeSelf == false)
            SelectOn();
       
        Manager.Input.curItem = item;
    }

    public void Refresh()
    {
        Item_Base curItem;
        Debug.Log($"{transform.name} + {Manager.Item._itemDic.TryGetValue(item, out curItem)}");
        if(Manager.Item._itemDic.TryGetValue(item, out curItem) == false)
            return;

        ItemData data = curItem._data;
        Debug.Log(GetImage((int)Images.ItemImage).gameObject);
        GetImage((int)Images.ItemImage).sprite = data.Image;
        GetImage((int)Images.ItemImage).gameObject.SetActive(true);
        Debug.Log(data);
    }
}

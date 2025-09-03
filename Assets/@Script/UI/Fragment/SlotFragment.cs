using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotFragment : UI_Base
{
    public Image selectImage;
    public Define.Item item;
    private MainCanvas main;
    private Item_Base myItem;
    enum Images
    {
        Select,
        ItemImage,
    }

    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        selectImage = GetImage((int)Images.Select);
        GetImage((int)Images.Select).gameObject.SetActive(false);
        //GetImage((int)Images.ItemImage).gameObject.SetActive(false);
        BindEvent(gameObject, ChagenSelect);

        myItem = Manager.Item.GetItem(item);
        return true;
    }
    public void SetInfo(MainCanvas main)
    {
        BindImage(typeof(Images));
        this.main = main;
    }

    public void SelectOn()
    {
        if(myItem != null)
            myItem.gameObject.SetActive(true);
        GetImage((int)Images.Select).gameObject.SetActive(true);
    }
    public void SelectOff()
    {
        if (myItem != null)
            myItem.gameObject.SetActive(false);
        GetImage((int)Images.Select).gameObject.SetActive(false);
    }

    public void ChagenSelect()
    {
        foreach (var slot in main._slot)
            if (slot != this) slot.SelectOff();


        if(selectImage.gameObject.activeSelf == false)
        {
            SelectOn();
            Manager.Input.curItem = item;
        }
        else
        {
            SelectOff();
            Manager.Input.curItem = Define.Item.None;
        }
        
    }

    public void Refresh()
    {
        Item_Base curItem;
        if(Manager.Item._itemDic.TryGetValue(item, out curItem) == false)
            return;

        ItemData data = curItem._data;
        Debug.Log(GetImage((int)Images.ItemImage).gameObject);
        GetImage((int)Images.ItemImage).sprite = data.Image;
        GetImage((int)Images.ItemImage).gameObject.SetActive(true);
        Debug.Log(data);
    }
}

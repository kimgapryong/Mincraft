using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketPop : UI_Pop
{
    enum Objects
    {
        Content,
        Panel
    }
    enum Buttons
    {
        International_Btn,
        Sell_Btn,
        Buy_Btn,
    }
    public List<ItemData> dataList = new List<ItemData>();
    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        BindButton(typeof(Buttons));
        BindObject(typeof(Objects));

        BindEvent(GetObject((int)Objects.Panel).gameObject, ClosePopupUI);
        BindEvent(GetButton((int)Buttons.Buy_Btn).gameObject, BuyBtnAction);

        BuyBtnAction();
        return true;
    }
   
    private void BuyBtnAction()
    {
        GetButton((int)Buttons.Buy_Btn).image.color = Color.yellow;
        GetButton((int)Buttons.International_Btn).image.color = Color.gray;
        GetButton((int)Buttons.Sell_Btn).image.color = Color.gray;

        foreach(ItemData data in dataList)
        {
            Debug.Log(data);
            Manager.UI.MakeSubItem<BuyFragment>(GetObject((int)Objects.Content).transform, callback: (fa) =>
            {
                fa.SetInfo(data);
            });
        }
    }
    
}

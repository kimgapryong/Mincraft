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
    private List<BuyFragment> buyList = new List<BuyFragment>();
    private List<SellFragment> sellList = new List<SellFragment>();
    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        BindButton(typeof(Buttons));
        BindObject(typeof(Objects));

        BindEvent(GetObject((int)Objects.Panel).gameObject, ClosePopupUI);
        BindEvent(GetButton((int)Buttons.Buy_Btn).gameObject, BuyBtnAction);
        BindEvent(GetButton((int)Buttons.Sell_Btn).gameObject, SellBtnAction);

        BuyBtnAction();
        return true;
    }
   
    private void BuyBtnAction()
    {
        if(GetButton((int)Buttons.Buy_Btn).image.color == Color.yellow)
            return;

        foreach (SellFragment sell in sellList)
            Destroy(sell.gameObject);
        
        sellList.Clear();
            

        GetButton((int)Buttons.Buy_Btn).image.color = Color.yellow;
        GetButton((int)Buttons.International_Btn).image.color = Color.gray;
        GetButton((int)Buttons.Sell_Btn).image.color = Color.gray;

        foreach(ItemData data in dataList)
        {
            Manager.UI.MakeSubItem<BuyFragment>(GetObject((int)Objects.Content).transform, callback: (fa) =>
            {
                buyList.Add(fa);
                fa.SetInfo(data);
            });
        }
    }
    
    private void SellBtnAction()
    {
        if (GetButton((int)Buttons.Sell_Btn).image.color == Color.yellow)
            return;

        foreach (BuyFragment buy in buyList)
            Destroy(buy.gameObject);

        buyList.Clear();

        GetButton((int)Buttons.Buy_Btn).image.color = Color.gray;
        GetButton((int)Buttons.International_Btn).image.color = Color.gray;
        GetButton((int)Buttons.Sell_Btn).image.color = Color.yellow;

        foreach(Define.Plant plant in System.Enum.GetValues(typeof(Define.Plant)))
        {
            SeedDatas data = Manager.Item.GetPlant(plant);
            if(data.count == 0)
                continue;

            Manager.UI.MakeSubItem<SellFragment>(GetObject((int)Objects.Content).transform, callback: (fa) =>
            {
                sellList.Add(fa);
                fa.SetInfo(plant);
            });
        }
    }
}

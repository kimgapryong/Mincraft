using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFragment : UI_Base
{
    enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        Explanation_Txt,
        Price_Txt,
        Count_Txt,
    }
    enum Buttons
    {
        Buy_Btn,
    }
    private Define.Item type;
    private ItemData _data;
    private ItemDatas _datas;
    private float price;
    private float updatePrice = 1.5f;
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetImage((int)Images.ItemImage).sprite = _data.Image;
        GetText((int)Texts.ItemName).text = _data.ItemName;
        GetText((int)Texts.Explanation_Txt).text = _data.Explanation;


        if(type != Define.Item.Tile)
        {
            BindEvent(GetButton((int)Buttons.Buy_Btn).gameObject, BuyItem);
            Refresh();
        
        }
        else
        {
            BindEvent(GetButton((int)Buttons.Buy_Btn).gameObject, BuyTile);
            GetText((int)Texts.Count_Txt).text = $"{Manager.Tile.GetCount()}/{Manager.Tile.tileList.Count}";
        }

        if ((_datas.count >= _data.MaxCount && _data.MaxCount != 1 && type != Define.Item.Tile) || GameManager.Instance.Money < _data.Price)
        {
            GetText((int)Texts.Price_Txt).text = "구매불가";
            GetButton((int)Buttons.Buy_Btn).image.color = Color.gray;
        }

        return true;
    }
    public void SetInfo(ItemData data)
    {
        _data = data;
        type = data.Type;
        price = _data.Price;
    }
    public void Refresh()
    {
        _datas = Manager.Item.GetItem(type);
        if (_data.MaxCount == 1)
            GetText((int)Texts.Count_Txt).text = $"0/1";
        else
            GetText((int)Texts.Count_Txt).text = $"{_datas.count}/{_data.MaxCount}";

        GetText((int)Texts.Price_Txt).text = $"{price}$";
    }
    private void BuyItem()
    {
        if (_datas.count >= _data.MaxCount || GameManager.Instance.Money < _data.Price)
            return;

        GameObject item = Manager.Resources.Instantiate($"Item/{_data.Path}", Manager.Player.weaponPos);
        Item_Base itemBase = item.GetComponent<Item_Base>();
        Manager.Item.AddItem(itemBase); 

        price *= updatePrice;
        Refresh();
    }
    private void BuyTile()
    {
        if (Manager.Tile.GetCount() >= Manager.Tile.tileList.Count || GameManager.Instance.Money < _data.Price)
            return;

        Manager.Tile.BuyTile();
        price *= updatePrice;

        GetText((int)Texts.Price_Txt).text = $"{price}$";
        GetText((int)Texts.Count_Txt).text = $"{Manager.Tile.GetCount()}/{Manager.Tile.tileList.Count}";
    }
}

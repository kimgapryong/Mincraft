using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellFragment : UI_Base
{
    enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        Explanation_Txt,
        All_Txt,
    }
    enum Buttons
    {
        Single_Btn,
        All_Btn
    }

    private Define.Plant _type;
    private SeedDatas _data;
    private SeedData seed;
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetImage((int)Images.ItemImage).sprite = seed.Image;
        GetText((int)Texts.ItemName).text = seed.PlantName;
        GetText((int)Texts.Explanation_Txt).text = seed.Pretice;
        Refresh();

        BindEvent(GetButton((int)Buttons.Single_Btn).gameObject, () => { Manager.Item.SellPlant(_type); Refresh(); });
        BindEvent(GetButton((int)Buttons.All_Btn).gameObject, () => { Manager.Item.SellAllPlant(_type); Refresh(); });
        return true;
    }
    public void SetInfo(Define.Plant type)
    {
        _type = type;
        _data = Manager.Item.GetPlant(type);
        seed = _data.data;
    }
    public void Refresh()
    {
        _data = Manager.Item.GetPlant(_type);
        if(_data.count != 0)
            GetText((int)Texts.All_Txt).text = $"{_data.count}판매";
        else
            GetText((int)Texts.All_Txt).text = $"작물 부족";
    }
}

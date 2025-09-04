using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFragment : UI_Base
{
   enum Texts
    {
        ItemName,
        ItemCount
    }
    enum Images
    {
        ItemImage,
    }
    private SeedDatas _data;
    private SeedData seed;
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindText(typeof(Texts));
        BindImage(typeof(Images));

        Refresh();

        return true;
    }
    public void SetInfo(SeedDatas data)
    {
        _data = data;   
        seed = data.data;   
    }
    private void Refresh()
    {
        GetImage((int)Images.ItemImage).sprite = seed.Final;
        GetText((int)Texts.ItemName).text = seed.PlantName;
        GetText((int)Texts.ItemCount).text = $"{_data.count}°³";
    }
}

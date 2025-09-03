using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedFragment : UI_Base
{
   enum Images
    {
        SeedImage,
    }
    enum Texts
    {
        SeedName,
        Humidity_Txt,
        Time_Txt,
        Amount_Txt,
        Price_Txt,
    }

    private SeedDatas _data;
    private SeedData seed;
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));

        Refresh();
        return true;
    }
    public void SetInfo(SeedDatas data)
    {
        _data = data;
        seed = data.data;
    }

    public void Refresh()
    {
        GetImage((int)Images.SeedImage).sprite = seed.Image;
        GetText((int)Texts.SeedName).text = seed.SeedName;
        GetText((int)Texts.Humidity_Txt).text = $"{seed.MinHumidity}~{seed.MaxHumidity}";
        GetText((int)Texts.Time_Txt).text = seed.Time.ToString();
        GetText((int)Texts.Amount_Txt).text = _data.count.ToString();
        GetText((int)Texts.Price_Txt).text = seed.Price.ToString();
    }
}

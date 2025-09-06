using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsFragment : UI_Base
{
   enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        Explanation_Txt,
        Count_Txt
    }
    private SeedData _data;
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        
        Refresh();
        return true;
    }
    public void SetInfo(SeedData data)
    {
        _data = data;
    }
    private void Refresh()
    {
        GetImage((int)Images.ItemImage).sprite = _data.Final;
        GetText((int)Texts.Explanation_Txt).text = GameManager.Instance.plantDic[_data.Plant].pre;

        int count = Manager.Item.GetPlant(_data.Plant).count;
        GetText((int)Texts.Count_Txt).text = $"{count}°³";
    }
}

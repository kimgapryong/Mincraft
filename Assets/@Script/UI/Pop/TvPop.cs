using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvPop : UI_Pop
{
    public List<SeedData> seedDatas;
    enum Objects
    {
        Content,
    }
    enum Buttons
    {
        Weather_Btn,
        Crops_Btn,
    }
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(Objects));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Weather_Btn).image.color = Color.yellow;
        GetButton((int)Buttons.Crops_Btn).image.color = Color.gray;

        return true;
    }
    private void CropsBtnAction()
    {
        if (GetButton((int)Buttons.Crops_Btn).image.color == Color.yellow)
            return;

        GetButton((int)Buttons.Crops_Btn).image.color = Color.yellow;
        GetButton((int)Buttons.Weather_Btn).image.color = Color.gray;

        foreach(SeedData data in seedDatas)
        {
            
        }
        
    }

}

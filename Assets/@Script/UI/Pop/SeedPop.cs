using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPop : UI_Pop
{
    enum Objects
    {
        Content,
    }
    enum Buttons
    {
        Close_Btn,
    }

    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        BindObject(typeof(Objects));
        BindButton(typeof(Buttons));    

        foreach(Define.Seed seed in System.Enum.GetValues(typeof(Define.Seed)))
        {
            SeedDatas curSeed = Manager.Item.GetSeed(seed);
            
            if(curSeed.count <= 0)
                continue;

            Manager.UI.MakeSubItem<SeedFragment>(GetObject((int)Objects.Content).transform,callback: (fa) =>
            {
                fa.SetInfo(curSeed);
            });
        }

        BindEvent(GetButton((int)Buttons.Close_Btn).gameObject, () => ClosePopupUI());
        
        return true;
    }
}

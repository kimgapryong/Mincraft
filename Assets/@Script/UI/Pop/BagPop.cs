using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPop : UI_Pop
{
    enum Buttons
    {
        Upgrade_Btn,
        Buy_Btn,
        Bag_Btn,
    }
    enum Objects
    {
        Content,
    }
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindObject(typeof(Objects));

        BindEvent(GetButton((int)Buttons.Bag_Btn).gameObject, BuyBtnAction);
        BuyBtnAction();
        return true;
    }

    private void BuyBtnAction()
    {
        GetButton((int)Buttons.Bag_Btn).image.color = Color.yellow;
        GetButton((int)Buttons.Upgrade_Btn).image.color = Color.gray;
        GetButton((int)Buttons.Buy_Btn).image.color = Color.gray;

        foreach(Define.Seed seed in System.Enum.GetValues(typeof(Define.Seed)))
        {
            if (!Manager.Item._seedDic.ContainsKey(seed) || Manager.Item.GetSeed(seed).count == 0)
                continue;

            Manager.UI.MakeSubItem<SaveFragment>(GetObject((int)Objects.Content).transform, callback: (fa) =>
            {
                fa.SetInfo(seed);
            });
        }
        foreach (Define.Plant seed in System.Enum.GetValues(typeof(Define.Plant)))
        {
            if (!Manager.Item._plantDic.ContainsKey(seed) || Manager.Item.GetPlant(seed).count == 0)
                continue;

            Manager.UI.MakeSubItem<SaveFragment>(GetObject((int)Objects.Content).transform, callback: (fa) =>
            {
                fa.SetInfo(seed);
            });
        }
    }
}

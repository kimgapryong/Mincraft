using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFragment : UI_Base
{
    enum Buttons
    {
        All_Btn,
        Single_Btn,
    }
    enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        Explanation_Txt,
        Count_Txt,
    }

    private bool plantBoolean;
    private bool seedBoolean;

    private Define.Seed _seed;
    private Define.Plant _plant;

    private SeedDatas _data;
    private SeedData seed;
    private string itemName;
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindImage(typeof(Images));
        BindText(typeof(Texts));
        
        BindEvent(GetButton((int)Buttons.Single_Btn).gameObject, SingleBtn);
        BindEvent(GetButton((int)Buttons.All_Btn).gameObject, AllBtn);

        Refresh();
        return true;
    }

    public void SetInfo(Define.Seed seedType)
    {
        _seed = seedType;
        _data = Manager.Item.GetSeed(seedType);
        seed = _data.data;
        itemName = seed.SeedName;
        seedBoolean = true;
    }

    public void SetInfo(Define.Plant plantType)
    {
        _plant = plantType;
        _data = Manager.Item.GetPlant(plantType); 
        seed = _data.data;
        itemName = seed.PlantName;
        plantBoolean = true;
    }
    private void Refresh()
    {
        GetImage((int)Images.ItemImage).sprite = seed.Image;
        GetText((int)Texts.ItemName).text = itemName;
        GetText((int)Texts.Explanation_Txt).text = seed.Pretice;
        GetText((int)Texts.Count_Txt).text = $"{_data.count}°³";
    }

    private void SingleBtn()
    {
        if (plantBoolean)
        {
            if (!Manager.Item.UsePlant(_plant))
                return;

            Manager.Item.AddInvenPlantDic(seed);
        }
        else if(seedBoolean)
        {
            if (!Manager.Item.UseSeed(_seed))
                return;

            Manager.Item.AddInvenSeedDic(seed);
        }
    }

    private void AllBtn()
    {
        if (plantBoolean)
        {
            while (Manager.Item.UsePlant(_plant))
                Manager.Item.AddInvenPlantDic(seed);
        }
        else if (seedBoolean)
        {
            while (Manager.Item.UseSeed(_seed))
                Manager.Item.AddInvenSeedDic(seed);
        }
    }
}

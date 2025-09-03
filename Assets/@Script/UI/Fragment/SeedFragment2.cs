using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedFragment2 : UI_Base
{
    enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        ItemPre_Txt,
    }
    enum Buttons
    {
        Seed_Btn,
    }

    private Vector3Int cell;
    private SeedDatas _seed;
    private SeedData _data;
    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        Refresh();
        BindEvent(GetButton((int)Buttons.Seed_Btn).gameObject, UseSeed);
        

        return true;
    }

    public void SetInfo(SeedDatas seed, Vector3Int cell)
    {
        this.cell = cell;
        _seed = seed;   
        _data = seed.data;
    }
    private void Refresh()
    {
        GetImage((int)Images.ItemImage).sprite = _data.Image;
        GetText((int)Texts.ItemName).text = _data.SeedName;
        GetText((int)Texts.ItemPre_Txt).text = _data.Pretice;
    }

    private void UseSeed()
    {
        SeedController seed = Manager.Item.UseSeed(_data.Type, cell);
        seed.transform.position = cell + Vector3.one * 0.5f;
    }
}

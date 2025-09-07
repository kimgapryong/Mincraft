using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : UI_Base
{
    enum Images
    {
        Image,
    }
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindImage(typeof(Images));
        
        BindEvent(GetImage((int)Images.Image).gameObject, () =>
        {
            Manager.UI.ShowPopUI<TvPop>();
        });
        return true;
    }
}

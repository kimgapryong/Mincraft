using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : Item_Base
{
    public int maxCount {  get; private set; }  
    public int curCount { get; set; }

    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        maxCount = _data.UseCount;
        curCount = maxCount;
        return true;
    }
    public override void ItemAbilty()
    {
        if (GameManager.Instance.Tired >= 100)
        {
            Manager.UI.StateUI.OnText("야이 시키야 좀 쉬자 좀", 3);
            return;
        }
        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);
        if(data.Water > 50)
        {
            Manager.UI.StateUI.OnText("이미 물이 충분한 것 같아", 3f);
            return;

        }
        if(data == null || curCount <= 0)
        {
            Manager.UI.StateUI.OnText("물이 부족한 것 같아", 3f);
            return;
        }
            

        data.Water += _data.Percent;
        curCount--;
        GameManager.Instance.Tired += 5f;


    }
}

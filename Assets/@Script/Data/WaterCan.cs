using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : Item_Base
{
    private int maxCount;
    private int curCount;

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
        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);

        if(data == null || curCount <= 0)
            return;

        data.Water += _data.Percent;
        curCount--;

    }
}

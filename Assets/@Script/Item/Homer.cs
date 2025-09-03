using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homer : Item_Base
{
    public override void ItemAbilty()
    {
        TileData curTile = Manager.Tile.GetTileData(Manager.Input.curCursor);
        SeedController seed = curTile.Seed;
        Manager.Item.AddPlant(seed._data);

        if (Manager.Random.RollPercent(_data.Percent))
            Manager.Item.AddSeed(seed._data);
        
        curTile.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AutoController : BaseController
{
    private ItemData _data;
   public void GetPlant()
    {
        TileData curTile = Manager.Tile.GetTileData(Manager.Input.curCursor);
        SeedController seed = curTile.Seed;

        Manager.Item.AddPlant(seed._data);
        Manager.Item.AddPlant(seed._data);

        if (Manager.Random.RollPercent(_data.Percent))
            Manager.Item.AddSeed(seed._data);

        curTile.Clear();
    }

    public void SetInfo(ItemData data)
    {
        _data = data;
    }
     
}

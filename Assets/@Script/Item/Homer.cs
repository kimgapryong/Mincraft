using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homer : Item_Base
{
    public override void ItemAbilty()
    {
        if (GameManager.Instance.Tired >= 100)
        {
            Manager.UI.StateUI.OnText("야이 시키야 좀 쉬자 좀", 3);
            return;
        }
        TileData curTile = Manager.Tile.GetTileData(Manager.Input.curCursor);
        SeedController seed = curTile.Seed;

        if(seed == null )
        {
            Manager.UI.StateUI.OnText("에잇 아직 아무것도 없잖아 뭘 심어야지", 3f);
            return;
        }
        if (!seed.Grow)
        {
            Manager.UI.StateUI.OnText("아직 수확하면 안될 것 같은데", 3f);
            return ;
        }
        Manager.Item.AddPlant(seed._data);

        if (Manager.Random.RollPercent(_data.Percent))
            Manager.Item.AddSeed(seed._data);
        
        curTile.Clear();
        GameManager.Instance.Tired += 5f;
    }
}

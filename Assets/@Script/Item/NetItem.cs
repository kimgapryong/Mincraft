using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetItem : Item_Base
{
    private float netPercent;
    public override void ItemAbilty()
    {
        if (GameManager.Instance.Tired >= 100)
        {
            Manager.UI.StateUI.OnText("야이 시키야 좀 쉬자 좀", 3);
            return;
        }

        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);
        ItemDatas item = Manager.Item.GetItem(_data.Type);

        if(data.Animal == null)
        {
            Manager.UI.StateUI.OnText("해당 타일에는 동물이 없어", 3);
            return;
        }
        if(item.count == 0)
        {
            Manager.UI.StateUI.OnText("네트가 고장난 것 같아 새로사자", 3);
            return;
        }
        
        data.ClearAnimal();
        netPercent += _data.Percent;

        if (Manager.Random.RollPercent(netPercent))
            Manager.Item.UseItem(_data.Type);

        GameManager.Instance.Tired += 5f;
    }

}

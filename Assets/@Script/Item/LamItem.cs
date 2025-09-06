using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamItem : Item_Base
{
    public override void ItemAbilty()
    {
        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);
        ItemDatas item = Manager.Item.GetItem(_data.Type);

     
        if (data.lam != null)
        {
            data.ClearLam();
        }
        else
        {
            if (item.count == 0)
            {
                Manager.UI.StateUI.OnText("아이템이 없어요", 2);
                return;
            }
            Manager.Resources.Instantiate("Item/LamItem", callback: (go) =>
            {
                go.transform.position = cur + Vector3.one * 0.5f;
                LamController auto = go.GetOrAddComponent<LamController>();
                auto.SetTile(data);
            });

            Manager.Item.UseItem(_data.Type);
        }
         
    }
}

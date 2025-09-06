using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoItem : Item_Base
{
    public override void ItemAbilty()
    {
        if(GameManager.Instance.Tired >= 100)
        {
            Manager.UI.StateUI.OnText("야이 시키야 좀 쉬자 좀", 3);
            return;
        }
        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);
        ItemDatas item = Manager.Item.GetItem(_data.Type);
        if(item.count == 0)
        {
            Manager.UI.StateUI.OnText("아이템이 없어요", 2);
            return;
        }
        if (data.auto != null)
            return;

        Manager.Resources.Instantiate("Item/AutoItem", callback: (go) =>
        {
            go.transform.position = cur + Vector3.one * 0.5f; 
            AutoController auto = go.GetOrAddComponent<AutoController>();
            auto.SetInfo(_data);
        });

        Manager.Item.UseItem(_data.Type);
        GameManager.Instance.Tired += 5f;
    }
  
}

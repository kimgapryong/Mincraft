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
            Manager.UI.StateUI.OnText("���� ��Ű�� �� ���� ��", 3);
            return;
        }

        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);
        ItemDatas item = Manager.Item.GetItem(_data.Type);

        if(data.Animal == null)
        {
            Manager.UI.StateUI.OnText("�ش� Ÿ�Ͽ��� ������ ����", 3);
            return;
        }
        if(item.count == 0)
        {
            Manager.UI.StateUI.OnText("��Ʈ�� ���峭 �� ���� ���λ���", 3);
            return;
        }
        
        data.ClearAnimal();
        netPercent += _data.Percent;

        if (Manager.Random.RollPercent(netPercent))
            Manager.Item.UseItem(_data.Type);

        GameManager.Instance.Tired += 5f;
    }

}

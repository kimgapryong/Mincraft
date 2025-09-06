using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homer : Item_Base
{
    public override void ItemAbilty()
    {
        if (GameManager.Instance.Tired >= 100)
        {
            Manager.UI.StateUI.OnText("���� ��Ű�� �� ���� ��", 3);
            return;
        }
        TileData curTile = Manager.Tile.GetTileData(Manager.Input.curCursor);
        SeedController seed = curTile.Seed;

        if(seed == null )
        {
            Manager.UI.StateUI.OnText("���� ���� �ƹ��͵� ���ݾ� �� �ɾ����", 3f);
            return;
        }
        if (!seed.Grow)
        {
            Manager.UI.StateUI.OnText("���� ��Ȯ�ϸ� �ȵ� �� ������", 3f);
            return ;
        }
        Manager.Item.AddPlant(seed._data);

        if (Manager.Random.RollPercent(_data.Percent))
            Manager.Item.AddSeed(seed._data);
        
        curTile.Clear();
        GameManager.Instance.Tired += 5f;
    }
}

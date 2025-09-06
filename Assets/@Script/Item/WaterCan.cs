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
            Manager.UI.StateUI.OnText("���� ��Ű�� �� ���� ��", 3);
            return;
        }
        Vector3Int cur = Manager.Input.curCursor;
        TileData data = Manager.Tile.GetTileData(cur);
        if(data.Water > 50)
        {
            Manager.UI.StateUI.OnText("�̹� ���� ����� �� ����", 3f);
            return;

        }
        if(data == null || curCount <= 0)
        {
            Manager.UI.StateUI.OnText("���� ������ �� ����", 3f);
            return;
        }
            

        data.Water += _data.Percent;
        curCount--;
        GameManager.Instance.Tired += 5f;


    }
}

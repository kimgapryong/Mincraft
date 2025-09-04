using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterArea : BaseController
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WaterCan waterCan = Manager.Item.GetItem(Define.Item.Water).data as WaterCan;
        Debug.Log(waterCan);

        if (waterCan == null)
            return;

        float cur = waterCan.curCount;
        float max = waterCan.maxCount;

        Manager.UI.StateUI.OnSlider(cur, max, Color.blue, () =>
        {
            waterCan.curCount = waterCan.maxCount;
        });
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        WaterCan waterCan = Manager.Item.GetItem(Define.Item.Water).data as WaterCan;

        if (waterCan == null)
            return;
       
        Manager.UI.StateUI.StopSlider();
    }
}

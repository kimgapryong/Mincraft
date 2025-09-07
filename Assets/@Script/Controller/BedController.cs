using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : BaseController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController waterCan = collision.GetComponent<PlayerController>();

        if (waterCan == null)
            return;

        Manager.UI.StateUI.OnSlider(100 -GameManager.Instance.Tired, 100, Color.yellow, () =>
        {
            GameManager.Instance.Tired = 0;   
        });
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController waterCan = collision.GetComponent<PlayerController>();

        if (waterCan == null)
            return;


        Manager.UI.StateUI.StopSlider();
    }
}

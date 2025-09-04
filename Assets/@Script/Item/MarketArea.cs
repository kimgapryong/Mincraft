using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketArea : BaseController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MainCanvas main = Manager.UI.SceneUI as MainCanvas;
        main.MarketBtn.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MainCanvas main = Manager.UI.SceneUI as MainCanvas;
        main.MarketBtn.gameObject.SetActive(false);
    }
}

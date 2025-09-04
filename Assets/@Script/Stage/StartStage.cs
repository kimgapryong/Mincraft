using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour
{
    public SeedData data;
    public List<GameObject> objs;
    void Start()
    {
        Manager.Tile.Init(objs);
        
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        Manager.Player = player;
        //플레이어 아이템 초기화
        foreach (var item in Manager.Player.GetComponentsInChildren<Item_Base>(true))
        {
            Manager.Item.AddItem(item);
            item.gameObject.SetActive(false);
        }

        Manager.Item.AddSeed(data);
        Manager.UI.ShowSceneUI<MainCanvas>();
    }
}

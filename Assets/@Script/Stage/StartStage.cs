using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour
{
    public List<GameObject> objs;
    void Start()
    {
        Manager.Tile.Init(objs);
        
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        Manager.Player = player;
        //플레이어 아이템 초기화
        foreach (var item in Manager.Player.GetComponentsInChildren<Item_Base>(true))
        {
            Manager.Item._itemDic.Add(item._data.Type, item);
            Manager.Item._itemAbiltyDic.Add(item._data.Type, item.ItemAbilty);
        }

        Manager.UI.ShowSceneUI<MainCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

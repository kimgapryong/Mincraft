using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    public Dictionary<Define.Item, Item_Base> _itemDic = new Dictionary<Define.Item, Item_Base>();
    public Dictionary<Define.Item, Action> _itemAbiltyDic = new Dictionary<Define.Item, Action>();
    public Dictionary<Define.Seed, SeedDatas> _seedDic = new Dictionary<Define.Seed, SeedDatas>();

    public Item_Base GetItem(Define.Item item)
    {
        Item_Base itemBase = null;
        if(_itemDic.TryGetValue(item, out itemBase) == true)
            return itemBase;

        return null;
    }
    public SeedDatas GetSeed(Define.Seed type)
    {
        SeedDatas data;
        if(_seedDic.TryGetValue(type, out data))
            return data;

        Debug.Log(data.count);
        Debug.LogError("값이 없소이다");
        return data;
    }
    public void AddSeed(SeedData seedData)
    {
        Define.Seed seed = seedData.Type;
        SeedDatas seedDatas;
        if (_seedDic.TryGetValue(seed, out seedDatas) == false)
        {
            seedDatas = new SeedDatas() { data = seedData, count = 1 };
            _seedDic.Add(seed, seedDatas);
            Debug.Log(seed);
            return;
        }

        seedDatas.count++;
        _seedDic[seed] = seedDatas;
    }
    
}
public struct SeedDatas
{
    public SeedData data;
    public int count;
}

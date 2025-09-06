using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    public Dictionary<Define.Item, ItemDatas> _itemDic = new Dictionary<Define.Item, ItemDatas>();
    public Dictionary<Define.Item, Action> _itemAbiltyDic = new Dictionary<Define.Item, Action>();
    public Dictionary<Define.Seed, SeedDatas> _seedDic = new Dictionary<Define.Seed, SeedDatas>();
    public Dictionary<Define.Plant, SeedDatas> _plantDic = new Dictionary<Define.Plant, SeedDatas>();

    public ItemDatas GetItem(Define.Item item)
    {
        ItemDatas itemBase;
        if(_itemDic.TryGetValue(item, out itemBase) == true)
            return itemBase;

        return itemBase;
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
    public SeedDatas GetPlant(Define.Plant plant)
    {
        SeedDatas data;
        if(_plantDic.TryGetValue(plant, out data))
            return data;

        Debug.Log("없어요");
        return data;
    }
    public void SellPlant(Define.Plant plant)
    {
        SeedDatas data = GetPlant(plant);
        if(data.count == 0)
        {
            _plantDic.Remove(plant);
            return;
        }
            
        GameManager.Instance.Money += data.data.Price;
        data.count--;
        _plantDic[plant] = data;
    }
    public void SellAllPlant(Define.Plant plant)
    {
        SeedDatas data = GetPlant(plant);
        while(data.count > 0)
            SellPlant(plant);
    }
    public void AddItem(Item_Base itemData)
    {
        Define.Item item = itemData._data.Type;
        ItemDatas itemDatas;
        if(_itemDic.TryGetValue(item, out itemDatas) == false)
        {
            itemDatas = new ItemDatas() {data = itemData, count = 1 };
            _itemDic.Add(item, itemDatas);
            _itemAbiltyDic.Add(item, itemData.ItemAbilty);
            return;
        }

        if(itemData._data.MaxCount == 1)
        {
            UnityEngine.Object.Destroy(itemDatas.data.gameObject);
            itemDatas.data = itemData;
            _itemDic[item] = itemDatas;
            _itemAbiltyDic[item] = itemData.ItemAbilty;
            return;
        }
        if(itemData._data.MaxCount <= itemDatas.count)
            return;

        itemDatas.count++;
        _itemDic[item] = itemDatas;
    }

    public void UseItem(Define.Item item)
    {
        ItemDatas data = GetItem(item);
        if(data.data._data.MaxCount == 1 || data.count == 0)
            return;
            
        data.count--;
       /* if(data.count == 0)
        {
            _itemDic.Remove(item);
            return;
        }*/

        _itemDic[item] = data;
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
    public void AddPlant(SeedData seedData)
    {
        Define.Plant seed = seedData.Plant;
        SeedDatas seedDatas;
        if (_plantDic.TryGetValue(seed, out seedDatas) == false)
        {
            seedDatas = new SeedDatas() { data = seedData, count = 1 };
            _plantDic.Add(seed, seedDatas);
            Debug.Log(seed);
            return;
        }

        seedDatas.count++;
        _plantDic[seed] = seedDatas;
    }
    public SeedController UseSeed(Define.Seed seed, Vector3Int cell)
    {
        SeedDatas curSeed = GetSeed(seed);
        SeedData data = curSeed.data;

        GameObject go = Manager.Resources.Instantiate("Seed");
        SeedController sdc = go.AddComponent<SeedController>();
        sdc.SetInfo(data, Manager.Tile.GetTileData(cell));


        curSeed.count--;

        if (curSeed.count == 0) 
            _seedDic.Remove(seed);

        return sdc;
    }
}
public struct SeedDatas
{
    public SeedData data;
    public int count;
}
public struct ItemDatas
{
    public Item_Base data;
    public int count;
}

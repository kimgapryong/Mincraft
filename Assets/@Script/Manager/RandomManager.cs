using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomManager
{
    public bool RollPercent(float percent)
    {
        if (percent <= 0f) return false;
        if (percent >= 100f) return true;
        return Random.value < (percent * 0.01f); // 50 -> 0.5
    }

    public int GetRandomValue(float[] percent)
    {
        float rand = Random.value * 100f; 
        float cumulative = 0f;

        for (int i = 0; i < percent.Length; i++)
        {
            cumulative += percent[i];
            if (rand < cumulative)
                return i;
        }

        return percent.Length - 1; 
    }
    public float GetRandomRange(float min, float max)
    {
        return Random.Range(min, max);
    }
    public List<TileData> GetRandomTileData(int count)
    {
        int value = count;
        List<TileData> tileList = new List<TileData>();

        while( value > 0)
        {
            int randValue = Random.Range(0, Manager.Tile.tileList.Count);
            TileEx curTile = Manager.Tile.tileList[randValue];

            Debug.Log(randValue);
            Debug.Log(curTile.dataDic.Count);

            if (!curTile.Lock)
                continue;

            Debug.Log("¿Ö ¾ÈµÅ");
            int randTileValue = Random.Range(0, curTile.dataDic.Count);
            tileList.Add(curTile.dataDic.Values.ToList()[randTileValue]);
            value--;
        }

        return tileList;
    }
}

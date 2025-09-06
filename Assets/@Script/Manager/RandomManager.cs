using System.Collections;
using System.Collections.Generic;
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
}

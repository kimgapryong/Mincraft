using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SeedData", menuName ="New SeedData")]
public class SeedData : ScriptableObject
{
    public Define.Seed Type;
    public Sprite Image;
    public string SeedName;
    public string Pretice;
    public float MinHumidity;
    public float MaxHumidity;
    public float Time;
    public int Price;

    public Define.Weather[] weathers;
    public Sprite Grow1;
    public Sprite Grow2;
    public Sprite Grow3;
}

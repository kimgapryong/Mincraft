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
    public float Humidity;
    public float Time;
    public int Price;
}

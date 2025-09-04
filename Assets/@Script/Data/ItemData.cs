using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName = "New ItemData")]
public class ItemData : ScriptableObject
{
    public Define.Item Type;
    public string Path;
    public string ItemName;
    public Sprite Image;
    public float Percent;
    public string Explanation;
    public float Price;

    public int MaxCount;

    [Header("¹°»Ñ¸®°³")]
    public int UseCount;

}

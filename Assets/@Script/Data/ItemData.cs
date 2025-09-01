using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName = "New ItemData")]
public class ItemData : ScriptableObject
{
    public Define.Item Type;
    public Sprite Image;
    public float Percent;

    [Header("¹°»Ñ¸®°³")]
    public int UseCount;

}

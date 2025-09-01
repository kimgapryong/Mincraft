using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    public Dictionary<Define.Item, Item_Base> _itemDic = new Dictionary<Define.Item, Item_Base>();
    public Dictionary<Define.Item, Action> _itemAbiltyDic = new Dictionary<Define.Item, Action>();

}

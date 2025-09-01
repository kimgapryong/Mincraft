using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    public ItemData _data;
    private bool _init;

    private void Start()
    {
        Init();
    }
    protected virtual bool Init()
    {
        if (!_init)
        {
            _init = true;
            return true;
        }

        return false;
    }

    public abstract void ItemAbilty();
}

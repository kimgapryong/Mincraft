using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected bool _init;

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
}

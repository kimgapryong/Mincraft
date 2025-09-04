using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField]
    private float moveSpeed = 5;
    public Vector2 dir;
    private Define.State _state;
    public Define.State State { get { return _state; } set { } }
    public Transform weaponPos;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        weaponPos = transform.Find("Weapon");

        return true;
    }

    private void Update()
    {
        UpdateMethod();
    }

    protected virtual void UpdateMethod()
    {
        switch (State)
        {
            case Define.State.Idle:
                Idle();
                break;
            case Define.State.Walk:
                Walk();
                break;
        }

        float rot = (dir.x > 0) ? 0 : (dir.x < 0) ? 180 : transform.eulerAngles.y;
        Vector3 curRot = transform.eulerAngles;
        curRot.y = rot;
        transform.eulerAngles = curRot;
    }
    protected virtual void Idle()
    {

    }
    protected virtual void Walk()
    {


    } 
 
}

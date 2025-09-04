using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedController : BaseController
{
    public SeedData _data;
    public TileData _tile;
    private Define.Weather[] weather;
    public Action<float, float> timeAction;
    public Action<string> stringAction;
    public bool Grow { get; private set; }
    
    private bool _canGrow = true; // ���� ���¿� �°� ������ ��
    private SpriteRenderer re;
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        _tile.Seed = this;
        re = GetComponent<SpriteRenderer>();
        re.sprite = _data.Grow1;

        StartGrow();

        return true;
    }
    public float MaxTime { get; private set; }
    private float _curTime;
    public float CurTime
    {
        get { return _curTime; }
        set
        {
            _curTime = value;
            Switch(value);
            timeAction?.Invoke(value, MaxTime);
        }
    }
    private void Switch(float cur)
    {
        float value = cur/ MaxTime;
        if(value >= 0.8f)
            re.sprite = _data.Grow3;
        else if(value >= 0.5f)
            re.sprite = _data.Grow2;
        else
            re.sprite = _data.Grow1;
    }
   public void SetInfo(SeedData data, TileData tile)
    {
        _data = data;
        _tile = tile;
        weather = data.weathers;
        MaxTime = data.Time;
    }

    public void SetWeater(Define.Weather weather)
    {
        foreach (var w in this.weather)
        {
            if(weather == w)
                _canGrow = true;
            return;
        }
        _canGrow = false;
    }
    public void StartGrow()
    {
        StartCoroutine(GrowEnumer());
    }
    private IEnumerator GrowEnumer()
    {
        while (MaxTime > CurTime)
        {
            while(!_canGrow || _tile.Water > _data.MaxHumidity || _tile.Water < _data.MinHumidity || GameManager.Instance.Hour < _data.MinGrowTime || GameManager.Instance.Hour > _data.MaxGrowTime)
            {
                if (!_canGrow)
                    stringAction?.Invoke("���忡 ������ ������ �ƴմϴ�");
                else if (_tile.Water > _data.MaxHumidity)
                    stringAction?.Invoke("���� ���� �ʹ� �����ϴ�");
                else if (_tile.Water < _data.MinHumidity)
                    stringAction?.Invoke("���� ���� �ʹ� �����մϴ�");
                else if(GameManager.Instance.Hour < _data.MinGrowTime || GameManager.Instance.Hour > _data.MaxGrowTime)
                    stringAction?.Invoke("������ �� �ִ� �ð��� �ƴմϴ�");
                yield return null;
            }
                
            CurTime += _tile.GrowPoint;
            stringAction?.Invoke($"{CurTime}/{MaxTime}");
            yield return new WaitForSeconds(1f);
        }

        //�����ϰ� ��Ȯ�� �غ��ϴ� �ڵ�
        Grow = true;
    }
    
}

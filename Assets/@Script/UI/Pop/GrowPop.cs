using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPop : UI_Pop
{
    enum Texts
    {
        Name_Txt,
        Humidity_Txt,
        Weater_Txt,
        Water_Txt,
        Exp_Txt,
    }
    enum Images
    {
        SeedImage,
        Water,
        Exp
    }
    enum Buttons
    {
        Close_Btn
    }
    private SeedData _data;
    private SeedController seed;
    private string weatherString;
    private Image seedImage;
    protected override bool Init()
    {
        if(base.Init() == false) return false;

        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        seedImage = GetImage((int)Images.SeedImage);

        seed.stringAction = StringAction;
        seed.timeAction = ExpAction;
        seed._tile.waterAction = WaterAction;

        seed._tile.Water = seed._tile.Water;
        Refresh();

        if (seed.Grow)
            GetText((int)Texts.Exp_Txt).text = "����Ϸ�";
        else
            GetText((int)Texts.Exp_Txt).gameObject.SetActive(false);
        BindEvent(GetButton((int)Buttons.Close_Btn).gameObject, CloseAction);
        
        return true;
    }

    public void SetInfo(SeedData data, SeedController seed)
    {
        _data = data;
        this.seed = seed;

        foreach(var w in _data.weathers)
        {
            switch (w)
            {
                case Define.Weather.Clear:
                    weatherString += "���� ";
                    break;
                case Define.Weather.rainy:
                    weatherString += "�� ";
                    break;
                case Define.Weather.hail:
                    weatherString += "��� ";
                    break;
                case Define.Weather.stormy:
                    weatherString += "��ǳ ";
                    break;
                case Define.Weather.Cloudy:
                    weatherString += "�帲 ";
                    break;
            }
        }
    }
    private void Refresh()
    {
        GetText((int)Texts.Name_Txt).text = _data.SeedName;
        GetText((int)Texts.Humidity_Txt).text = $"��������: {_data.MinHumidity}~{_data.MaxHumidity}";
        GetText((int)Texts.Weater_Txt).text = $"��������: {weatherString}";
    }
    private void WaterAction(float cur, float max)
    {
        GetImage((int)Images.Water).fillAmount = cur / max;
        GetText((int)Texts.Water_Txt).text = $"���� ����: {cur}%";
    }
    private void ExpAction(float cur, float max)
    {
        float value = cur/ max;
        GetImage((int)Images.Exp).fillAmount = value;

        if (value >= 0.8f)
            seedImage.sprite = _data.Grow3;
        else if (value >= 0.5f)
            seedImage.sprite = _data.Grow2;
        else
            seedImage.sprite = _data.Grow1;
    }
    private void StringAction(string str)
    {
        GetText((int)Texts.Exp_Txt).gameObject.SetActive(true);
        GetText((int)Texts.Exp_Txt).text = str;
    }
    private void CloseAction()
    {
        seed.stringAction = null;
        seed.timeAction = null;
        seed._tile.waterAction = null;
        ClosePopupUI();

    }
}

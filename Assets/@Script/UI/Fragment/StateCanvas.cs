using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCanvas : UI_Base
{
    private Coroutine sliderCor;
    private Coroutine textCor;
    private Transform p;
    enum Images
    {
        Slider_Bg,
        Slider,
    }
    enum Texts
    {
        World_Txt,
    }

    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        p = transform.parent;

        GetImage((int)Images.Slider_Bg).gameObject.SetActive(false);
        GetText((int)Texts.World_Txt).gameObject.SetActive(false);

        Manager.UI.StateUI = this;  

        return true;
    }
    void LateUpdate()
    {
        if (p == null) return;

        var local = p.eulerAngles;
        transform.localEulerAngles = local;
    }
    public void OnText(string text, float time)
    {
        if (textCor != null)
            StopCoroutine(textCor);

        GetText((int)Texts.World_Txt).gameObject.SetActive(true);
        GetText((int)Texts.World_Txt).text = text;
        StartCoroutine(WaitCool(time, () => { GetText((int)Texts.World_Txt).gameObject.SetActive(false); textCor = null; }));
    }
    public void OnSlider(float cur, float max, Color color, Action callback)
    {
        if(sliderCor != null)
            StopCoroutine(sliderCor);

        sliderCor = StartCoroutine(SliderCool(cur, max, color, callback));
    }

    IEnumerator WaitCool(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();
    }

    IEnumerator SliderCool(float cur, float max, Color color, Action callback)
    {
        GetImage((int)Images.Slider_Bg).gameObject.SetActive(true);
        GetImage((int)Images.Slider).color = color;

        Debug.Log("waterwater");
        while (cur < max)
        {
            GetImage((int)Images.Slider).fillAmount = cur / max;
            yield return null;
            cur += Time.deltaTime;
            
        }
        GetImage((int)Images.Slider).fillAmount = 1f;
        callback?.Invoke();
        sliderCor = null;
    }

    public void StopSlider()
    {
        if (sliderCor != null)
        {
            StopCoroutine(sliderCor);
            sliderCor = null;
        }
        GetImage((int)Images.Slider_Bg).gameObject.SetActive(false);

    }
}

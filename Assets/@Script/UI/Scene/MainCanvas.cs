using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : UI_Scene
{
    enum Images
    {
        Tilred,
    }
    enum Buttons
    {
        Seed_Btn,
        Plant_Btn,
        Market_Btn
    }
    public List<SlotFragment> _slot = new List<SlotFragment>();
    public Button MarketBtn { get; private set; }
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        TiredAction(0,100);
        GameManager.Instance.tiredAction = TiredAction;
        BindEvent(GetButton((int)Buttons.Seed_Btn).gameObject, () => { Manager.UI.ShowPopUI<SeedPop>(callback: (pop) =>
        {
            pop.SetInfo(Define.PopMode.SeedPop1, Vector3Int.zero);
        }); });

        BindEvent(GetButton((int)Buttons.Plant_Btn).gameObject, () => {
            Manager.UI.ShowPopUI<PlantPop>();
        });
        foreach (SlotFragment fragment in gameObject.GetComponentsInChildren<SlotFragment>())
        {
            fragment.SetInfo(this);
            _slot.Add(fragment);
        }
        BindEvent(GetButton((int)Buttons.Market_Btn).gameObject, () =>
        {
            Manager.UI.ShowPopUI<MarketPop>();
        });

        MarketBtn = GetButton((int)Buttons.Market_Btn);
        MarketBtn.gameObject.SetActive(false);

        SlotAllRefresh();
        return true;
    }
    public void SlotAllRefresh()
    {
        Debug.Log(_slot.Count);
        foreach(var slot in _slot)
            slot.Refresh();
    }

    private void TiredAction(float cur, float max)
    {
        GetImage((int)Images.Tilred).fillAmount = cur / max;
    }
}

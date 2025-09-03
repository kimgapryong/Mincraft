using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : UI_Scene
{
    enum Buttons
    {
        Seed_Btn
    }
    public List<SlotFragment> _slot = new List<SlotFragment>();

    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindEvent(GetButton((int)Buttons.Seed_Btn).gameObject, () => { Manager.UI.ShowPopUI<SeedPop>(callback: (pop) =>
        {
            pop.SetInfo(Define.PopMode.SeedPop1, Vector3Int.zero);
        }); });
        foreach(SlotFragment fragment in gameObject.GetComponentsInChildren<SlotFragment>())
        {
            fragment.SetInfo(this);
            _slot.Add(fragment);
        }

        SlotAllRefresh();
        return true;
    }
    public void SlotAllRefresh()
    {
        Debug.Log(_slot.Count);
        foreach(var slot in _slot)
            slot.Refresh();
    }

    
}

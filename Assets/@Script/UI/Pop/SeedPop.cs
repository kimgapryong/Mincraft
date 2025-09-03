using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPop : UI_Pop
{
    enum Objects
    {
        Content,
        ToolTip
    }
    enum Buttons
    {
        Close_Btn,
    }
    private Define.PopMode _mode;
    private Vector3Int cellPost;
    protected override bool Init()
    {
        if(base.Init() == false )
            return false;

        BindObject(typeof(Objects));
        BindButton(typeof(Buttons));

        switch (_mode)
        {
            case Define.PopMode.SeedPop1:
                {
                    foreach (Define.Seed seed in System.Enum.GetValues(typeof(Define.Seed)))
                    {
                        SeedDatas curSeed = Manager.Item.GetSeed(seed);

                        if (curSeed.count <= 0)
                            continue;

                        Manager.UI.MakeSubItem<SeedFragment>(GetObject((int)Objects.Content).transform, callback: (fa) =>
                        {
                            fa.SetInfo(curSeed);
                        });
                    }

                    
                }
                break;
            case Define.PopMode.SeedPop2:
                {
                    //RectTransform tipRT = GetObject((int)Objects.ToolTip).GetComponent<RectTransform>();
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        transform.GetComponent<RectTransform>(),
                        Input.mousePosition,
                        null,
                        out Vector2 local
                    );
                    GetObject((int)Objects.ToolTip).GetComponent<RectTransform>().anchoredPosition = local;

                    foreach (Define.Seed seed in System.Enum.GetValues(typeof(Define.Seed)))
                    {
                        SeedDatas curSeed = Manager.Item.GetSeed(seed);

                        if (curSeed.count <= 0)
                            continue;

                        Manager.UI.MakeSubItem<SeedFragment2>(GetObject((int)Objects.Content).transform, callback: (fa) =>
                        {
                            fa.SetInfo(curSeed, cellPost);
                        });
                    }
                }
                break;
        }

        BindEvent(GetButton((int)Buttons.Close_Btn).gameObject, () => ClosePopupUI());

        return true;
    }
    public void SetInfo(Define.PopMode mode, Vector3Int cell)
    {
        _mode = mode;
        cellPost = cell;
    }
    private void Update()
    {
        if (_mode != Define.PopMode.SeedPop2)
            return;
    }
}

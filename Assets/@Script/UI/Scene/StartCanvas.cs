using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvas : UI_Scene
{
    enum Buttons
    {
        Start_Btn,
        Explain_Btn,
        Exit_Btn,
    }
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        BindEvent(GetButton((int)Buttons.Start_Btn).gameObject, () => SceneManager.LoadScene("MainScene"));
        
        return true;
    }
}

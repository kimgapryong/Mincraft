using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _instance = null;
    public static Manager Instance { get { Init(); return _instance; } }

    private TileManager _tile = new TileManager();
    public static TileManager Tile { get { return Instance._tile; } }
    private ResourcesManager _resources = new ResourcesManager();
    public static ResourcesManager Resources { get { return Instance._resources; } }
    private UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }
    private ItemManager _item = new ItemManager();
    public static ItemManager Item { get { return Instance._item; } }
    private RandomManager _rand = new RandomManager();
    public static RandomManager Random { get { return Instance._rand; } }

    public static PlayerController Player;
    public static InputController Input;
    private static void Init()
    {
        if(_instance != null)
            return;

        GameObject go = GameObject.Find("@Manager");
        if(go == null)
        {
            go = new GameObject("@Manager");
            go.AddComponent<Manager>();
        }
        _instance = go.GetComponent<Manager>();
        DontDestroyOnLoad(go);

        
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager
{
    private const string MAIN_SPRITE_NAME = "Sprite_Tiles_Soil_23";

    private int minX = 11;
    private int minY = -10;
    private int maxX = 28;
    private int maxY = 7;
    private Vector3Int[] vectorArray = new Vector3Int[9] { Vector3Int.zero, Vector3Int.right, Vector3Int.left, Vector3Int.up, Vector3Int.down, new Vector3Int(1,1), new Vector3Int(-1, 1), new Vector3Int(-1, -1), new Vector3Int(1, -1) };

    public Tilemap solidTile;
    public List<TileEx> tileList = new List<TileEx>();
    
    public void Init(List<GameObject> objs)
    {
        int curValue = 0;

        GameObject go = GameObject.Find("Grid");
        solidTile = go.transform.Find("Solid").GetComponent<Tilemap>();
        
        for(int x = minX; x <= maxX; x++)
        {
            for(int y = minY; y <= maxY; y++)
            {
                Vector3Int pos = new Vector3Int(x, y);
                if(solidTile.GetTile(pos).name != MAIN_SPRITE_NAME)
                    continue;

                TileEx tile = new TileEx(objs[curValue]);
                foreach (var vec in vectorArray)
                {
                    Vector3Int tileVec = (pos + vec);
                    TileData data = new TileData(solidTile, 50,tileVec, tile);
                    tile.dataDic.Add(tileVec, data);
                }
                tileList.Add(tile);
                curValue++;
            }
        }
        tileList[0].Lock = true;    
    }

    public bool CheckTile(Vector3Int vec)
    {
        foreach(var tile in tileList)
        {
            if (tile.Lock)
                if (tile.dataDic.ContainsKey(vec))
                    return true;
        }

        return false;
    }

    public TileData GetTileData(Vector3Int vec)
    {
        TileData tileData = null;
        foreach(var tile in tileList)
        {
           if(tile.dataDic.TryGetValue(vec, out tileData))
                return tileData;
        }
        return null;
    }
}

public class TileEx
{
    private GameObject obj;

    private bool _lock;
    public bool Lock
    {
        get { return _lock; }
        set
        {
            _lock = value;
            UnityEngine.Object.Destroy(obj);
        }
    }
    public Dictionary<Vector3Int, TileData> dataDic  = new Dictionary<Vector3Int, TileData>();
    public TileEx(GameObject obj)
    {
      this.obj = obj;
    }

    public void UpdateWater(float water)
    {
        foreach(var data in dataDic.Values)
        {
            data.Water -= water;
        }
    }
}
public class TileData
{
    private TileEx parent;
    private Vector3Int vec;
    private Tilemap tilemap;
    private TileBase baseTile;
    public float GrowPoint { get; private set; } = 1f;
    public SeedController Seed {  get; set; }
    public Action<float, float> waterAction;
    //현재 농장물 스크립트
    private float _water;
    public float Water
    {
        get { return _water; }
        set
        {
            _water = value;
            WaterChange(value);
            waterAction?.Invoke(value, 100);
        }
    }

    public TileData(Tilemap tilemap, float water, Vector3Int vec, TileEx parent)
    {
        this.vec = vec;
        this.tilemap = tilemap;
        Water = water;
        this.parent = parent;
        baseTile = tilemap.GetTile(vec);
    }
    
    private void WaterChange(float value)
    {
        if(value >= 80)
            tilemap.SetTile(vec, Manager.Resources.LoadTile("Sprite_Tiles_Soil_23"));
        else if(value >= 50)
            tilemap.SetTile(vec, Manager.Resources.LoadTile("Sprite_Tiles_Soil_27"));
        else
            tilemap.SetTile(vec, Manager.Resources.LoadTile("Sprite_Tiles_Soil_35"));
    }
    //Sprite_Tiles_Soil_27 적당한거
    //Sprite_Tiles_Soil_23 너무 젖은 거
    //Sprite_Tiles_Soil_35 마른 거
    public void SetGrowPoint(float growPoint)
    {
        GrowPoint = growPoint;
    }
    public void Clear()
    {
        UnityEngine.Object.Destroy(Seed.gameObject);
        Seed = null;

    }

}
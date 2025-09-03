using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class InputController : BaseController
{
    public Define.Item curItem;
    public Transform marker;
    public Tilemap tile;
    private Camera cam;
    public Vector3Int curCursor;

    //현재 pop체크
    private SeedPop pop;

    [SerializeField]
    private float speed = 4f;
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        cam = Camera.main;
        Manager.Input = this;   

        return true;
    }
    private void Update()
    {
        GetCell();
        PlayerMove();
    }

    //플레이어 이동
    private void PlayerMove()
    {
        if(Manager.Player == null) return;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 curPos = new Vector3(x, y, 0);
        Manager.Player.dir = curPos;
        Manager.Player.transform.Translate(curPos * speed * Time.deltaTime, Space.World);
    }

    //마우스 셀 좌표 반환
    private void GetCell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current && EventSystem.current.IsPointerOverGameObject())
                return;

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tile.WorldToCell(mousePos);
            

            if (!Manager.Tile.CheckTile(cellPos))
                return;

            if(Vector2.Distance(Manager.Player.transform.position, mousePos) > 3f)
                return;

            Vector3Int cell = tile.WorldToCell(mousePos);
            if (tile.HasTile(cell) && curCursor != cellPos)  
            {
                
               Vector3 markVec = Vector3Int.FloorToInt(mousePos) + Vector3.one * 0.5f;
                marker.transform.position = markVec;
                curCursor = cellPos;
                return;
            }
            if (curItem != Define.Item.None)
            {
                if (Manager.Item._itemDic.ContainsKey(curItem))
                    Manager.Item._itemAbiltyDic[curItem]?.Invoke();
                return;
            }
                

            SeedController seed = Manager.Tile.GetTileData(cellPos).Seed;
            if (seed != null)
            {
                Manager.UI.ShowPopUI<GrowPop>(callback: (pop) =>
                {
                    pop.SetInfo(seed._data, seed);
                });
                return;
            }

            if (pop != null)
                Manager.UI.ClosePopUI(pop);

            Manager.UI.ShowPopUI<SeedPop>("SeedPop2", callback: (pop) =>
            {
                this.pop = pop;
                pop.SetInfo(Define.PopMode.SeedPop2, cellPos);
            });

           
        }
    }
}

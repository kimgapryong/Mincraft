using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : BaseController
{
    private TileData _data;
    private Vector3 dir;
    private float speed = 1f;
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        StartCoroutine(Move());

        return true;
    }
    public void SetInfo(TileData data)
    {
        _data = data;
    }
    private IEnumerator Move()
    {
        while (true)
        {
            TileData nextTile = Manager.Random.GetRandomTileData(1)[0];
            dir = (nextTile.vec - _data.vec);
            dir = dir.normalized;
                
            while(_data != nextTile)
            {
                Debug.Log(Vector2.Distance(transform.position, (Vector3)nextTile.vec));
                if(Vector2.Distance(transform.position, (Vector3)nextTile.vec + Vector3.one * 0.5f) <= 0.1f)
                {
                    transform.position = (Vector3)nextTile.vec + Vector3.one * 0.5f;
                    _data.Animal = null;
                    nextTile.Animal = gameObject;
                    _data = nextTile;
                }
                transform.Translate(dir * speed * Time.deltaTime, Space.World);
                yield return null;
            }

            yield return new WaitForSeconds(4f);
        }
    }
}

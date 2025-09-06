using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamController : BaseController
{
    SeedController seed;
    private TileData _tile;
    protected override bool Init()
    {
        if(base.Init() == false)
            return false;

        seed = _tile.Seed;
        if(seed != null)
            seed.LamGrow = true;
        return true;
    }

    public void SetTile(TileData tile)
    {
        _tile = tile;
        _tile.lam = this;
    }
    public void SetInfo(SeedController seed)
    {
        this.seed = seed;
        seed.LamGrow = true ;
    }
}

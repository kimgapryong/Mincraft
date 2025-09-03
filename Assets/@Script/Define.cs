using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
   public enum State
    {
        Walk,
        Idle,
    }
    public enum Item
    {
        None,
        Hormer,
        Water,
        Auto,
        Net,
        House
    }
    public enum Seed
    {
        Carrot,
        Corn,
        Wheat,
    }
    public enum Plant
    {
        Carrot,
        Corn,
        Wheat,
    }
    public enum PopMode
    {
        SeedPop1,
        SeedPop2
    }
    public enum Weather
    {
        Clear,
        Cloudy,
        rainy,
        stormy,
        hail
    }
}

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
        House,
        Tile
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

    public static string GetWeatherString(Define.Plant plant, float value)
    {
        string plantName = "";
        switch(plant)
        {
            case Plant.Carrot:
                plantName = "당근";
                break;
            case Plant.Corn:
                plantName = "옥수수";
                break;
            case Plant.Wheat:
                plantName = "밀";
                break;
        }
        if(value < 0.5f)
        {
            return $"현재 {plantName}의 시세가 완전히 반토막이 나버렸습니다 좀 더 묶혀서 판매하는 것을 추천합니다";
        }
        else if(value < 1.4f)
        {
            return $"현재 {plantName}의 시세가 조금 올랐습니다 지금 판매해도 되지만 어쩌면 내일 가격이 폭등할 수도 있습니다";
        }
        else
        {
            return $"현재 {plantName}의 시세가 완전 초대박이 터졌네요 지금 파는 것을 추천합니다 현재 시세는 약 {value}배 입니다";
        }
       
    }
}

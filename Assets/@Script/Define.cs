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
                plantName = "���";
                break;
            case Plant.Corn:
                plantName = "������";
                break;
            case Plant.Wheat:
                plantName = "��";
                break;
        }
        if(value < 0.5f)
        {
            return $"���� {plantName}�� �ü��� ������ ���丷�� �����Ƚ��ϴ� �� �� ������ �Ǹ��ϴ� ���� ��õ�մϴ�";
        }
        else if(value < 1.4f)
        {
            return $"���� {plantName}�� �ü��� ���� �ö����ϴ� ���� �Ǹ��ص� ������ ��¼�� ���� ������ ������ ���� �ֽ��ϴ�";
        }
        else
        {
            return $"���� {plantName}�� �ü��� ���� �ʴ���� �����׿� ���� �Ĵ� ���� ��õ�մϴ� ���� �ü��� �� {value}�� �Դϴ�";
        }
       
    }
}

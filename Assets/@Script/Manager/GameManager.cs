using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public Dictionary<Define.Plant, WheaterDatas> plantDic = new Dictionary<Define.Plant, WheaterDatas>();
    public static GameManager Instance { get { Init(); return _instance; } }
    public Action<float, float> tiredAction;
    public Action<float> moneyAction;

    private Define.Weather[] weathers = new Define.Weather[5]
    {
        Define.Weather.Clear,
        Define.Weather.Cloudy,
        Define.Weather.rainy,
        Define.Weather.stormy,
        Define.Weather.hail,
    };
    private float[] percents = new float[5]
    {
        50f, 30f, 10f, 5f, 5f
    };

    private float _tired;
    public float Tired
    {
        get { return _tired; }
        set
        {
            _tired = Mathf.Clamp(value, 0, 100);
            tiredAction?.Invoke(value, 100);
        }
    }
    public Define.Weather CurWeahter { get; private set; }
    public int Hour { get; private set; }
    public float inGameTime;   // 0~24시간
    private const float realSecondsPerDay = 120f;
    private const float inGameHoursPerDay = 24f;

    private float growPoint = 1f; //작물 성장 게이지
    private float hamPoint; //타일의 습도 게이지

    private float _price = 100;
    public float Money
    {
        get { return _price; }
        set
        {
            _price = value;
            moneyAction?.Invoke(value);
        }
    }
    public float AnimalPercent { get; set; }    

    //private Dictionary<int, Action> timeEvents = new Dictionary<int, Action>();

    private void Awake()
    {
        Init();
        OnDayPassed(); //날씨 먼저 설정
        StartCoroutine(UpdateHam());
        
    }

    private void Update()
    {
        float inGameHoursPerRealSecond = inGameHoursPerDay / realSecondsPerDay;
        inGameTime += Time.deltaTime * inGameHoursPerRealSecond;

        if (inGameTime >= 24f)
        {
            inGameTime -= 24f;
            OnDayPassed();
        }

        Hour = GetHour();

        /*if (timeEvents.ContainsKey(hour))
        {
            timeEvents[hour]?.Invoke();
            timeEvents.Remove(hour); // 하루 한 번만 실행하도록 제거
        }*/
    }
    private static void Init()
    {
        if (_instance != null)
            return;

        GameObject go = GameObject.Find("@GameManager");
        if (go == null)
        {
            go = new GameObject("@GameManager");
            go.AddComponent<GameManager>();
        }
        _instance = go.GetComponent<GameManager>();
        DontDestroyOnLoad(go);


    }
    public int GetHour() => Mathf.FloorToInt(inGameTime);
   /* public int GetMinute()
    {
        float hourFraction = inGameTime - Mathf.Floor(inGameTime);
        return Mathf.FloorToInt(hourFraction * 60);
    }*/

    private void OnDayPassed()
    {
        int vlaue = Manager.Random.GetRandomValue(percents);
        CurWeahter = weathers[vlaue];
        Debug.Log(CurWeahter.ToString());

        switch (CurWeahter)
        {
            case Define.Weather.Clear:
                growPoint = 2f;
                hamPoint = -1;
                break;
            case Define.Weather.rainy:
                growPoint = 2f;
                hamPoint = 1;
                break;
            case Define.Weather.hail:
                growPoint = -1f;
                hamPoint = -10;
                break;
            case Define.Weather.stormy:
                growPoint = 1f;
                hamPoint = -15;
                break;
            case Define.Weather.Cloudy:
                growPoint = 1f;
                hamPoint = -1;
                break;
        }

        foreach (var tile in Manager.Tile.tileList)
        {
            if (!tile.Lock)
                continue;
            tile.SetAllGrowPoint(growPoint);
        }

        MakePrice();
        Animal();
    }

    /*public void RegisterEvent(int hour, Action callback)
    {
        if (!timeEvents.ContainsKey(hour))
            timeEvents.Add(hour, callback);
    }*/

    private IEnumerator UpdateHam()
    {
        while (true)
        {
            foreach (var tile in Manager.Tile.tileList)
            {
                if (!tile.Lock)
                    continue;

                tile.UpdateWater(hamPoint);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void MakePrice()
    {
        WheaterDatas datas;
        foreach (Define.Plant plant in System.Enum.GetValues(typeof(Define.Plant)))
        {
            float curFloat = Manager.Random.GetRandomRange(0.3f, 2f);
            datas.wheater = curFloat;
            datas.pre = Define.GetWeatherString(plant, curFloat);
            plantDic[plant] = datas;
        }
    }
    public void Animal()
    {
        Debug.Log("치킨나");
        if (!Manager.Random.RollPercent(AnimalPercent))
            return;

        Debug.Log("치킨나와");
        AnimalPercent = 0;
        int value = UnityEngine.Random.Range(1, 4);
        List<TileData> list = Manager.Random.GetRandomTileData(value);
        Debug.Log(list.Count);
        foreach (var tile in list)
        {
            GameObject animal = Manager.Resources.Instantiate("Animal/Chicken",(Vector3)tile.vec + Vector3.one * 0.5f, Quaternion.identity);
            animal.GetOrAddComponent<AnimalController>().SetInfo(tile);
            tile.Animal = animal;

            Debug.Log(tile.Animal);
        }
        
    }
}
public struct WheaterDatas
{
    public float wheater;
    public string pre;
}

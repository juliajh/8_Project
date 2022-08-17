using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class BasketManager : MonoBehaviour
{
    public static BasketManager Instance;
    public GameObject shopContent;

    public List<RecommendResponseData> BasketList = new List<RecommendResponseData>();

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        //Load();
    }

    public void AddBasket(RecommendResponseData data)
    {
        if (!BasketList.Contains(data))
        {
            BasketList.Add(data);
        }
    }

    public void RemoveBasket(RecommendResponseData data)
    {
        BasketList.Remove(data);
    }

    /*
    public async UniTaskVoid Load()
    {
        print("load");
        var response = await NetManager.Post<ResponseLoginPacket>(new RequestLoginPacket());

        if (response.Result)
        {
            UnityEngine.Debug.Log(response.Map);

            var mapDatas = JsonConvert.DeserializeObject<List<MapData>>(response.Map);

            if (mapDatas.Count > 0)
            {
                for (int i = 0; i < mapDatas.Count; ++i)
                {
                    var data = mapDatas[i];

                    if (data.FurnitureType == FurnitureType.Floor)
                    {
                        floors[data.Index].SetActive(true);
                    }
                    else
                    {
                        Make(data.FurnitureType, data.Index, data.x, data.y, data.Direction);
                    }
                }

            }

        }
    }


    public async UniTaskVoid Save()
    {
        int count = InteriorObjects.Count;
        if (count == 0) return;

        List<MapData> saveData = new List<MapData>(count);

        for (int i = 0; i < count; ++i)
        {
            var o = InteriorObjects[i];

            MapData data = new MapData()
            {
                FurnitureType = o.FurnitureType,
                Index = o.Index,
                x = o.transform.position.x,
                y = o.transform.position.y,
                Direction = o.direction
            };

            saveData.Add(data);
        }

        MapData floordata = new MapData()
        {
            FurnitureType = FurnitureType.Floor,
            Index = checkFloor(),
            x = 0,
            y = 0,
            Direction = 0
        };

        saveData.Add(floordata);
        string jsonData = JsonConvert.SerializeObject(saveData);

        var response = await NetManager.Post<ResponseSavePacket>(new RequestSavePacket(jsonData));

        if (response.Result)
        {
            UnityEngine.Debug.Log("저장 성공");
        }
    }

    */
}

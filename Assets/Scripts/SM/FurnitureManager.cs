using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Newtonsoft.Json;

public class FurnitureManager : MonoBehaviour
{
    public static FurnitureManager Instance;

    public List<InteriorObject> Prefabs;

    public List<InteriorObject> InteriorObjects = new List<InteriorObject>(64);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
    }


    public void Make(FurnitureType furnitureType, int index)
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);

        obj.SetIndex(index);

        obj.transform.position = new Vector3(0, 0, 0);

        InteriorObjects.Add(obj);
    }

    public void Make(FurnitureType furnitureType, int index, float x, float y, Direction direction)
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);
        obj.SetIndex(index);

        obj.transform.position = new Vector3(x, y, 0);

        InteriorObjects.Add(obj);
    }

    public async UniTaskVoid Load()
    {
        var response = await NetManager.Post<ResponseLoginPacket>(new RequestLoginPacket());

        if (response.Result)
        {
            UnityEngine.Debug.Log(response.Map);

            var mapDatas = JsonConvert.DeserializeObject<List<MapData>>(response.Map);
            if(mapDatas.Count > 0)
            {
                for(int i = 0; i < mapDatas.Count; ++i)
                {
                    var data = mapDatas[i];

                    Make(data.FurnitureType, data.Index, data.x, data.y, data.Direction);
                }

            }    

        }
    }


    public async UniTaskVoid Save()
    {
        int count = InteriorObjects.Count;
        if (count == 0) return;

        List<MapData> saveData = new List<MapData>(count);

        for(int i = 0; i < count; ++i)
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

        string jsonData = JsonConvert.SerializeObject(saveData);

        var response = await NetManager.Post<ResponseSavePacket>(new RequestSavePacket(jsonData));

        if (response.Result)
        {
            UnityEngine.Debug.Log("저장 성공");
        }
    }
}

public class MapData
{
    public FurnitureType FurnitureType;
    public int Index;
    public float x;
    public float y;
    public Direction Direction;
}

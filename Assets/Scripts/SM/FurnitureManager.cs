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
    public List<GameObject> floors;

    public List<InteriorObject> InteriorObjects = new List<InteriorObject>(64);

    private InteriorObject m_CurrentInterObject;
    public InteriorObject CurrentInterObject => m_CurrentInterObject;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
    }


    public void RecommendMake(FurnitureType furnitureType, int index, float x, float y, Direction direction) 
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);
        obj.SetIndex(index);
        obj.transform.position = new Vector3(x, y, 0);

        obj.direction = direction;
        obj.LoadTurnObject(direction);
        //InteriorObjects.Add(obj);
        obj.ColorChange();
    }


    public void Make(FurnitureType furnitureType, int index)
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);
        obj.SetIndex(index);
        if (furnitureType == FurnitureType.PhotoFrame) 
        {
            obj.transform.position = new Vector3(0, 3.8f, 0);

        }

        else
        {
            obj.transform.position = new Vector3(0, 0, 0);

        }

        InteriorObjects.Add(obj);
        PosRecommend();

        
    }

    /*public async UniTaskVoid Recommend() 
    {
        //var response = await NetManager.Post<ResponsePacket>(new RequestPosPacket());

        //print(response);
        UInet
    }*/


    public void Make(FurnitureType furnitureType, int index, float x, float y, Direction direction)
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);
        obj.SetIndex(index);
        obj.transform.position = new Vector3(x, y, 0);

        obj.direction = direction;
        print(obj.direction);
        obj.LoadTurnObject(direction);
        InteriorObjects.Add(obj);

    }

    public void ClearMap()
    {
        int count = InteriorObjects.Count;

        for(int i = 0; i < count; ++i)
        {
            Destroy(InteriorObjects[i].gameObject);
        }

        InteriorObjects.Clear();

        FurnitureManager.Instance.SetCurrentInterObject(null);
    }


    public void RemoveCurrenntInteriorObject() 
    {
        if(m_CurrentInterObject == null)
        {
            return;
        }

        InteriorObjects.Remove(m_CurrentInterObject);

        Destroy(m_CurrentInterObject.gameObject);
        SetCurrentInterObject(null);
    }

    public void SetCurrentInterObject(InteriorObject interiorObject)
    {
        m_CurrentInterObject = interiorObject;

        if(m_CurrentInterObject == null)
        {
            UI_RotateButton.Instance.Hide();
            UI_DeleteButton.Instance.Hide();
            return;
        }

        // 버튼 노출 로직
        UI_RotateButton.Instance.Show();
        UI_DeleteButton.Instance.Show();
    }

    public async UniTaskVoid PosRecommend()
    {
        // 가구 타입
        // 가구 아이디
        // 가구 색상

        PosRequestData posRequestData = new PosRequestData
        {
            FurnitureType = FurnitureType.Bed.ToString(),
            ColorType = ColorType.Blue.ToString()
        };
        var response = await NetManager.Post<ResponsePosPacket>(new RequestPosPacket(posRequestData));

        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;
            
            var data = responseData[0];
            float p_X = float.Parse(data.PosX);
            float p_Y = float.Parse(data.PosY);
            //if () { }
            RecommendMake(FurnitureType.Bed, 1, p_X, p_Y, Direction.Front);


            //allPos.RemoveAll();
            /*for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                float.Parse(data.PosX);
                Debug.Log("====="+ float.Parse(data.PosX));
                //Debug.Log("2||||"+data.PosY);
                FurnitureManager.Instance.Make(FurnitureType.Bed, 1,data.PosX,data.PosY,Direction.Front);
            }*/
        }
    }
    public async UniTaskVoid Load()
    {
        print("load");
        
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

    private int checkFloor()
    {
        int floorNum = 0;
        foreach(GameObject f in floors)
        {
            if (f.activeSelf == true)
            {
                floorNum = floors.IndexOf(f);
            }
        }

        
        Debug.Log("SSSSSSSSSSSSSSSS ===== " + floorNum);
        return floorNum;
    }

    public void OnClickSaveButton()
    {
        Save();
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
}

public class MapData
{
    public FurnitureType FurnitureType;
    public int Index;
    public float x;
    public float y;
    public Direction Direction;
}

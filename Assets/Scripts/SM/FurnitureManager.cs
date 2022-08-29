using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Newtonsoft.Json;
using DG.Tweening;

public class FurnitureManager : MonoBehaviour
{
    public static FurnitureManager Instance;

    public Transform m_Parent;


    public List<InteriorObject> Prefabs;
    public List<GameObject> floors;

    public List<InteriorObject> InteriorObjects = new List<InteriorObject>(64);



    public List<GameObject> recommendFurniture = new List<GameObject>();

    private InteriorObject m_CurrentInterObject;
    public InteriorObject CurrentInterObject => m_CurrentInterObject;



    public GameObject recommendParticle;
    public GameObject putButton;
    public GameObject destroyParticle;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //m_Parent = transform;
        Load();
        //destroyParticle.SetActive(false);
    }


    public void RecommendMake(FurnitureType furnitureType, int index, float x, float y, Direction direction) 
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);
        obj.gameObject.SetActive(false);
        obj.SetIndex(index);
        //obj.transform.position = new Vector3(x, y, 0);

        obj.direction = direction;
        obj.LoadTurnObject(direction);
        //InteriorObjects.Add(obj);
        obj.ColorChange();
        obj.tag = "RecommendFurniture";
        if (recommendFurniture.Count == 0)
        {
            print("recommendCount" + recommendFurniture.Count);
            recommendFurniture.Add(obj.gameObject);

        }
        else 
        {
            print("recommendCount" + recommendFurniture.Count);
            Destroy(recommendFurniture[0]);
            recommendFurniture.RemoveAt(0);
            recommendFurniture.Add(obj.gameObject);
        }
        
        recommendFurniture[0].transform.position = new Vector2(x, y);
        obj.gameObject.SetActive(true);
        Vector3 particlePos = new Vector3(obj.transform.position.x, obj.transform.position.y, 60);
        GameObject forRecommend = Instantiate(recommendParticle, particlePos, Quaternion.identity);
        forRecommend.transform.SetParent(obj.transform);
    }
    int sortOrder = 5;
    public void Make(FurnitureType furnitureType, int index)
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType], m_Parent);
        obj.SetIndex(index);
        sortOrder += 1;
        print("sir" + sortOrder);
        obj.m_SpriteRenderer.sortingOrder = sortOrder;
        obj.gameObject.AddComponent<PolygonCollider2D>();

        if (furnitureType == FurnitureType.PhotoFrame) 
        {
            obj.transform.position = new Vector3(0, 3.8f, 0);

        }

        else
        {
            obj.transform.position = new Vector3(0, 0, 0);

        }

        InteriorObjects.Add(obj);
        PosRecommend(obj.FurnitureType,index);

        
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

    public async UniTaskVoid PosRecommend(FurnitureType furnitureType,int index)
    {
        // 가구 타입
        // 가구 아이디
        // 가구 색상

        string tmp = ((ColorType)index).ToString();

        if (furnitureType == FurnitureType.BookShelf || furnitureType == FurnitureType.Desk ||
        furnitureType == FurnitureType.FlowerPot || furnitureType == FurnitureType.PhotoFrame)
        {
            tmp = index.ToString();
        }

        PosRequestData posRequestData = new PosRequestData
        {
            /*            FurnitureType = FurnitureType.Bed.ToString(),
                        ColorType = ColorType.Blue.ToString()*/
            FurnitureType = furnitureType.ToString(),
            ColorType = tmp
        };
       
        var response = await NetManager.Post<ResponsePosPacket>(new RequestPosPacket(posRequestData));

        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;

            print(responseData);

            var data = responseData[0];
            float p_X = float.Parse(data.PosX);
            float p_Y = float.Parse(data.PosY);
            Debug.Log(data);


            //if () { }
            RecommendMake(furnitureType, index, p_X, p_Y, Direction.Front);
            


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
                        Debug.Log("data.Index=="+data.Index);
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
        Debug.Log("floorNum=="+floorNum);
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

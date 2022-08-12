using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class RecommendManager : MonoBehaviour
{
    public static RecommendManager Instance;
    
    public List<RecommendResponseData> List = new List<RecommendResponseData>(32);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GetRandomRecommend();
    }

    private async UniTaskVoid GetRandomRecommend()
    {
        var response = await NetManager.Post<ResponseRecommendPacket>(new RequestRecommendRandomPacket());

        if (response.Result)
        {
            
            List.Clear();
            
            int count = response.Data.Length;

            var responseData = response.Data;

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                List.Add(data);
                Debug.Log(data.Category);
                Debug.Log(data.Color);
                Debug.Log(data.Title);
                Debug.Log(data.Link);
                Debug.Log(data.Image);
                Debug.Log(data.Brand);
                Debug.Log(data.Price);
            }
            
            UI_Recommend.Instance.Refresh();
        }
    }

    public async UniTaskVoid Recommend(FurnitureType furnitureType, ColorType colorType)
    {
        RecommendRequestData recommendRequestData = new RecommendRequestData
        {
            FurnitureType = furnitureType.ToString(),
            ColorType = colorType.ToString(),
        };

        var response = await NetManager.Post<ResponseRecommendPacket>(new RequestRecommendPacket(recommendRequestData));

        if (response.Result)
        {
            List.Clear();

            int count = response.Data.Length;

            var responseData = response.Data;

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                List.Add(data);

                Debug.Log(data.Category);
                Debug.Log(data.Color);
                Debug.Log(data.Title);
                Debug.Log(data.Link);
                Debug.Log(data.Image);
                Debug.Log(data.Brand);
                Debug.Log(data.Price);
            }
            
            UI_Recommend.Instance.Refresh();

        }
    }
}

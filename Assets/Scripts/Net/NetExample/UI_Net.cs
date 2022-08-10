using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_Net : MonoBehaviour
{
    public void OnClickLoginButton()
    {
        Login();
    }
    public async UniTaskVoid Login()
    {
        var response = await NetManager.Post<ResponseLoginPacket>(new RequestLoginPacket());

        if (response.Result)
        {
            UnityEngine.Debug.Log(response.Result);
            UnityEngine.Debug.Log(response.Map);
        }
        
    }

    public void OnClickSaveButton()
    {
        Save();
    }

    public async UniTaskVoid Save()
    {
        var response = await NetManager.Post<ResponseSavePacket>(new RequestSavePacket("{id: 234234}"));

        if (response.Result)
        {
            UnityEngine.Debug.Log("저장 성공");
        }
    }

    public async UniTaskVoid OnClickRecommendButton()
    {
        var response = await NetManager.Post<ResponseSavePacket>(new RequestSavePacket("{id: 234234}"));

        if (response.Result)
        {
            UnityEngine.Debug.Log("저장 성공");
        }
    }
}

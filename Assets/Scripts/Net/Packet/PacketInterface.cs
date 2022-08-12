using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public abstract class IRequestPacket
{
    [JsonIgnore]
    public string url { get; }

    public string DeviceId { get; private set; }
    
    
    protected IRequestPacket(string url)
    {
        this.url = url;
        
#if UNITY_WEBGL        
        if (!PlayerPrefs.HasKey("UniqueIdentifier"))
            PlayerPrefs.SetString("UniqueIdentifier", Guid.NewGuid().ToString());
        
        this.DeviceId = PlayerPrefs.GetString("UniqueIdentifier");        
#else
        this.DeviceId = UnityEngine.SystemInfo.deviceUniqueIdentifier;

#endif
    }
}

public class ResponsePacket
{
    [JsonProperty] public bool Result { get; private set; }
}

public class DataError
{
    [JsonProperty]
    public int code { get; private set; }
    
    [JsonProperty]
    public string message { get; private set; }
}

public class PacketErrorJson
{
    [JsonProperty]
    public bool result { get; private set; }
    [JsonProperty]
    public bool isInternalError { get; private set; }

    public static string CreateJson()
    {
        var inst = new PacketErrorJson()
        {
            result = false,
            isInternalError = true,
        };

        var json = JsonConvert.SerializeObject(inst);
        return json;
    }
}
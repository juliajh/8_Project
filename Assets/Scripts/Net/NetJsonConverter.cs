using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Debug = System.Diagnostics.Debug;


public class DoubleCurrencyJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return true;//objectType.IsSubclassOf(typeof(double));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return double.Parse((string)reader.Value);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue($"{value:E12}");
    }
}

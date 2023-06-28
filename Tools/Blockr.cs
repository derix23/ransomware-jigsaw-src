// Decompiled with JetBrains decompiler
// Type: Main.Tools.Blockr
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace Main.Tools
{
  internal static class Blockr
  {
    private static string BlockrAddress => "http://btc.blockr.io/api/v1/";

    internal static double GetPrice()
    {
      string string_0 = Blockr.smethod_0(Blockr.BlockrAddress, "coin/info/");
      JObject jobject = Blockr.smethod_3(Blockr.smethod_2(Blockr.smethod_1(), string_0));
      JToken object_0 = Blockr.smethod_4(jobject, "status");
      if (object_0 != null && Blockr.smethod_6(Blockr.smethod_5((object) object_0), "error"))
        throw Blockr.smethod_7(Blockr.smethod_5((object) jobject));
      return Blockr.smethod_8(Blockr.smethod_8(Blockr.smethod_4(jobject, "data"), (object) "markets"), (object) "coinbase").Value<double>((object) "value");
    }

    internal static double GetBalanceBtc(string address)
    {
      string string_0 = Blockr.smethod_9(Blockr.BlockrAddress, "address/balance/", address);
      JObject jobject = Blockr.smethod_3(Blockr.smethod_2(Blockr.smethod_1(), string_0));
      JToken object_0 = Blockr.smethod_4(jobject, "status");
      if (object_0 != null && Blockr.smethod_6(Blockr.smethod_5((object) object_0), "error"))
        throw Blockr.smethod_7(Blockr.smethod_5((object) jobject));
      return Blockr.smethod_4(jobject, "data").Value<double>((object) "balance");
    }

    static string smethod_0(string string_0, string string_1) => string_0 + string_1;

    static WebClient smethod_1() => new WebClient();

    static string smethod_2(WebClient webClient_0, string string_0) => webClient_0.DownloadString(string_0);

    static JObject smethod_3(string string_0) => JObject.Parse(string_0);

    static JToken smethod_4(JObject jobject_0, string string_0) => jobject_0[string_0];

    static string smethod_5(object object_0) => object_0.ToString();

    static bool smethod_6(string string_0, string string_1) => string_0 == string_1;

    static Exception smethod_7(string string_0) => new Exception(string_0);

    static JToken smethod_8(JToken jtoken_0, object object_0) => jtoken_0[object_0];

    static string smethod_9(string string_0, string string_1, string string_2) => string_0 + string_1 + string_2;
  }
}

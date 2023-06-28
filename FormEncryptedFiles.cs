// Decompiled with JetBrains decompiler
// Type: Main.FormEncryptedFiles
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Main.Tools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Main
{
  public class FormEncryptedFiles : Form
  {
    private IContainer components;
    private DataGridView dataGridViewEncryptedFiles;
    private DataGridViewTextBoxColumn ColumnDeleted;
    private DataGridViewTextBoxColumn ColumnPath;

    public FormEncryptedFiles() => this.InitializeComponent();

    private void FormEncryptedFiles_Load(object sender, EventArgs e)
    {
      foreach (string encryptedFile in Locker.GetEncryptedFiles())
      {
        if (FormEncryptedFiles.smethod_1(FormEncryptedFiles.smethod_0(encryptedFile, ".fun")))
          FormEncryptedFiles.smethod_3(FormEncryptedFiles.smethod_2(this.dataGridViewEncryptedFiles), new object[2]
          {
            (object) "",
            (object) encryptedFile
          });
        else
          FormEncryptedFiles.smethod_3(FormEncryptedFiles.smethod_2(this.dataGridViewEncryptedFiles), new object[2]
          {
            (object) "YES",
            (object) encryptedFile
          });
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        FormEncryptedFiles.smethod_4((IDisposable) this.components);
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dataGridViewEncryptedFiles = FormEncryptedFiles.smethod_5();
      this.ColumnDeleted = FormEncryptedFiles.smethod_6();
      this.ColumnPath = FormEncryptedFiles.smethod_6();
      FormEncryptedFiles.smethod_7((ISupportInitialize) this.dataGridViewEncryptedFiles);
      FormEncryptedFiles.smethod_8((Control) this);
      FormEncryptedFiles.smethod_9(this.dataGridViewEncryptedFiles, DataGridViewColumnHeadersHeightSizeMode.AutoSize);
      FormEncryptedFiles.smethod_11(FormEncryptedFiles.smethod_10(this.dataGridViewEncryptedFiles), new DataGridViewColumn[2]
      {
        (DataGridViewColumn) this.ColumnDeleted,
        (DataGridViewColumn) this.ColumnPath
      });
      FormEncryptedFiles.smethod_12((Control) this.dataGridViewEncryptedFiles, DockStyle.Fill);
      this.dataGridViewEncryptedFiles.Location = new Point(0, 0);
      this.dataGridViewEncryptedFiles.Name = "dataGridViewEncryptedFiles";
      this.dataGridViewEncryptedFiles.Size = new Size(594, 326);
      this.dataGridViewEncryptedFiles.TabIndex = 0;
      this.ColumnDeleted.HeaderText = "Deleted";
      this.ColumnDeleted.Name = "ColumnDeleted";
      this.ColumnDeleted.ReadOnly = true;
      this.ColumnDeleted.Width = 50;
      this.ColumnPath.HeaderText = "Path";
      this.ColumnPath.Name = "ColumnPath";
      this.ColumnPath.ReadOnly = true;
      this.ColumnPath.Width = 500;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(594, 326);
      this.Controls.Add((Control) this.dataGridViewEncryptedFiles);
      this.Name = nameof (FormEncryptedFiles);
      this.Text = "EncryptedFiles";
      this.Load += new EventHandler(this.FormEncryptedFiles_Load);
      ((ISupportInitialize) this.dataGridViewEncryptedFiles).EndInit();
      this.ResumeLayout(false);
    }

    static string smethod_0(string string_0, string string_1) => string_0 + string_1;

    static bool smethod_1(string string_0) => File.Exists(string_0);

    static DataGridViewRowCollection smethod_2(DataGridView dataGridView_0) => dataGridView_0.Rows;

    static int smethod_3(
      DataGridViewRowCollection dataGridViewRowCollection_0,
      object[] object_0)
    {
      return dataGridViewRowCollection_0.Add(object_0);
    }

    static void smethod_4(IDisposable idisposable_0) => idisposable_0.Dispose();

    static DataGridView smethod_5() => new DataGridView();

    static DataGridViewTextBoxColumn smethod_6() => new DataGridViewTextBoxColumn();

    static void smethod_7(ISupportInitialize isupportInitialize_0) => isupportInitialize_0.BeginInit();

    static void smethod_8(Control control_0) => control_0.SuspendLayout();

    static void smethod_9(
      DataGridView dataGridView_0,
      DataGridViewColumnHeadersHeightSizeMode dataGridViewColumnHeadersHeightSizeMode_0)
    {
      dataGridView_0.ColumnHeadersHeightSizeMode = dataGridViewColumnHeadersHeightSizeMode_0;
    }

    static DataGridViewColumnCollection smethod_10(DataGridView dataGridView_0) => dataGridView_0.Columns;

    static void smethod_11(
      DataGridViewColumnCollection dataGridViewColumnCollection_0,
      DataGridViewColumn[] dataGridViewColumn_0)
    {
      dataGridViewColumnCollection_0.AddRange(dataGridViewColumn_0);
    }

    static void smethod_12(Control control_0, DockStyle dockStyle_0) => control_0.Dock = dockStyle_0;
  }
}

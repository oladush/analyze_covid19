// Decompiled with JetBrains decompiler
// Type: hidden_tear.Form2
// Assembly: VapeHacksLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 630DF1DB-C121-457B-BCEC-9948B868FD96
// Assembly location: C:\Users\user\volal\dumps\executable.3720.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace hidden_tear
{
  public class Form2 : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox textBox1;
    private Button button1;

    public Form2() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      int num = (int) new Form3().ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form2));
      this.textBox1 = new TextBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.textBox1.BackColor = Color.Black;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.Red;
      this.textBox1.Location = new Point(302, 61);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(407, 392);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = componentResourceManager.GetString("textBox1.Text");
      this.button1.BackColor = Color.Black;
      this.button1.Location = new Point(742, 425);
      this.button1.Name = "button1";
      this.button1.Size = new Size(241, 78);
      this.button1.TabIndex = 1;
      this.button1.Text = "Next,";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(1010, 537);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox1);
      this.ForeColor = Color.Red;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Form2);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

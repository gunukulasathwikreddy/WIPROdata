using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part2Reflections
{
    internal class E_MessageBoxEg
    {
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int ShowMessageBox(int hwnd, string text, string caption, uint type);

        static void Main()
        {
            E_MessageBoxEg.ShowMessageBox(0, "Welcome to Reflection", "MessageBox", 0);
        }
    }
}

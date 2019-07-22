using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teset2
{
    public class HookKeyBoard
    {
        private enum HookType
        {
            WH_CALLWNDPROC = 4, 
            WH_CALLWNDPROCRET = 12, 
            WH_CBT = 5, 
            WH_DEBUG = 9, 
            WH_FOREGROUNDIDLE = 11, 
            WH_GETMESSAGE = 3, 
            WH_HARDWARE = 8, 
            WH_JOURNALPLAYBACK = 1, 
            WH_JOURNALRECORD = 0,
            WH_KEYBOARD = 2,
            WH_MOUSE = 7,
            WH_MSGFILTER = (-1), 
            WH_SHELL = 10,
            WH_SYSMSGFILTER = 6,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14,
        }

        private const int WM_KEYUP = 0X101;
        private const int WM_SYSKEYUP = 0X105;

        private delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        private int KeyHook;

       // private int MouseHook;

        public event KeyEventHandler keyeventhandler;

        [StructLayout(LayoutKind.Sequential)]
        private class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //set hook 
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //unhook 
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook); 

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name); 

        [DllImport("user32", EntryPoint = "GetMessage")]
        public static extern int GetMessage(  
                        out tagMSG lpMsg,
                        IntPtr hwnd,
                        int wMsgFilterMin,
                        int wMsgFilterMax
        );
        [DllImport("user32", EntryPoint = "DispatchMessage")]
        public static extern int DispatchMessage(ref tagMSG lpMsg); 

        [DllImport("user32", EntryPoint = "TranslateMessage")]
        public static extern int TranslateMessage(ref tagMSG lpMsg); 
        public struct tagMSG
        {
            public int hwnd;
            public uint message;
            public int wParam;
            public long lParam;
            public uint time;
            public int pt;
        }


        public void InstallHook(Window2 window)
        {
            if (KeyHook.Equals(0))
            {
                HookProc hp = new HookProc(KeyMouseHookProc);
                KeyHook = SetWindowsHookEx((int)HookType.WH_KEYBOARD_LL,
                          hp,
                        GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
               // MouseHook = SetWindowsHookEx((int)HookType.WH_MOUSE_LL, hp,
                  //  GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
            }
            if (KeyHook.Equals(0))
            {
                Hook_Clear();
                throw new Exception("Install fail");
            }
        }

        /// <summary>
    
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int KeyMouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (keyeventhandler != null && nCode >= 0)
            {
                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)kbh.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    keyeventhandler(this, e);
                }
            }
            return 1;
        }

        //clear hook 
        public void Hook_Clear()
        {
            bool retKeyboard = true;
            if (!KeyHook.Equals(0))
            {
                retKeyboard = UnhookWindowsHookEx(KeyHook);
                //if (retKeyboard) retKeyboard = UnhookWindowsHookEx(MouseHook);
            }
            //if clear hook fail
            if (!retKeyboard) throw new Exception("UnhookWindowsHookEx failed.");
        }
    }
}

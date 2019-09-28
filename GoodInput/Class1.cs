using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace GoodInput
{
    public class Mic
    {
        //Do Click
        public enum ClickOption
        {
            LeftDown,
            LeftUp,
            LeftDownUp,
            RightDown,
            RightUp,
            RightDownUp
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        //Move Mic
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        //Do Click
        public void Click (ClickOption option)
        {
            switch (option)
            {
                case ClickOption.LeftDown:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    break;
                case ClickOption.LeftUp:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    break;
                case ClickOption.LeftDownUp:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    break;
                case ClickOption.RightDown:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    break;
                case ClickOption.RightUp:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    break;
                case ClickOption.RightDownUp:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    break;
            }
        }

        //Move Cursor
        public void Move(int X, int Y)
        {
            SetCursorPos(X, Y);
        }

        public ClickOption GetClickState()
        {
            return ClickOption.RightDownUp;
        }
    }
}

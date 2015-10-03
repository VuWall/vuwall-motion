﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace vuwall_motion
{
    public class WindowApi
    {
        public Window WindowFromPoint(Point p)
        {
            var ptr = _WindowFromPoint(p);
            Rectangle rect;
            _GetWindowRect(ptr, out rect);
            return new Window(ptr, rect);
        }

        public void SetWindow(Window window)
        {
            _SetWindowPos(window.Ptr, 0, window.Area.X, window.Area.Y, window.Area.Width, window.Area.Height, 0x0040);
        }

        public void BringToFront(Window window)
        {
            _SetForegroundWindow(window.Ptr);
        }

        public Window GetForegroundWindow()
        {
            var ptr = _GetForegroundWindow();
            Rectangle rect;
            _GetWindowRect(ptr, out rect);
            return new Window(ptr, rect);
        }

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        public static extern IntPtr _WindowFromPoint(Point point);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr _SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern IntPtr _GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern IntPtr _SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr _GetForegroundWindow();
    }
}
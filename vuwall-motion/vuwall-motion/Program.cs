﻿using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Discovery;
using MyoSharp.Exceptions;
using MyoSharp.Math;
using MyoSharp.Poses;

namespace vuwall_motion {
    static class Program {
        private static void Main()
        {
            var Myo = new MyoApi();
            var form = new TransparentForm();
            Myo.Connect(() =>
            {
                Application.Run(form);
                return false;
            });
        }
    }
}

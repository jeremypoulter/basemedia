﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixIO.IO.Bmff
{
    [Flags]
    public enum BaseMediaOptions
    {
        None,
        CacheAllBoxes,
        CacheAllBoxContent,
        LoadChildren,
    }
}

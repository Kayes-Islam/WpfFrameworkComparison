﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interactions
{
    public interface IDialogHandle
    {
        void CloseDialog(bool? dialogResult);
    }
}

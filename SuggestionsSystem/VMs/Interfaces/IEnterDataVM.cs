﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionsSystem.VMs.Interfaces
{
    public interface IEnterDataVM : IBaseVM
    {
        void GetSuggestions(string paramID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionsSystem.Interfaces
{
    public interface IBaseVM
    {
        void FocusSuggestionsBox();
        void SelectSuggestion();
        void SelectedSuggestionChanged();
    }
}

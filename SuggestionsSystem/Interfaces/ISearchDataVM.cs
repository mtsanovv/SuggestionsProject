using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionsSystem.Interfaces
{
    public interface ISearchDataVM : IBaseVM
    {
        void TriggerSuggestions(string paramID, bool shouldTrySavingSuggestion = false);
        IList<string> GetListRelatedToParamID(string paramID);
        string GetFileRelatedToParamID(string paramID);
    }
}

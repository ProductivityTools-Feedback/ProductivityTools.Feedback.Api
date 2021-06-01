using PSTeamManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WCFService
{
    public class Dictionary
    {
        public DictValue GetDictValueByKey(string dictionaryKey, string dictValueKey)
        {
            TeamFeadbackEntities DbContext = new ContextFactory().CreateNewContext();
            var dictValue = from dv in DbContext.DictValue
                            join d in DbContext.Dictionary on dv.DictonaryId equals d.DictonaryId
                            where d.Name == dictionaryKey && dv.Key == dictValueKey
                            select dv;
            return dictValue.Single();
        }

        public int GetDictValueIdByKey(string dictionaryKey, string dictValueKey)
        {
            var x = GetDictValueByKey(dictionaryKey, dictValueKey);
            return x.DictValueId;
        }

    }
}

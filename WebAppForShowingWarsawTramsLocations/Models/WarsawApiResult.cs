using System.Collections.Generic;

namespace WebAppForShowingWarsawTramsLocalization.Models
{
    public class WarsawApiResult
    {
        public List<WebTramLocation> result = new List<WebTramLocation>();

        public WarsawApiResult(WebTramLocation loc)
        {
            result.Add(loc);
        }
    }
}

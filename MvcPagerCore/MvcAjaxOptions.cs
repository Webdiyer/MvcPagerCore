/* MvcPager source code
This file is part of MvcPager.
Copyright 2009-2015 Webdiyer(http://en.webdiyer.com)
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Webdiyer.WebControls.AspNetCore
{
    ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Classes/Class[@name="MvcAjaxOptions"]/*'/>
    public class MvcAjaxOptions
    {
        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/MvcAjaxOptions/Property[@name="EnablePartialLoading"]/*'/>
        public bool EnablePartialLoading { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/MvcAjaxOptions/Property[@name="DataFormId"]/*'/>
        public string DataFormId { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/MvcAjaxOptions/Property[@name="AllowCache"]/*'/>
        public bool AllowCache { get; set; } = true;


        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/MvcAjaxOptions/Property[@name="EnableHistorySupport"]/*'/>
        public bool EnableHistorySupport { get; set; } = true;

        public string Confirm { get; set; }

        public string HttpMethod { get; set; }

        public int LoadingElementDuration { get; set; }

        public string LoadingElementId { get; set; }

        public string OnBegin { get; set; } = string.Empty;

        public string OnComplete { get; set; } = string.Empty;

        public string OnFailure { get; set; } = string.Empty;

        public string OnSuccess { get; set; } = string.Empty;

        public string UpdateTargetId { get; set; }

        public IDictionary<string, object> ToUnobtrusiveHtmlAttributes()
        {
            var result = new Dictionary<string, object>
            {
                { "data-ajax", "true" },
            };

            PagerBuilder.AddToDictionaryIfNotEmpty(result, "data-ajax-method", HttpMethod);
            PagerBuilder.AddToDictionaryIfNotEmpty(result, "data-ajax-confirm", Confirm);
            PagerBuilder.AddToDictionaryIfNotEmpty(result, "data-ajax-begin", OnBegin);
            PagerBuilder.AddToDictionaryIfNotEmpty(result, "data-ajax-complete", OnComplete);
            PagerBuilder.AddToDictionaryIfNotEmpty(result, "data-ajax-failure", OnFailure);
            PagerBuilder.AddToDictionaryIfNotEmpty(result, "data-ajax-success", OnSuccess);

            if (!string.IsNullOrWhiteSpace(DataFormId))
            {
                result.Add("data-ajax-search-form", PagerBuilder.EscapeIdSelector(DataFormId));
            }
            if (!String.IsNullOrWhiteSpace(LoadingElementId))
            {
                result.Add("data-ajax-loading", PagerBuilder.EscapeIdSelector(LoadingElementId.Trim('#')));

                if (LoadingElementDuration > 0)
                {
                    result.Add("data-ajax-loading-duration", LoadingElementDuration);
                }
            }
            if (!String.IsNullOrWhiteSpace(UpdateTargetId))
            {
                result.Add("data-ajax-update", PagerBuilder.EscapeIdSelector(UpdateTargetId.Trim('#')));
            }
            if (EnablePartialLoading)
            {
                result.Add("data-ajax-partial-loading", "true");
            }
            if (!AllowCache)
            {
                result.Add("data-ajax-cache", "false");
            }
            if (!EnableHistorySupport)
                result.Add("data-ajax-history", "false");

            return result;
        }
        

    }
}

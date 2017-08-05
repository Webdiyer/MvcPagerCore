/* MvcPager source code
This file is part of MvcPager.
Copyright 2009-2017 Webdiyer(http://en.webdiyer.com)
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
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Webdiyer.WebControls.AspNetCore
{
    [HtmlTargetElement("mvcpager")]
    public partial class MvcPagerTagHelper:TagHelper
    {
        private const string ActionAttributeName = "asp-action";
        private const string AreaAttributeName = "asp-area";
        private const string ControllerAttributeName = "asp-controller";
        private const string RouteAttributeName = "asp-route";
        private const string RouteValuesDictionaryName = "asp-all-route-data";
        private const string RouteValuesPrefix = "asp-route-";
        
        private int _totalPageCount = 1;
        private int _pageIndex;


        IUrlHelperFactory _urlHelperFactory;
        public MvcPagerTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            //if(!int.TryParse((string)ViewContext.RouteData.Values[PageIndexParameterName],out _pageIndex)){
            //    _pageIndex = 1;
            //}
                        
            if(DataSource==null)
                throw new ArgumentNullException(nameof(DataSource));
            int actualPageCount = (int) Math.Ceiling(DataSource.TotalItemCount/(double) DataSource.PageSize);
            _pageIndex = DataSource.CurrentPageIndex;
            if (MaximumPageNumber == 0 || MaximumPageNumber >actualPageCount)
                _totalPageCount = actualPageCount;
            else
                _totalPageCount = MaximumPageNumber;

            PagerBuilder pb;
            if (AjaxEnabled)
            {
                pb = new PagerBuilder(ViewContext,_urlHelperFactory.GetUrlHelper(ViewContext), _totalPageCount, _pageIndex, Options, AjaxOptions);
            }
            else
            {
                pb = new PagerBuilder(ViewContext, _urlHelperFactory.GetUrlHelper(ViewContext), _totalPageCount, _pageIndex, Options);
            }
            var content=pb.GenerateHtml();
            output.TagName = string.Empty;
            output.Content = new DefaultTagHelperContent().SetHtmlContent(content);

            //output.PreElement.SetHtmlContent(_copyrightText);
            //output.TagName = TagName;
            //_content = new DefaultTagHelperContent();
            //output.Content = _content.SetHtmlContent(buildPager(output));
            //output.PostElement.SetHtmlContent(_copyrightText);
        }
        
    }
}

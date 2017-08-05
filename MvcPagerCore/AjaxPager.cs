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

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace Webdiyer.WebControls.AspNetCore
{
    ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Classes/Class[@name="AjaxPager"]/*'/>
    public class AjaxPager : IHtmlContent
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly int _currentPageIndex;
        private readonly int _pageSize;
        private readonly int _totalItemCount;
        private PagerOptions _pagerOptions;
        private MvcAjaxOptions _ajaxOptions;

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/AjaxPager/Constructor[@name="AjaxPager1"]/*'/>
        public AjaxPager(IHtmlHelper html, int totalItemCount, int pageSize, int pageIndex,PagerOptions pagerOptions, MvcAjaxOptions ajaxOptions)
        {
            _htmlHelper = html;
            _totalItemCount = totalItemCount;
            _pageSize = pageSize;
            _currentPageIndex = pageIndex;
            _pagerOptions = pagerOptions;
            _ajaxOptions = ajaxOptions;
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/AjaxPager/Constructor[@name="AjaxPager2"]/*'/>
        public AjaxPager(IHtmlHelper ajax, IPagedList pagedList,PagerOptions pagerOptions, MvcAjaxOptions ajaxOptions)
            : this(ajax, pagedList.TotalItemCount, pagedList.PageSize, pagedList.CurrentPageIndex,pagerOptions, ajaxOptions) { }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/AjaxPager/Method[@name="Options"]/*'/>
        public AjaxPager Options(Action<PagerOptionsBuilder> builder)
        {
            if (_pagerOptions == null)
            {
                _pagerOptions = new PagerOptions();
            }
            builder(new PagerOptionsBuilder(_pagerOptions));
            return this;
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/AjaxPager/Method[@name="AjaxOptions"]/*'/>
        public AjaxPager AjaxOptions(Action<MvcAjaxOptionsBuilder> builder)
        {
            if (_ajaxOptions == null)
            {
                _ajaxOptions = new MvcAjaxOptions();
            }
            builder(new MvcAjaxOptionsBuilder(_ajaxOptions));
            return this;
        }
        
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var totalPageCount = (int)Math.Ceiling(_totalItemCount / (double)_pageSize);
            writer.Write(new PagerBuilder(_htmlHelper.ViewContext,new UrlHelper(_htmlHelper.ViewContext), totalPageCount, _currentPageIndex, _pagerOptions,_ajaxOptions).GenerateHtml());
        }
    }
}

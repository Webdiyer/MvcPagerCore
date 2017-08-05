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

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace Webdiyer.WebControls.AspNetCore
{
    ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Classes/Class[@name="HtmlPager"]/*'/>
    public class HtmlPager:IHtmlContent
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly int _currentPageIndex;
        private readonly int _pageSize;
        private readonly int _totalItemCount;
        private PagerOptions _pagerOptions;

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/HtmlPager/Constructor[@name="HtmlPager1"]/*'/>
        public HtmlPager(IHtmlHelper html, int totalItemCount, int pageSize, int pageIndex,PagerOptions pagerOptions)
        {
            _htmlHelper = html;
            _totalItemCount = totalItemCount;
            _pageSize = pageSize;
            _currentPageIndex = pageIndex;
            _pagerOptions = pagerOptions;
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/HtmlPager/Constructor[@name="HtmlPager2"]/*'/>
        public HtmlPager(IHtmlHelper html, int totalItemCount, int pageSize, int pageIndex):this(html,totalItemCount,pageSize,pageIndex,null){}

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/HtmlPager/Constructor[@name="HtmlPager3"]/*'/>
        public HtmlPager(IHtmlHelper html, IPagedList pagedList,PagerOptions pagerOptions) : this(html, pagedList.TotalItemCount, pagedList.PageSize, pagedList.CurrentPageIndex,pagerOptions) { }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/HtmlPager/Constructor[@name="HtmlPager4"]/*'/>
        public HtmlPager(IHtmlHelper html, IPagedList pagedList):this(html, pagedList.TotalItemCount, pagedList.PageSize, pagedList.CurrentPageIndex){}


        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/HtmlPager/Method[@name="Options"]/*'/>
        public HtmlPager Options(Action<PagerOptionsBuilder> builder)
        {
            if (_pagerOptions == null)
            {
                _pagerOptions = new PagerOptions();
            }
            builder(new PagerOptionsBuilder(_pagerOptions));
            return this;
        }

        
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var totalPageCount = (int)Math.Ceiling(_totalItemCount / (double)_pageSize);
            writer.Write(new PagerBuilder(_htmlHelper.ViewContext,new UrlHelper(_htmlHelper.ViewContext), totalPageCount, _currentPageIndex, _pagerOptions).GenerateHtml());
        }
    }

}

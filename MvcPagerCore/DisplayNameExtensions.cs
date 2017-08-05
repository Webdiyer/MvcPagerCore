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
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Webdiyer.WebControls.AspNetCore
{
    ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Classes/Class[@name="DisplayNameExtensions"]/*'/>
    public static class DisplayNameExtensions
    {
        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/DisplayNameExtensions/Method[@name="DisplayNameFor"]/*'/>
        public static string DisplayNameFor<TModel, TValue>(this IHtmlHelper<PagedList<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.DisplayNameForInnerType<TModel, TValue>(expression);
        }
    }
}

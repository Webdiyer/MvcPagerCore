# MvcPagerCore
MvcPager
MvcPager is a free and open source paging component for ASP.NET Core MVC, it expose a series of extension methods for using in ASP.NET Core MVC applications. It support both tag helper and Html extension method syntax:

### Html extension method syntax:
@Html.Pager(Model)

### TagHelper syntax:
&lt;mvcpager asp-model="@Model" ajax-enabled="true" ajax-update-target="orders"&gt;&lt;/mvcpager&gt;

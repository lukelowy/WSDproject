#pragma checksum "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e4f5d875f13ac3308203501e91b5e4b130af6cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Hotelone19301408.Pages.Bookings.Pages_Bookings_MyBookings), @"mvc.1.0.razor-page", @"/Pages/Bookings/MyBookings.cshtml")]
namespace Hotelone19301408.Pages.Bookings
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\_ViewImports.cshtml"
using Hotelone19301408;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\_ViewImports.cshtml"
using Hotelone19301408.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e4f5d875f13ac3308203501e91b5e4b130af6cb", @"/Pages/Bookings/MyBookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d4d8185774a5fdb218636d09a3b8621f80cd84b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Bookings_MyBookings : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "BookARoom", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My Bookings</h1>\r\n");
#nullable restore
#line 9 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
 if (Model.Booking != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
     if (Model.Booking.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br>\r\n        <h4>\r\n            You have not made an order.\r\n        </h4>\r\n");
#nullable restore
#line 17 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e4f5d875f13ac3308203501e91b5e4b130af6cb4990", async() => {
                WriteLiteral("Create New Booking");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                   Write(Html.DisplayNameFor(model => model.Booking[0].TheCustomer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 30 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                   Write(Html.DisplayNameFor(model => model.Booking[0].TheRoom.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e4f5d875f13ac3308203501e91b5e4b130af6cb7042", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 34 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.Booking[0].CheckIn));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortorder", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                                                     WriteLiteral(ViewData["CheckInPriceOrder"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortorder"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortorder", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortorder"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 38 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                   Write(Html.DisplayNameFor(model => model.Booking[0].CheckOut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e4f5d875f13ac3308203501e91b5e4b130af6cb10047", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 42 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.Booking[0].Cost));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortorder", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                                                     WriteLiteral(ViewData["PriceOrder"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortorder"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortorder", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortorder"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 48 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                 foreach (var item in Model.Booking)
                {
                    if (item.CustomerEmail == (string)ViewData["Email"])
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 54 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.TheCustomer.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 57 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.RoomID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 60 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CheckIn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 63 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CheckOut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 66 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"

                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 75 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\shirl\OneDrive\Documents\GitHub\WSDproject\Pages\Bookings\MyBookings.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hotelone19301408.Pages.Bookings.MyBookingsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hotelone19301408.Pages.Bookings.MyBookingsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hotelone19301408.Pages.Bookings.MyBookingsModel>)PageContext?.ViewData;
        public Hotelone19301408.Pages.Bookings.MyBookingsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

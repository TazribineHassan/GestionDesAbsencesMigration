#pragma checksum "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acc6a126f443f0cd6b906ed0b32d4bc56eafe4e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Home), @"mvc.1.0.view", @"/Views/Admin/Home.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\_ViewImports.cshtml"
using GestionDesAbsencesMigration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\_ViewImports.cshtml"
using GestionDesAbsencesMigration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc6a126f443f0cd6b906ed0b32d4bc56eafe4e6", @"/Views/Admin/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430ddb756b39511dc01748ceee86d9af80471367", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\Home.cshtml"
  
    ViewBag.Title = "Home";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <!-- Solde -->
    <div class=""row"">
        <div class=""col-md-5 mb-4"" >
            <div class=""card shadow h-100 py-2"" style=""border-left: 5px solid #3445b4"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-gray-800 text-uppercase mb-1"">
                                Nombre d'absences d'aujourd'huit
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-danger"">20</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-calendar-times fa-2x text-danger""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-1""></div>
        <div class=""col-md-6 shadow text-center""");
            WriteLiteral(" >\r\n            <div id=\"chart_div\" class=\"text-center\"></div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    
    <script>
        var jasonData = {}; 
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(function () {

            $.ajax({
                url: 'CycleChart',
                dataType: ""json"",
                type: ""GET"",
                error: function (xhr, status, error) {
                    var err = eval(""("" + xhr.responseText + "")"");
                    toastr.error(err.message);
                },
                success: function (data) {
                    var dataArray = new google.visualization.DataTable();
                    dataArray.addColumn('string', 'Cycle');
                    dataArray.addColumn('number', 'Nombre absence');
                    dataArray.addRows([
                        ['CP', data.CP],
                        ['CI', data.CI]
                    ]);

                    var options = ");
                WriteLiteral(@"{
                        'title': 'Nombres absence par semaine',
                    };
                    var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
                    chart.draw(dataArray, options);
                }
            });
        });

    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

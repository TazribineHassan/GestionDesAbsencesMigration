#pragma checksum "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50da02ad5b777088590382182ea17c1cb864d4dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professeur_Profil), @"mvc.1.0.view", @"/Views/Professeur/Profil.cshtml")]
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
#line 6 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
using GestionDesAbsencesMigration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50da02ad5b777088590382182ea17c1cb864d4dd", @"/Views/Professeur/Profil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430ddb756b39511dc01748ceee86d9af80471367", @"/Views/_ViewImports.cshtml")]
    public class Views_Professeur_Profil : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Professeur>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
  
    ViewData["Title"] = "Profil";
    Layout = "~/Views/Shared/ProfesseurLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""row justify-content-center "">
    <div class=""col-md-8 pt-3"">
        <div class=""card bg-light shadow"">
            <div class=""card-header font-weight-bolder  btn btn-primary text-center"">
                Informations
            </div>
            <div class=""card-body"">
                <div class=""card-text mb-3 pb-2 border-bottom"">ID : <strong class=""text-secondary  font-weight-bold mx-5"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
#nullable restore
#line 16 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
                                                                                                                                                                     Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n                <div class=\"card-text mb-3 pb-2 border-bottom\">Nom : <strong class=\"text-secondary font-weight-bold mx-5\">&nbsp;&nbsp;&nbsp; ");
#nullable restore
#line 17 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
                                                                                                                                        Write(Model.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n                <div class=\"card-text mb-3 pb-2 border-bottom\">Prénom : <strong class=\"text-secondary font-weight-bold mx-5\">");
#nullable restore
#line 18 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
                                                                                                                        Write(Model.Prenom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n                <div class=\"card-text mb-3 pb-2 border-bottom\">\r\n                    Modules :\r\n                    <ul >\r\n");
#nullable restore
#line 22 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
                         foreach (var item in Model.Modules)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"mr-5\"><strong class=\"text-success mx-3\">");
#nullable restore
#line 24 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
                                                                          Write(item.NomModule);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></li>\r\n");
#nullable restore
#line 25 "C:\Users\admin\source\repos\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Profil.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Professeur> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a725f7855c286bfb1a300e15f8b45c4fe302ca0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professeur_Index), @"mvc.1.0.view", @"/Views/Professeur/Index.cshtml")]
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
#line 1 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\_ViewImports.cshtml"
using GestionDesAbsencesMigration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
using GestionDesAbsencesMigration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a725f7855c286bfb1a300e15f8b45c4fe302ca0b", @"/Views/Professeur/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430ddb756b39511dc01748ceee86d9af80471367", @"/Views/_ViewImports.cshtml")]
    public class Views_Professeur_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SeancesForProf>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
  
    ViewData["Title"] = "Accueil";
    Layout = "~/Views/Shared/ProfesseurLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 10 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
  
    string[] color_list = { "info", "warning", "success", "danger" };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row justify-content-center py-5 \">\r\n    <div class=\"col-md-8 btn btn-outline-danger\">\r\n        ");
#nullable restore
#line 17 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
   Write(Model.First().Semaine.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 17 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                                 Write(Model.Last().Date.ToString("dddd-MM-yyyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row justify-content-center \">\r\n");
#nullable restore
#line 22 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
     foreach ((SeancesForProf item, Int32 i) in Model.Select((value, i) => (value, i)))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-3 pt-3\">\r\n            <div class=\"card bg-light shadow\">\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 708, "\"", 769, 5);
            WriteAttributeValue("", 716, "card-header", 716, 11, true);
            WriteAttributeValue(" ", 727, "text-white", 728, 11, true);
            WriteAttributeValue(" ", 738, "bg-", 739, 4, true);
#nullable restore
#line 26 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
WriteAttributeValue("", 742, color_list[@i], 742, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 757, "text-center", 758, 12, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                                                                              Write(item.Seance.HeurDebut);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 26 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                                                                                                       Write(item.Seance.HeurFin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title text-center\">Module: <span class=\"text-primary\">");
#nullable restore
#line 28 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                                                                                     Write(item.Module.NomModule);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h5>\r\n                    <ul>\r\n");
#nullable restore
#line 30 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                         foreach (var classe in item.Classes)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"card-text \">");
#nullable restore
#line 32 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                                              Write(classe.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 33 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </ul>\r\n\r\n");
#nullable restore
#line 37 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                     using (Html.BeginForm("Notez", "Professeur", FormMethod.Get))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"hidden\" name=\"id_semaine\"");
            BeginWriteAttribute("value", " value=\"", 1403, "\"", 1436, 1);
#nullable restore
#line 39 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
WriteAttributeValue("", 1411, Model.First().Semaine.id, 1411, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"id_seance\"");
            BeginWriteAttribute("value", " value=\"", 1503, "\"", 1526, 1);
#nullable restore
#line 40 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
WriteAttributeValue("", 1511, item.Seance.id, 1511, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"id_module\"");
            BeginWriteAttribute("value", " value=\"", 1593, "\"", 1616, 1);
#nullable restore
#line 41 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
WriteAttributeValue("", 1601, item.Module.Id, 1601, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input type=\"submit\"");
            BeginWriteAttribute("class", " class=\"", 1666, "\"", 1705, 3);
            WriteAttributeValue("", 1674, "btn", 1674, 3, true);
            WriteAttributeValue(" ", 1677, "btn-outline-", 1678, 13, true);
#nullable restore
#line 42 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
WriteAttributeValue("", 1690, color_list[@i], 1690, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"name\" value=\"Notez\" />\r\n");
#nullable restore
#line 43 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 47 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Professeur\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SeancesForProf>> Html { get; private set; }
    }
}
#pragma warning restore 1591

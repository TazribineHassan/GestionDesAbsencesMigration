#pragma checksum "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d13026ff1321f54a53c1248a3a243d7f4edb98d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AllEtudiants), @"mvc.1.0.view", @"/Views/Admin/AllEtudiants.cshtml")]
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
#line 2 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\_ViewImports.cshtml"
using GestionDesAbsencesMigration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d13026ff1321f54a53c1248a3a243d7f4edb98d", @"/Views/Admin/AllEtudiants.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430ddb756b39511dc01748ceee86d9af80471367", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AllEtudiants : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GestionDesAbsencesMigration.Models.Etudiant>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/datatables/css/jquery.dataTables.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/datatables/js/jquery.dataTables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
  
    ViewBag.Title = "La liste des étudiants";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Style", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d13026ff1321f54a53c1248a3a243d7f4edb98d6050", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"

<div class=""row justify-content-center "">
    <div class=""col-md-10 pt-3"">
        <div class=""card bg-light shadow"">
            <div class=""card-body"">
                <button class=""btn btn-primary mb-3"" data-toggle=""modal"" data-target=""#addStudentModal""><i class=""fas fa-user-plus""></i> Ajouter un etudiant</button>
                <table id=""myTable"" class=""table table-hover"">
                    <thead>
                        <tr>
                            <th class=""text-primary"">CNE</th>
                            <th class=""text-primary"">Nom</th>
                            <th class=""text-primary"">Prénom</th>
                            <th class=""text-primary"">Email</th>
                            <th class=""text-primary "">Classe</th>
                            <th class=""text-primary "">Groupe</th>
                            <th class=""text-primary text-center"">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 30 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 33 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                               Write(Html.DisplayFor(c => item.Cne));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 34 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                               Write(Html.DisplayFor(c => item.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 35 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                               Write(Html.DisplayFor(c => item.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 36 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                               Write(Html.DisplayFor(c => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 37 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                               Write(Html.DisplayFor(c => item.Classe.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                               Write(Html.DisplayFor(c => item.Groupe.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"text-center\">\r\n                                    <div class=\"btn-group\">\r\n                                        <button");
            BeginWriteAttribute("value", " value=\"", 2031, "\"", 2047, 1);
#nullable restore
#line 41 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
WriteAttributeValue("", 2039, item.Id, 2039, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"editbutton btn btn-outline-primary \"> <i class=\"fa fa-edit\"></i> </button>\r\n                                        <button");
            BeginWriteAttribute("value", " value=\"", 2179, "\"", 2195, 1);
#nullable restore
#line 42 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
WriteAttributeValue("", 2187, item.Id, 2187, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""deleteButton btn btn-outline-danger"" data-toggle=""modal"" data-target=""#deleteModal"" > <i class=""fas fa-trash-alt""></i> </button>
                                    </div>
                                </td>
                            </tr>
");
#nullable restore
#line 46 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""addStudentModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalScrollableTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-scrollable"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header text-center"" style=""background-color:#44bef1; text-align:center"">
                <h5 class=""modal-title""  style=""text-align: center;"" id=""exampleModalScrollableTitle"">Ajouter un nouveau etudiant</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
");
#nullable restore
#line 65 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                 using (Html.BeginForm("SaveEtudiant", "Admin", FormMethod.Post, new { @class = "my_from" }))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""modal-body"">
                        <div class=""form-group"">
                            <label for=""cne"">CNE</label>
                            <input type=""text"" class=""form-control border"" id=""cne"" name=""cne"" placeholder=""Cne"">
                        </div>
                        <div class=""form-group"">
                            <label for=""nom"">Nom</label>
                            <input type=""text"" class=""form-control border"" id=""nom"" name=""nom"" placeholder=""Nom"">
                        </div>
                        <div class=""form-group"">
                            <label for=""preom"">Prenom</label>
                            <input type=""text"" class=""form-control border"" id=""prenom"" name=""prenom"" placeholder=""Preom"">
                        </div>
                        <div class=""form-group"">
                            <label for=""email"">Email address</label>
                            <input type=""email"" class=""form-control border"" id=""");
            WriteLiteral("email\" name=\"email\" aria-describedby=\"emailHelp\" placeholder=\"Enter email\" />\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label>Cycle</label>\r\n                            ");
#nullable restore
#line 86 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                       Write(Html.DropDownList("liste_cycle", ViewBag.list as SelectList, "Selectionnez le cycle", new { id = "liste_cycle", @class = "form-control border" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        </div>
                        <div class=""form-group"">
                            <label>Classe</label>
                            <select class=""form-control border"" id=""classe"" name=""classe""></select>
                        </div>
                        <div class=""form-group"">
                            <label>Groupe</label>
                            <select class=""form-control border"" id=""groupe"" name=""groupe"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d13026ff1321f54a53c1248a3a243d7f4edb98d15806", async() => {
                WriteLiteral("1");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d13026ff1321f54a53c1248a3a243d7f4edb98d16993", async() => {
                WriteLiteral("2");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d13026ff1321f54a53c1248a3a243d7f4edb98d18180", async() => {
                WriteLiteral("3");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d13026ff1321f54a53c1248a3a243d7f4edb98d19367", async() => {
                WriteLiteral("4");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </select>
                        </div>

                    </div>
                    <div class=""modal-footer"">
                        <input type=""submit"" class=""btn btn-primary"" id=""submit"" value=""Ajouter"" />
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Annuler</button>
                    </div>
");
#nullable restore
#line 108 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-danger"">
                <h5 class=""modal-title text-white"" id=""exampleModalLabel"">Supprimer un etudiant</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body font-weight-bold"">
                Êtes-vous sûr ?
            </div>
            <div class=""modal-footer"">
                <a");
            BeginWriteAttribute("href", " href=\"", 6813, "\"", 6820, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""deleteHref"" class=""btn btn-danger"">Oui</a>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Non</button>
            </div>
        </div>
    </div>
</div>

<!--edit etudiant Modal and button-->
<button hidden data-toggle=""modal"" id=""lunchModal"" data-target=""#editModal"" ></button>
<div class=""modal fade"" id=""editModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalScrollableTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-scrollable"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"" style=""background-color:#44bef1;"">
                <h5 class=""modal-title"" id=""exampleModalScrollableTitle"">Éditer un etudiant</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
");
#nullable restore
#line 147 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                 using (Html.BeginForm("EditEtudiant", "Admin", FormMethod.Post, new { @class = "my_from" }))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""modal-body"" id=""modalEditBody"">
                    </div>
                    <div class=""modal-footer"">
                        <input type=""submit"" class=""btn btn-primary"" id=""submit"" value=""Éditer"" />
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Annuler</button>
                    </div>
");
#nullable restore
#line 155 "D:\mini projets\GestionDesAbsencesMigration\GestionDesAbsencesMigration\Views\Admin\AllEtudiants.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d13026ff1321f54a53c1248a3a243d7f4edb98d24372", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <script>
            $(document).ready(function () {

                $('#myTable').DataTable();



                $(""#liste_cycle"").addClass(""form-control"");

                $(""#liste_cycle"").change(function () {
                    $.get(""/Admin/GetClass"", { id: $(""#liste_cycle"").val() }, function (data) {
                        $(""#classe"").empty();
                        $.each(data, function (index, ligne) {
                            $(""#classe"").append(""<option value='"" + ligne.id + ""'>"" + ligne.nom + ""</option>"")
                        });

                    });
                });

                // edit etudiant
                $(""#myTable"").on(""click"", "".editbutton"", function () {
                    var url = ""GetEditedEtudiant/"" + $(this).attr(""value"");
                    $.get(url, function (data) {
                        $('#modalEditBody').html(data);
                        document.getElementById(""lunchModal"").click();
                    })
   ");
                WriteLiteral(@"             });

                // delte etudiant
                $(""#myTable"").on(""click"", "".deleteButton"", function () {
                    var url = ""DeleteEtudiant/"" + $(this).attr(""value"");
                    $(""#deleteHref"").attr(""href"", url);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GestionDesAbsencesMigration.Models.Etudiant>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dd842bc2bfb6f06fe852925e4c61ea15689d8ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_Details), @"mvc.1.0.view", @"/Views/Movie/Details.cshtml")]
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
#line 1 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\_ViewImports.cshtml"
using CinemaLibraryWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\_ViewImports.cshtml"
using CinemaLibraryWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dd842bc2bfb6f06fe852925e4c61ea15689d8ad", @"/Views/Movie/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd332e7d858180cb33a7ebacca06239e0e713e10", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Movie_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Movie>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
.main {
    display: flex;
    width: 90%;
}
.child{
    border:1px solid black;
    padding:2%;
    width:260px !important;
    margin-right: 2%;
    background-color:#f0f0ea;
    margin-bottom : 3%;
}
    
 img{
    width:200px;
    margin-bottom:2%;
}
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 70%;
  height: 20%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 5px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}
</style>

");
#nullable restore
#line 38 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
 if (Model != null)
{
    Movie movie = Model;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 41 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
   Write(movie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <div class=\"main\">\r\n\r\n        <div class=\"child\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 702, "\"", 721, 1);
#nullable restore
#line 45 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
WriteAttributeValue("", 708, movie.Poster, 708, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:200px\"");
            BeginWriteAttribute("alt", " alt=\"", 742, "\"", 748, 0);
            EndWriteAttribute();
            WriteLiteral(@"/>
        </div>
        <table>
            <tr style=""height: 20%"">
                <th>Genre</th>
                <th>Director</th>
                <th>Release Date</th>
                <th>IMDB</th>
                <th style=""width: 15%"">Rotten Tomatoes</th>
            </tr>
            <tr>
                <td>");
#nullable restore
#line 56 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
               Write(movie.Genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1125, "\"", 1173, 2);
            WriteAttributeValue("", 1132, "../../director/details/", 1132, 23, true);
#nullable restore
#line 57 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
WriteAttributeValue("", 1155, movie.Director.Id, 1155, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 57 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
                                                                   Write(movie.Director.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 57 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
                                                                                            Write(movie.Director.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td>");
#nullable restore
#line 58 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
               Write(movie.ReleaseDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 58 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
                                       Write(movie.ReleaseDate.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 58 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
                                                                Write(movie.ReleaseDate.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 59 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
               Write(movie.IMDB);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 60 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
               Write(movie.RottenTomatoes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </table>\r\n    \r\n    </div>\r\n    <h3>Description :</h3>\r\n    <p>\r\n        ");
#nullable restore
#line 67 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
   Write(movie.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 69 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>No movie Found</h1>\r\n");
#nullable restore
#line 73 "C:\Users\Gio\source\repos\CinemaLibrary\CinemaLibraryWebApp\Views\Movie\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Movie> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
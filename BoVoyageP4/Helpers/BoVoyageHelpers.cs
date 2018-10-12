using BoVoyageP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageP4.Helpers
{
    public static class BoVoyageHelpers
    {
        public static MvcHtmlString VoyageImage (this HtmlHelper helper, VoyageImage image, string cssClass = "")
        {
            var photo = new TagBuilder("img");

            var base64 = Convert.ToBase64String(image.Content);
            var src = $"data:{image.ContentType};base64,{base64}";

            photo.Attributes.Add("src", src);
            photo.Attributes.Add("alt", image.Name);
            if (!string.IsNullOrWhiteSpace(cssClass))
                photo.Attributes.Add("class", cssClass);

            return MvcHtmlString.Create(photo.ToString());
        }
    }
}
    

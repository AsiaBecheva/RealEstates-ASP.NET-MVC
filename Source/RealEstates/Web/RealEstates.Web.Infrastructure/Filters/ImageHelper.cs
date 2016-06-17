namespace RealEstates.Web.Infrastructure.Filters
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ImageHelper
    {
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public static ICollection<string> SanitizeImageUrls(string[] urls)
        {
            for (int i = 0; i < urls.Count(); i++)
            {
                var startPoint = urls[i].IndexOf("Content");
                urls[i] = urls[i].Substring(startPoint - 1);
            }

            return urls;
        }

        public static string SaveImage(string path)
        {
            var imageUrl = path + ".jpg";

            return imageUrl;
        }
    }
}

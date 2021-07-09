﻿namespace SimpleMvc.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        private const string ContentDirectory = "../../../Content/";

        private static readonly Dictionary<string, string> ExtensionsToMIMETypes = new Dictionary<string, string>()
        {
            ["js"] = "application/javascript",
            ["css"] = "text/css",
            ["html"] = "text/html",
            ["htm"] = "text/html",
            ["jpg"] = "image/jpeg",
            ["jpeg"] = "image/jpeg",
            ["jpe"] = "image/jpeg",
            ["bmp"] = "image/bmp",
            ["gif"] = "image/gif",
            ["svg"] = "image/svg+xml",
            ["tif"] = "image/tiff",
            ["tiff"] = "image/tiff",
            ["ico"] = "image/x-icon"
        };

        public IHttpResponse Handle(IHttpRequest request)
        {
            try
            {
                string folderPath = request.Path;
                string[] resourcePath = request.Path.Split('/', 3, StringSplitOptions.RemoveEmptyEntries);

                // The first part will always be empty, as it begins with '/'
                // The second part may be either a controller path or a direct resource
                //if (resourcePath)
                //{

                //}
                if (resourcePath.Length > 2)
                {
                    folderPath = '/' + resourcePath[1] + '/' + resourcePath[2];
                }

                string extension = folderPath.Split(".").Last();

                if (!ExtensionsToMIMETypes.ContainsKey(extension) && extension != "jpg")
                {
                    throw new InvalidOperationException("The file type is not supported.");
                }

                byte[] fileContent = this.ReadFileContent(folderPath);
                return new FileResponse(HttpStatusCode.Ok, fileContent, ExtensionsToMIMETypes[extension]);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }
        }

        private byte[] ReadFileContent(string fileFullName)
        {
            return File.ReadAllBytes(ContentDirectory + fileFullName);
        }
    }
}
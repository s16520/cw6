using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cw6.Services;

namespace cw6.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private const string FILE_NAME = "requestsLog.txt";

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IDbService service)
        {
            httpContext.Request.EnableBuffering();

            if (httpContext.Request != null)
            {
                string path = httpContext.Request.Path; 
                string querystring = httpContext.Request?.QueryString.ToString();
                string metoda = httpContext.Request.Method.ToString();
                string bodyStr = "";

                using (StreamReader reader
                 = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                }

                using (FileStream fs = new FileStream(FILE_NAME, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter w = new StreamWriter(fs))
                    {
                        string log = "\nMethode: " + metoda +
                            "\nPath: " + path +
                            "\nBody: " + bodyStr +
                            "\nQuery: " + querystring +
                            "\n-----------------------------";

                        w.Write(log);
                    }
                }
            }
            

            await _next(httpContext);
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.Test
{
    public partial class UrlPath : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Request.AppRelativeCurrentExecutionFilePath=" + Request.AppRelativeCurrentExecutionFilePath + "<br>");
            Response.Write("Request.CurrentExecutionFilePath=" + Request.CurrentExecutionFilePath + "<br>");
            Response.Write("Request.FilePath=" + Request.FilePath + "<br>");
            Response.Write("Request.Path=" + Request.Path + "<br>");
            Response.Write("Request.PathInfo=" + Request.PathInfo + "<br>");
            Response.Write("Request.PhysicalApplicationPath=" + Request.PhysicalApplicationPath + "<br>");
            Response.Write("Request.PhysicalPath=" + Request.PhysicalPath + "<br>");
            Response.Write("Request.RawUrl=" + Request.RawUrl + "<br>");
            Response.Write("Request.Url=" + Request.Url + "<br>");
            Response.Write("Request.UrlReferrer=" + Request.UrlReferrer + "<br>");
            Response.Write("Request.UserHostAddress=" + Request.UserHostAddress + "<br>");
            Response.Write("Request.UserHostName=" + Request.UserHostName + "<br>");

            Uri uri = Request.Url;
            Response.Write("uri.AbsolutePath=" + uri.AbsolutePath + "<br>");
            Response.Write("uri.AbsoluteUri=" + uri.AbsoluteUri + "<br>");
            Response.Write("uri.Authority=" + uri.Authority + "<br>");
            Response.Write("uri.Fragment=" + uri.Fragment + "<br>");
            Response.Write("uri.Host=" + uri.Host + "<br>");
            Response.Write("uri.HostNameType=" + uri.HostNameType + "<br>");
            Response.Write("uri.IsAbsoluteUri=" + uri.IsAbsoluteUri + "<br>");
            Response.Write("uri.IsDefaultPort=" + uri.IsDefaultPort + "<br>");
            Response.Write("uri.IsFile=" + uri.IsFile + "<br>");
            Response.Write("uri.IsLoopback=" + uri.IsLoopback + "<br>");
            Response.Write("uri.LocalPath=" + uri.LocalPath + "<br>");
            Response.Write("uri.OriginalString=" + uri.OriginalString + "<br>");
            Response.Write("uri.PathAndQuery=" + uri.PathAndQuery + "<br>");
            Response.Write("uri.Port=" + uri.Port + "<br>");
            Response.Write("uri.Query=" + uri.Query + "<br>");
            Response.Write("uri.Scheme=" + uri.Scheme + "<br>");
            Response.Write("uri.Segments=");
            foreach (string str in uri.Segments)
            {
                Response.Write(str + ",");
            }
        }
    }
}
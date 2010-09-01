﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Bravo.Reporting.OpenDocument;

namespace Bravo.Reporting.Test
{
    public static class OdfTemplateTestHelper
    {
        /// <summary>
        /// 一部执行模板编译、渲染并返回结果
        /// </summary>
        /// <param name="odfPath"></param>
        /// <returns></returns>
        public static OdfDocument RenderTemplate(string odfPath, IDictionary<string, object> context)
        {
            var odf = new OdfDocument(odfPath);
            var compiler = new OdfTemplateCompiler();
            var template = compiler.Compile(odf);
            var tr = new OdfTemplateRenderer(template);
            return tr.Render(context);
        }

        public static XmlDocument GetContentDocument(OdfDocument odfDoc)
        {
            var inputStream = odfDoc.GetEntryInputStream(OdfDocument.ContentEntryPath);
            var xmldoc = new XmlDocument();
            xmldoc.Load(inputStream);
            return xmldoc;
        }
    }
}

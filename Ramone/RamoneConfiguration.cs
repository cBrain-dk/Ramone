﻿using System;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;
using HtmlAgilityPack;
using Ramone.Implementation;
using Ramone.MediaTypes;
using Ramone.MediaTypes.Atom;
using Ramone.MediaTypes.Html;
using Ramone.MediaTypes.Json;
using Ramone.MediaTypes.Xml;


namespace Ramone
{
  public static class RamoneConfiguration
  {
    public static IRamoneService NewService(Uri baseUrl)
    {
      return new RamoneService(baseUrl);
    }


    public static IRamoneService WithStandardCodecs(this IRamoneService settings)
    {
      // XML
      settings.CodecManager.AddCodec<XmlDocument>("application/xml", new XmlDocumentCodec());
      settings.CodecManager.AddCodec<XmlDocument>("text/xml", new XmlDocumentCodec());

      // HTML + XHTML
      settings.CodecManager.AddCodec<HtmlDocument>("text/html", new HtmlDocumentCodec());
      settings.CodecManager.AddCodec<HtmlDocument>("text/xml", new HtmlDocumentCodec());
      settings.CodecManager.AddCodec<HtmlDocument>("application/xhtml+xml", new HtmlDocumentCodec());
      settings.CodecManager.AddCodec<HtmlDocument>("application/xml", new HtmlDocumentCodec());

      // Atom
      settings.CodecManager.AddCodec<SyndicationFeed>("application/atom+xml", new AtomFeedCodec());
      settings.CodecManager.AddCodec<SyndicationItem>("application/atom+xml", new AtomItemCodec());

      // JSON
      settings.CodecManager.AddCodec("application/json", new JsonDynamicCodec());

      // Streams
      settings.CodecManager.AddCodec<Stream>(new StreamCodec());

      return settings;
    }
  }
}

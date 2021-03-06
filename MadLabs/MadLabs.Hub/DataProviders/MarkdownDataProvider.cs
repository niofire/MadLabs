﻿using MadLabs.Hub.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace MadLabs.Hub.DataProviders
{
    public class MarkdownDataProvider
    {
        public string GetMarkdown(string filepath)
        {
            using (StreamReader reader = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read)))
            using (StringWriter writer = new StringWriter())
            {
                CommonMark.CommonMarkConverter.Convert(reader, writer);
                return writer.ToString();
            }
        }

        public Dictionary<string, string> GetMetadata(string filepath)
        {

            Dictionary<string, string> metadataStore = new Dictionary<string, string>();

            metadataStore.Add("filename", Path.GetFileName(filepath));

            //Parse through the metadata node.
            using (XmlReader reader = XmlReader.Create(filepath))
            {
                //reader.ReadToFollowing("metadata");
                try
                {
                    reader.Read();

                    if (reader.NodeType != XmlNodeType.Comment)
                        return metadataStore;
                    XmlReader metadataReader = XmlReader.Create(new StringReader(reader.Value));

                    //Read the metadata
                    while (metadataReader.Read())
                    {
                        string key = metadataReader.Name.ToLower();
                        string value = metadataReader.GetAttribute("value");

                        if (metadataReader.NodeType == XmlNodeType.Element
                        && !metadataStore.ContainsKey(key)
                        && !string.IsNullOrEmpty(value))
                        {
                            metadataStore.Add(key, value);
                        }
                    }
                }
                catch (XmlException e)
                {
                    //TODO log xml error
                    return metadataStore;
                }
                return metadataStore;
            }
        }

        public MarkdownViewModel GetMarkdownViewModel(string filepath)
        {
            return new MarkdownViewModel()
            {
                Content = GetMarkdown(filepath),
                Metadata = GetMetadata(filepath)
            };
        }
    }
}

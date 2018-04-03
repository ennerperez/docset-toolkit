using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZDocs.Core.Models
{
    [XmlRoot(ElementName = "TokenIdentifier")]
    public class TokenIdentifier
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "APILanguage")]
        public string APILanguage { get; set; }
    }

    [XmlRoot(ElementName = "Token")]
    public class Token
    {
        [XmlElement(ElementName = "TokenIdentifier")]
        public TokenIdentifier TokenIdentifier { get; set; }

        [XmlElement(ElementName = "Path")]
        public string Path { get; set; }
    }

    [XmlRoot(ElementName = "Tokens")]
    public class Tokens
    {
        [XmlElement(ElementName = "Token")]
        public List<Token> Token { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
}
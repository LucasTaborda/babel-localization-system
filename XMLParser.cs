using System.Xml;
using UnityEngine;

namespace Localization
{
    public class XMLParser
    {
        XmlDocument xmlHandler = new XmlDocument();


        public XMLParser(TextAsset file)
        {
            xmlHandler.LoadXml(file.text);
        }


        public void LoadXML(TextAsset file)
        {
            xmlHandler.LoadXml(file.text);
        }


        public string ObtainNode(string tag)
        {
            XmlNodeList nodeList = xmlHandler.GetElementsByTagName(tag);
            if (nodeList.Count > 0)
            {
                return nodeList[0].InnerText;
            }

            Debug.LogWarning("Tag not found: " + tag);
            return tag;
        }


        public string ObtainNode(string parentNode, string tag)
        {
            XmlNodeList parentNodes = xmlHandler.GetElementsByTagName(parentNode);
            if (parentNodes.Count > 0)
            {
                XmlNode firstParentNode = parentNodes[0];
                XmlNodeList childrenNodes = firstParentNode.SelectNodes(tag);
                if (childrenNodes.Count > 0)
                {
                    return childrenNodes[0].InnerText;
                }
            }

            Debug.LogWarning($"Tag not found:<{parentNode}> <{tag}></{tag}> </{parentNode}>");
            return tag;
        }


    }
}


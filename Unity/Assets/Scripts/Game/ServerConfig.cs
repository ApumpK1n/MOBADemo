using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConfig
{
    public struct Server
    {
        public string strIP;
        public string strName;
        public int nPort;
    }

    private XmlDocument xmldoc = null;
    private XmlNode root = null;

    private List<Server> m_ServerList = null;

    public void Load()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("ServerConfig");

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);

        root = xmldoc.SelectSingleNode("XML");
    }

    public List<Server> GetServerList()
    {
        if (null == m_ServerList)
        {
            m_ServerList = new List<Server>();

            XmlNode node = root.SelectSingleNode("Servers");

            XmlNodeList nodeList = node.SelectNodes("Server");
            for (int i = 0; i < nodeList.Count; ++i)
            {
                XmlNode nodeServer = nodeList.Item(i);
                XmlAttribute strIP = nodeServer.Attributes["IP"];
                XmlAttribute strName = nodeServer.Attributes["Name"];
                XmlAttribute strPort = nodeServer.Attributes["Port"];

                Server server = new Server();
                server.strIP = strIP.Value;
                server.nPort = int.Parse(strPort.Value);
                server.strName = strName.Value;

                m_ServerList.Add(server);
            }
        }

        return m_ServerList;
    }

    public bool GetSelectServer(int n, ref Server server)
    {
        List<Server> serverList = GetServerList();
        if (n >= 0 && n < serverList.Count)
        {
            Server strData = (Server)serverList[n];
            server = strData;

            return true;
        }

        return false;
    }

    public bool GetSelectServer(ref string strIP)
    {
        //if (Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        //    strIP = "192.168.1.41";
        //    return true;
        //}

        List<Server> serverList = GetServerList();
        if (null != serverList && serverList.Count > 0)
        {
            Server strData = serverList[0];
            strIP = strData.strIP;

            return true;
        }

        return false;
    }

    public string GetDataPath()
    {
        XmlNode node = root.SelectSingleNode("Evironment");

        XmlNode nodeDataPath = node.SelectSingleNode("DataPath");
        return nodeDataPath.Attributes["ID"].Value;
    }
}
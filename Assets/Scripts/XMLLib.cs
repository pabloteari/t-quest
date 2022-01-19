using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System.IO;

public class XMLLib {

    public void CriarXML(int bloqueio, int tarefaAtual, int maquinaBloqueada)
    {
        XmlTextWriter writer = new XmlTextWriter("123ada7123.xml", System.Text.Encoding.UTF8);
        writer.WriteStartDocument(true);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;
        writer.WriteStartElement("Table");
        createNode(bloqueio, tarefaAtual, maquinaBloqueada, writer);
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
    }

    public void createNode(int bloqueio, int tarefaAtual, int maquinaBloqueada, XmlTextWriter writer)
    {
        writer.WriteStartElement("GamaSave");
        writer.WriteStartElement("Bloqueios");
        writer.WriteString(bloqueio.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("TarefaAtual");
        writer.WriteString(tarefaAtual.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("MaquinaBloqueada");
        writer.WriteString(maquinaBloqueada.ToString());
        writer.WriteEndElement();
    }

    public Processo isXmlExist()
    {     
        Processo processo = new Processo();

        if (!File.Exists("123ada7123.xml")) 
        {                
            CriarXML(0,0,0);
        }      

        XmlTextReader reader = new XmlTextReader("123ada7123.xml");

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Bloqueios")
            {
                processo.bloqueios = int.Parse(reader.ReadString());
            }
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "TarefaAtual")
            {
                processo.tarefaAtual = int.Parse(reader.ReadString());
            }
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "MaquinaBloqueada")
            {
                processo.maquinaBloqueada = int.Parse(reader.ReadString());
            }
        }
        reader.Close();
        return processo;
    }       
}

public class Processo {
    public int bloqueios;
    public int tarefaAtual;
    public int maquinaBloqueada;
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

class Program
{
	static void Main(string[] args)
	{
		// Archivo XML, si no existe lo creamos y salimos.
		if (!File.Exists("config.xml"))
		{
			XDocument archivo = new XDocument(
				new XElement("CONFIGURACION",
					new XElement("HABILITAR", "True"),
					new XElement("EXTENSION_ARCHIVO", ".xlsx")
				)
			);

			archivo.Save("config.xml");
		}
		else
		{
			// Existe el archivo XML, lo leemos.
			XmlDocument archivo = new XmlDocument();
			archivo.Load("config.xml");

            //XmlNode root = archivo.DocumentElement;
            //XmlNode myNode = root.SelectSingleNode("/CONFIGURACION/EXTENSION_ARCHIVO");
            //myNode.InnerText = "test";
            // Esto es equivalente...
            archivo.DocumentElement.SelectSingleNode("/CONFIGURACION/EXTENSION_ARCHIVO").InnerText = ".jpg";
            archivo.DocumentElement.SelectSingleNode("/CONFIGURACION/HABILITAR").InnerText = false.ToString();

            archivo.Save("config.xml");
	   }
	}
}
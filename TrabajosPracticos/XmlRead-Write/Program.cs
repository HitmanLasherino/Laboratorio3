using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        EscribirXML();
        string path = Directory.GetCurrentDirectory();
        path = path.Replace("bin\\Debug", "");
        EscribirXMLtxtWriter(path);
        Console.Write("Archivos Escritos");

        Console.Write("\n-------------\n");
        string xml = LeerXML();
        Console.Write(xml);
        Console.Write("\n-------------\n");
        Console.Write("Primera Lectura realizada");

        Console.Write("\n-------------\n");
        string xml1 = LeerXMLtxtReader();
        Console.Write(xml1);
        Console.ReadLine();
        Console.Write("\n-------------\n");
        Console.Write("Segunda Lectura Realizada");

    }

    protected static void EscribirXML()
    {
        try
        {
            XElement empleados = new XElement("empleados");

            XElement listado = new XElement("listado");

            XElement empleado = new XElement("empleado");
            XElement id = new XElement("id", "4884");
            empleado.Add(id);
            XElement nombreCompleto = new XElement("nombreCompleto", "Rodriguez, Victor");
            empleado.Add(nombreCompleto);
            XElement cuil = new XElement("cuil", "20103180326");
            empleado.Add(cuil);
            XElement sector = new XElement("sector");
            XAttribute denominacion = new XAttribute("denominacion", "Gerencia Recursos Humanos");
            XAttribute Id = new XAttribute("id", "137");
            XAttribute valorSemaforo = new XAttribute("valorSemaforo", "130.13");
            XAttribute colorSemaforo = new XAttribute("colorSemaforo", "VERDE");
            sector.Add(denominacion, Id, valorSemaforo, colorSemaforo);
            empleado.Add(sector);
            XElement cupoAsignado = new XElement("cupoAsignado", "1837.15");
            empleado.Add(cupoAsignado);
            XElement cupoConsumido = new XElement("cupoConsumido", "685.02");
            empleado.Add(cupoConsumido);
            listado.Add(empleado);

            empleado = new XElement("empleado");
            id = new XElement("id", "1225");
            empleado.Add(id);
            nombreCompleto = new XElement("nombreCompleto", "Sanchez, Juan");
            empleado.Add(nombreCompleto);
             cuil = new XElement("cuil", "20271265817");
            empleado.Add(cuil);
             sector = new XElement("sector");
             denominacion = new XAttribute("denominacion", "Gerencia Operativa");
             Id = new XAttribute("id", "44");
             valorSemaforo = new XAttribute("valorSemaforo", "130.13");
             colorSemaforo = new XAttribute("colorSemaforo", "ROJO");
            sector.Add(denominacion, Id, valorSemaforo, colorSemaforo);
            empleado.Add(sector);
             cupoAsignado = new XElement("cupoAsignado", "750.87");
            empleado.Add(cupoAsignado);
             cupoConsumido = new XElement("cupoConsumido", "625.46");
            empleado.Add(cupoConsumido);
            listado.Add(empleado);

            empleados.Add(listado);

            XElement subsectores = new XElement("subsectores", "5");
            empleados.Add(subsectores);
            XElement totalCupoAsignadoSector = new XElement("totalCupoAsignadoSector", "4217.21");
            empleados.Add(totalCupoAsignadoSector);
            XElement totalCupoConsumidoSector = new XElement("totalCupoConsumidoSector", "1405.88");
            empleados.Add(totalCupoConsumidoSector);
            XElement valorDial = new XElement("valorDial", "33.34");
            empleados.Add(valorDial);

            XDeclaration declaration = new XDeclaration("1.0", "utf-8", "yes");
            XComment comentario = new XComment("Lista de Empleados");
            XDocument miXML = new XDocument(declaration, comentario, empleados);

            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug", "");
            string archivoXML = path + "empleados.xml";
            miXML.Save(@archivoXML);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    static void EscribirXMLtxtWriter(string ruta)
    {
        XmlTextWriter myxmlTextWriter = new XmlTextWriter(ruta + "empleadostxtWriter.xml", null);
        myxmlTextWriter.Formatting = Formatting.Indented;
        myxmlTextWriter.WriteStartDocument(false);
        myxmlTextWriter.WriteComment("Lista de Empleados");

        myxmlTextWriter.WriteStartElement("empleados");
        myxmlTextWriter.WriteStartElement("listado");
        //Empleado1
        myxmlTextWriter.WriteStartElement("empleado");

        myxmlTextWriter.WriteElementString("id", null, "4884");
        myxmlTextWriter.WriteElementString("nombreCompleto", null, "Rodriguez, Victor");
        myxmlTextWriter.WriteElementString("cuil", null, "20103180326");
        //Sector1
        myxmlTextWriter.WriteStartElement("sector", null);
        myxmlTextWriter.WriteAttributeString("denominacion", "Gerencia Recursos Humanos");
        myxmlTextWriter.WriteAttributeString("id", "137");
        myxmlTextWriter.WriteAttributeString("valorSemaforo", "130.13");
        myxmlTextWriter.WriteAttributeString("colorSemaforo", "VERDE");
        myxmlTextWriter.WriteEndElement();
        myxmlTextWriter.WriteElementString("cupoAsignado",null,"1837.15");
        myxmlTextWriter.WriteElementString("cupoConsumido", null, "685.02");
        myxmlTextWriter.WriteEndElement();

        //Empleado2
        myxmlTextWriter.WriteStartElement("empleado");

        myxmlTextWriter.WriteElementString("id", null, "1225");
        myxmlTextWriter.WriteElementString("nombreCompleto", null, "Sanchez, Juan Ignacio");
        myxmlTextWriter.WriteElementString("cuil", null, "20271265817");
        myxmlTextWriter.WriteStartElement("sector", null);
        //Sector2
        myxmlTextWriter.WriteAttributeString("denominacion", "Gerencia Operativa");
        myxmlTextWriter.WriteAttributeString("id", "44");
        myxmlTextWriter.WriteAttributeString("valorSemaforo", "130.13");
        myxmlTextWriter.WriteAttributeString("colorSemaforo", "ROJO");
        myxmlTextWriter.WriteEndElement();
        myxmlTextWriter.WriteElementString("cupoAsignado", null, "750.87");
        myxmlTextWriter.WriteElementString("cupoConsumido", null, "625.46");
        myxmlTextWriter.WriteEndElement();//Cierra Segundo Empleado
        myxmlTextWriter.WriteEndElement();//Cierra listado

        //Otros datos de empleados
        myxmlTextWriter.WriteElementString("subsectores", null, "5");
        myxmlTextWriter.WriteElementString("totalCupoAsignadoSector", null, "4217.21");
        myxmlTextWriter.WriteElementString("totalCupoConsumidoSector", null, "1405.88");
        myxmlTextWriter.WriteElementString("valorDial", "33.34");

        myxmlTextWriter.WriteEndElement();
        myxmlTextWriter.Flush();
        myxmlTextWriter.Close();
    }

    static string LeerXML()
    {
        string resultado = "";
        string path = Directory.GetCurrentDirectory();
        path = path.Replace("bin\\Debug", "");

        try
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path + "empleados.xml");

            XmlNodeList empleados = xDoc.GetElementsByTagName("empleados");
            XmlNodeList listado = ((XmlElement)empleados[0]).GetElementsByTagName("listado");
            XmlNodeList lista = ((XmlElement)listado[0]).GetElementsByTagName("empleado");


            foreach (XmlElement node in lista)
            {

                XmlNodeList gId = node.GetElementsByTagName("id");
                XmlNodeList gNombreCompleto = node.GetElementsByTagName("nombreCompleto");
                XmlNodeList gCuil = node.GetElementsByTagName("cuil");
                XmlNodeList gSector = node.GetElementsByTagName("sector");


                resultado += "ID: " + gId[0].InnerText + "\n";
                resultado += "Nombre Completo: " + gNombreCompleto[0].InnerText + "\n";

                if (gSector.Count > 0)
                {
                    XmlElement sectorElement = (XmlElement)gSector[0];

                    string denominacion = sectorElement.GetAttribute("denominacion");
                    string idSector = sectorElement.GetAttribute("id");
                    string valorSemaforo = sectorElement.GetAttribute("valorSemaforo");
                    string colorSemaforo = sectorElement.GetAttribute("colorSemaforo");

                    resultado += "Sector: " + denominacion + "\tID Sector: " + idSector + "\n";
                    resultado += "Valor Semáforo: " + valorSemaforo + "\tColor Semáforo: " + 
                    colorSemaforo + "\n";
                }

                XmlNodeList gCupoAsignado = node.GetElementsByTagName("cupoAsignado");
                if (gCupoAsignado.Count > 0)
                {
                    resultado += "Cupo Asignado: " + gCupoAsignado[0].InnerText + "\n";
                }

                XmlNodeList gCupoConsumido = node.GetElementsByTagName("cupoConsumido");
                if (gCupoConsumido.Count > 0)
                {
                    resultado += "cupo Consumido: " + gCupoConsumido[0].InnerText + "\n";
                }
                resultado += "\n---\n";

            }

            //Lectura de datos por fuera de listado
            XmlNodeList subsectores = ((XmlElement)empleados[0]).GetElementsByTagName("subsectores");
            if (subsectores.Count > 0)
            {
                resultado += "Subsectores: " + subsectores[0].InnerText + "\n";
            }

            XmlNodeList totalCupoAsignadoSector = ((XmlElement)empleados[0]).GetElementsByTagName("totalCupoAsignadoSector");
            if (totalCupoAsignadoSector.Count > 0)
            {
                resultado += "Total Cupo Asignado Sector: " + totalCupoAsignadoSector[0].InnerText + "\n";
            }

            XmlNodeList totalCupoConsumidoSector = ((XmlElement)empleados[0]).GetElementsByTagName("totalCupoConsumidoSector");
            if (totalCupoConsumidoSector.Count > 0)
            {
                resultado += "Total Cupo Consumido Sector: " + totalCupoConsumidoSector[0].InnerText + "\n";
            }

            XmlNodeList valorDial = ((XmlElement)empleados[0]).GetElementsByTagName("valorDial");
            if (valorDial.Count > 0)
            {
                resultado += "Valor Dial: " + valorDial[0].InnerText + "\n";
            }
        }
        catch (Exception ex)
        {

            return ex.Message;
        }
        return resultado;

    }
    
    static string LeerXMLtxtReader()
    {
        string resultado = "";
        string path = Directory.GetCurrentDirectory();
        path = path.Replace("bin\\Debug", "");

        using (XmlReader reader = XmlReader.Create(path + "empleados.xml"))
        {
            string id = "", nombreCompleto = "", cuil = "", denominacion = "", idSector = "", valorSemaforo = "", colorSemaforo = "", cupoAsignado = "", cupoConsumido = "";

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        // Capturamos los elementos dentro de listado
                        case "empleado":
                            id = nombreCompleto = cuil = denominacion = idSector = valorSemaforo = colorSemaforo = cupoAsignado = cupoConsumido = "";
                            break;
                        case "id":
                            if (reader.Read())
                            {
                                id = reader.Value.Trim();
                            }
                            break;
                        case "nombreCompleto":
                            if (reader.Read())
                            {
                                nombreCompleto = reader.Value.Trim();
                            }
                            break;
                        case "cuil":
                            if (reader.Read())
                            {
                                cuil = reader.Value.Trim();
                            }
                            break;
                        case "sector":
                            denominacion = reader["denominacion"];
                            idSector = reader["id"];
                            valorSemaforo = reader["valorSemaforo"];
                            colorSemaforo = reader["colorSemaforo"];
                            break;
                        case "cupoAsignado":
                            if (reader.Read())
                            {
                                cupoAsignado = reader.Value.Trim();
                            }
                            break;
                        case "cupoConsumido":
                            if (reader.Read())
                            {
                                cupoConsumido = reader.Value.Trim();
                            }
                            break;

                        // Mostramos los datos capturados de cada empleado
                        case "listado":
                            if (!string.IsNullOrEmpty(id))
                            {
                                resultado += "ID: " + id + "\n";
                                resultado += "Nombre Completo: " + nombreCompleto + "\n";
                                resultado += "CUIL: " + cuil + "\n";
                                resultado += "Sector: " + denominacion + "\tID Sector: " + idSector + "\n";
                                resultado += "Valor Semáforo: " + valorSemaforo + "\tColor Semáforo: " + colorSemaforo + "\n";
                                resultado += "Cupo Asignado: " + cupoAsignado + "\n";
                                resultado += "Cupo Consumido: " + cupoConsumido + "\n";
                                resultado += "\n---\n";
                            }
                            break;

                        // Capturamos y mostramos los elementos fuera del listado
                        case "subsectores":
                            if (reader.Read())
                            {
                                resultado += "Subsectores: " + reader.Value.Trim() + "\n";
                            }
                            break;
                        case "totalCupoAsignadoSector":
                            if (reader.Read())
                            {
                                resultado += "Total Cupo Asignado Sector: " + reader.Value.Trim() + "\n";
                            }
                            break;
                        case "totalCupoConsumidoSector":
                            if (reader.Read())
                            {
                                resultado += "Total Cupo Consumido Sector: " + reader.Value.Trim() + "\n";
                            }
                            break;
                        case "valorDial":
                            if (reader.Read())
                            {
                                resultado += "Valor Dial: " + reader.Value.Trim() + "\n";
                            }
                            break;
                    }
                }

                // Cuando terminamos de leer un empleado
                if (reader.Name == "empleado" && reader.NodeType == XmlNodeType.EndElement)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        resultado += "ID: " + id + "\n";
                        resultado += "Nombre Completo: " + nombreCompleto + "\n";
                        resultado += "CUIL: " + cuil + "\n";
                        resultado += "Sector: " + denominacion + "\tID Sector: " + idSector + "\n";
                        resultado += "Valor Semáforo: " + valorSemaforo + "\tColor Semáforo: " + colorSemaforo + "\n";
                        resultado += "Cupo Asignado: " + cupoAsignado + "\n";
                        resultado += "Cupo Consumido: " + cupoConsumido + "\n";
                        resultado += "\n---\n";
                    }
                }
            }
        }
        return resultado;
    }
}

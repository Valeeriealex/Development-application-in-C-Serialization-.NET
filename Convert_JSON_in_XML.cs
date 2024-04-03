using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;

namespace Convert_JSON_in_XML
{
    internal class Convert_JSON_in_XML
    {
        static void Main(string[] args)
        {
            //Данные в формате JSON
            string jsonData = "{ \"name\": \"John\", \"age\": 30, \"city\": \"New York\" }";

            //Использование Text.Json
            JsonDocument jsonDocument = JsonDocument.Parse(jsonData);

            //Создание документа и добавление элементов
            XDocument xDocument = new XDocument(
            new XElement("Root",
                jsonDocument.RootElement.EnumerateObject()
                    .Select(prop => new XElement(prop.Name, prop.Value.ToString()))
            )
        );
            //Конвертация в XML
            string xmlOutput = xDocument.ToString();
            Console.WriteLine(xmlOutput);
        }
    }
}

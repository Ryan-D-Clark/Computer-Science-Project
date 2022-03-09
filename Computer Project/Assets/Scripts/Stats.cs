using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class Stats
{
    public int PlayerLevel { get; set; }
    public int CurrentExp { get; set; }

    public void Save(string fileName)
    {
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            var XML = new XmlSerializer(typeof(Stats));
            XML.Serialize(stream, this);
        }
    }

    public static Stats LoadFile(string fileName)
    {
        using (var stream = new FileStream(fileName, FileMode.Open))
        {
            var XML = new XmlSerializer(typeof(Stats));
            return (Stats)XML.Deserialize(stream);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.IO;
using System.Xml.Linq;

using System.Xml.Serialization;
using System;


public class DataManager : MonoBehaviour
{
    // XML stuff
    private string _xmlData;    // Used for creating file
    private string _xmlDataPath;    // Used for creating directory

    // Json stuff
    private string _jsonDataPath; // Used for creating directory
    private string _jsonData;   // Used for creating file

    // Person stuff
    [Serializable]
    public struct PersonData //Creating a struct to store the data
    {
        public string Name;
        public string DateOfBirth;
        public string FavouriteColor;
    }

    [Serializable]
    public class People
    {
        public List<PersonData> PersonList { get; set; }
    }

    void Awake()
    {
        _xmlDataPath = Application.persistentDataPath + "/XMLDataToSave/";  // Path to save XML data folder
        _jsonDataPath = Application.persistentDataPath + "/JSONDataToSave/";// Path to save JSON data folder

        _jsonData = _jsonDataPath + "Person_Data.json"; //Path to save JSON file
        _xmlData = _xmlDataPath + "Person_Data.xml";    //Path to save XML file

        Debug.Log("XML Path: " + _xmlDataPath);
    }

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        NewDirectory(_xmlDataPath);
        NewDirectory(_jsonDataPath);

        InitData();

        //WriteToXML(_xmlData, InitData());

        People peopleFromXML = ReadXML(_xmlData);

        //WriteToJSON(_jsonData, peopleFromXML.PersonList);
    }

    public People InitData()
    {
        People people = new People
        {
            PersonList = new List<PersonData>
            {
                new PersonData
                {
                    Name = "Jeff",
                    DateOfBirth = "1995-01-01",
                    FavouriteColor = "Blue"
                },
                new PersonData
                {
                    Name = "Alice",
                    DateOfBirth = "1996-02-02",
                    FavouriteColor = "Red"
                }
            }
        };
        return people;
    }

    /// <summary>
    /// Creates a new directory if it does not exist
    /// </summary>
    /// <param name="dataPath"></param>
    public void NewDirectory(string dataPath)
    {
        if(Directory.Exists(dataPath))
        {
            Debug.Log("Directory already exists");
            return;
        }

        Directory.CreateDirectory(dataPath);
        Debug.Log("Directory created");
    }

    /// <summary>
    /// Writes to XML file
    /// </summary>
    /// <param name="filename"></param>
    public void WriteToXML(string filename, People people)
    {
        // Check if file already exists
        if(File.Exists(filename))
        {
            Debug.Log("File already exists");
            return;
        }

        var xmlSerializer = new XmlSerializer(typeof(People));

        using (FileStream stream = File.Create(filename))
        {
            xmlSerializer.Serialize(stream, people);
        }
    
        Debug.Log("XML File created");
    }

    public People ReadXML(string filename)
    {
        // Check if file exists
        if(!File.Exists(filename))
        {
            Debug.Log("File does not exist");
            return null;
        }

        var xmlSerializer = new XmlSerializer(typeof(People));

        using (FileStream stream = File.OpenRead(filename))
        {       
            return (People)xmlSerializer.Deserialize(stream); 
        }

    }
    
    public void WriteToJSON(string filename, List<PersonData> people)
    {
         if(people == null)
        {
            Debug.Log("No data to convert");
            return;
        }

        var xmlSerializer = new XmlSerializer(typeof(List<PersonData>));

        using (FileStream stream = File.OpenRead(filename))
        {
            var personDatas = (List<PersonData>)xmlSerializer.

            Deserialize(stream);
 
           foreach (var peoples in personDatas)
            {
               Debug.LogFormat("Name: {0}, Age: {1}, Color: {3}", peoples.Name, peoples.Name, peoples.FavouriteColor);
            }
        }
    }
    /*
    public void DeserializeXML()
    {
    if (File.Exists(_xmlData))
        {
            var xmlSerializer = new XmlSerializer(typeof(List<People>));

            using (FileStream stream = File.OpenRead(_xmlData))
            {
                var persons = (List<People>)xmlSerializer.
                Deserialize(stream);

                foreach (var person in persons)
                {
                    //Debug.LogFormat("Name: {0}, Age: {1}, Color: {3}", weapon.Name, weapon.DateOfBirth, weapon.FavouriteColor);
                }
            }

        }
    } 
    */
}




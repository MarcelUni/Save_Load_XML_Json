using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;


[Serializable]
public struct Person //Creating a struct to store the data
{
    public string Name;
    public int DateOfBirth;
    public string FavouriteColor;
    public Person(string name, int dateOfBirth, string favouriteColor)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        FavouriteColor = favouriteColor;
    }
}

[Serializable]
public class ListOfPeople   //Creating a class to store the list of people for json serialization, as jsonutility does not support list serialization
{
    public List<Person> GroupOfPeople; 
}

public class DataManager : MonoBehaviour
{
    // List of people
    public List<Person> PersonList = new List<Person>
    {
        new Person ("Greg", 100, "Blue"),
        new Person ("John", 153, "Green"),
        new Person ("Alice", 200, "Red")
    };

    // XML stuff
    private string _xmlData;    // Used for creating file, this will be the file name and path
    private string _xmlDataPath;    // Used for creating directory

    // Json stuff
    private string _jsonDataPath; // Used for creating directory
    private string _jsonData;   // Used for creating file, this will be the file name and path

    // Person stuff

    void Awake()
    {
        _xmlDataPath = Application.persistentDataPath + "/XMLDataToSave/";  // Path to save XML data folder
        _jsonDataPath = Application.persistentDataPath + "/JSONDataToSave/";// Path to save JSON data folder

        _jsonData = _jsonDataPath + "Person_Data.json"; //Path to save JSON file, and the file name
        _xmlData = _xmlDataPath + "Person_Data.xml";    //Path to save XML file, and the file name

        Debug.Log(Application.persistentDataPath);      // Path to the data path unity uses to save data
    }

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        NewDirectory(_xmlDataPath); //Create a new directory(folder) for XML data
        NewDirectory(_jsonDataPath);//Create a new directory(folder) for JSON data

        //SerializeXML();
        //DeserializeXML();

        SerializeJSON();
    }



    // Creates a new directory if it does not exist
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

    public void SerializeXML()
    {
        if(File.Exists(_xmlData))   //Check if file already exists, if it does, do not create a new file - we can remove this to overwrite the file
        {
            Debug.Log("File already exists");
            return;
        }

        var xmlSerializer = new XmlSerializer(typeof(List<Person>));

        using(FileStream stream = File.Create(_xmlData))
        {
            xmlSerializer.Serialize(stream, PersonList);
        }

        Debug.Log("XML file created");
    }

    public List<Person> DeserializeXML()
    {
        if(File.Exists(_xmlData))
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Person>));

            using (FileStream stream = File.OpenRead(_xmlData))
            {
                var people = (List<Person>)xmlSerializer.Deserialize(stream);

                foreach (var person in people)
                {
                    Debug.LogFormat("Name: {0}, Date of Birth: {1}, Favourite Color: {2}", person.Name, person.DateOfBirth, person.FavouriteColor);
                }                   
                return people;
            }
        }    
        else
            Debug.Log("File does not exist");
            return null;
        
    }

    public void SerializeJSON()
    {
        ListOfPeople listOfPeople = new ListOfPeople();

        listOfPeople.GroupOfPeople = DeserializeXML();

        string jsonString = JsonUtility.ToJson(listOfPeople, true);

        using(StreamWriter stream = File.CreateText(_jsonData))
        {
            stream.WriteLine(jsonString);
        }

        Debug.Log("JSON file created");
    }

}




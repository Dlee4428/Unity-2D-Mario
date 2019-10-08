using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

public class SaveDataManager : MonoBehaviour {

    private void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            Save();
            GameState.Enemies.Clear();
            Debug.Log("Saved");
        }
    }

    // Save game data 
    [XmlRoot("PlatformerSaveData")]
    public class GameStateData {

        // Serializable Data 

        public struct DataTransform {
            public float X;
            public float Y;
            public float Z;
            public float RotX;
            public float RotY;
            public float RotZ;
            public float ScaleX;
            public float ScaleY;
            public float ScaleZ;
        }

        // Data for player 
        public class DataPlayer {
            public DataTransform PosRotScale;
            public string Name;
            public float CollectedCash;
            public bool CollectedGun;
            public int Health;
        }

        // Data for Enemy
        public class DataEnemy
        {
            public DataTransform PosRotScale;
            public int EnemyID;
            public int Health;
        }

        // Instance variables 
        public DataPlayer Player = new DataPlayer();
        public List<DataEnemy> Enemies = new List<DataEnemy>();
    }

    // Game data to save/load 
    public GameStateData GameState = new GameStateData();    

    // Saves game data to XML file 
    public void Save(string FileName = "SaveData.xml") {
        //Now save game data 
        // XMLSerializer is instantiated, passing a valid instance to GameStateData in the constructor, indicating the class to serialize
        XmlSerializer Serializer = new XmlSerializer(typeof(GameStateData));
        // Creates file to write the XML into
        StreamWriter Stream = new StreamWriter(new FileStream(FileName, FileMode.Create), System.Text.Encoding.UTF8);
        // Serializes data in the class to a file stream
        Serializer.Serialize(Stream, GameState);
        // Data is committed to the file and the file is closed using a Stream.Close
        Stream.Close();
    }

    // Load game data from XML file 
    // Load is the inverse of the Save function 
    public void Load(string FileName = "SaveData.xml") {
        // XMLSerializer is instantiated to Deserialize an XML file stream 
        // back to GameStateData class, allowing game state data to be reconstructed
        XmlSerializer Serializer = new XmlSerializer(typeof(GameStateData));
        FileStream Stream = new FileStream(FileName, FileMode.Open);
        GameState = Serializer.Deserialize(Stream) as GameStateData;
        // File is closed after the read using a Stream.Close
        Stream.Close();
    }
}

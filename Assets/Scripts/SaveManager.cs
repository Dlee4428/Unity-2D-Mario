using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    /*public Transform Player;
    public string Name = "";

    public int score = 0;

    void OnGUI()
    {
       if(GUI.Button(new Rect(100, 100, 125, 25), "Save")){
            SaveStuff();
        } 
       if(GUI.Button(new Rect(100, 140, 125, 25), "Load")){
            LoadStuff();
        } 
       if(GUI.Button(new Rect(100, 180, 125, 25), "Increase Score")){
            score++;
            Debug.Log("Score +1");
        } 
       if(GUI.Button(new Rect(100, 220, 125, 25), "Decrease Score")){
            score--;
            Debug.Log("Score -1");
        } 
       if(GUI.Button(new Rect(100, 260, 125, 25), "Wipe Save")){
            DeleteSavedData();
        }

        GUI.color = Color.black;
        Name = GUI.TextField(new Rect(300, 200, 125, 25), Name, 25);
        GUI.Label(new Rect(300, 100, 125, 25), "Score: " + score);
    }

    void SaveStuff()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("Name", Name);
        Debug.Log("Saved Data");
    }

    void LoadStuff()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        Name = PlayerPrefs.GetString("Name", "");
        Debug.Log("Loaded Previous Save Data");
    }

    void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Wiped Save Data/Try Load Function!");
    }*/
}

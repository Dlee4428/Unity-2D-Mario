using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public string Name;
    public int Health;
    public float Cash;
    public bool CollectWeapon;

    private void Start() {
       SavePlayer();
       //LoadPlayer();
    }

    public void SavePlayer() {

       // Get Player Data Object 
        SaveDataManager.GameStateData.DataPlayer temp = GameManager.Singleton._saveDataManager.GameState.Player;

       //Fill in player data for save game 
        temp.Name = Name;
        temp.CollectedCash = Cash;
        temp.CollectedGun = CollectWeapon;
        temp.Health = Health;
        temp.PosRotScale.X = transform.position.x;
        temp.PosRotScale.Y = transform.position.y;
        temp.PosRotScale.Z = transform.position.z;
        temp.PosRotScale.RotX = transform.localEulerAngles.x;
        temp.PosRotScale.RotY = transform.localEulerAngles.y;
        temp.PosRotScale.RotZ = transform.localEulerAngles.z;
        temp.PosRotScale.ScaleX = transform.localScale.x;
        temp.PosRotScale.ScaleY = transform.localScale.y;
        temp.PosRotScale.ScaleZ = transform.localScale.z;
    }

    public void LoadPlayer() {

        // Get Player Data Object 
        SaveDataManager.GameStateData.DataPlayer temp = GameManager.Singleton._saveDataManager.GameState.Player;

        // Load data back to Player 
        Name = temp.Name;
        Cash = temp.CollectedCash;

       // check if weapon was collected
        if (temp.CollectedGun) {
            // Do something
            CollectWeapon = temp.CollectedGun;
       }

       Health = temp.Health;
       transform.position = new Vector3(temp.PosRotScale.X, temp.PosRotScale.Y, temp.PosRotScale.Z);
       transform.localRotation = Quaternion.Euler(temp.PosRotScale.RotX, temp.PosRotScale.RotY, temp.PosRotScale.RotZ);
       transform.localScale = new Vector3(temp.PosRotScale.ScaleX, temp.PosRotScale.ScaleY, temp.PosRotScale.ScaleZ);
   }
}

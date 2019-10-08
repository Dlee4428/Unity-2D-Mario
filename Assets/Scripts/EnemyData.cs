using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour {


    public int EnemyID;
    public int Health;

    private void Start()
    {
       SaveEnemy();
       //LoadEnemy();
    }

    public void SaveEnemy()
    {

        // Get Player Data Object 
        SaveDataManager.GameStateData.DataEnemy temp = new SaveDataManager.GameStateData.DataEnemy();

        //Fill in player data for save game 
        temp.EnemyID = EnemyID;
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

        GameManager.Singleton._saveDataManager.GameState.Enemies.Add(temp);
    }

    public void LoadEnemy()
    {

        // Get Player Data Object 
        List<SaveDataManager.GameStateData.DataEnemy> Enemies = GameManager.Singleton._saveDataManager.GameState.Enemies;

        SaveDataManager.GameStateData.DataEnemy temp = null;

        for(int i = 0; i < Enemies.Count; i++){
            if(Enemies[i].EnemyID == EnemyID){
                temp = Enemies[i];
                break;
            }
        }

        if(temp == null){
            DestroyImmediate(gameObject);
            return;
        }

        // Load data back to Player 
        EnemyID = temp.EnemyID;
        Health = temp.Health;
        transform.position = new Vector3(temp.PosRotScale.X, temp.PosRotScale.Y, temp.PosRotScale.Z);
        transform.localRotation = Quaternion.Euler(temp.PosRotScale.RotX, temp.PosRotScale.RotY, temp.PosRotScale.RotZ);
        transform.localScale = new Vector3(temp.PosRotScale.ScaleX, temp.PosRotScale.ScaleY, temp.PosRotScale.ScaleZ);
    }
}


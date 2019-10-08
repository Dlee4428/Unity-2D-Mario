using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Singleton = null;

    [HideInInspector]
    public SaveDataManager _saveDataManager;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        if(Singleton == null) {
            Singleton = this;
        } else {
            Destroy(this.gameObject);
        }
        _saveDataManager = GetComponent<SaveDataManager>();
        //_saveDataManager.Load();
    }
}

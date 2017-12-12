using System.Security.Cryptography;
using System.Text;
using LitJson;
using UnityEngine;

public class GlobalServerValues : MonoBehaviour {
    // Global
    public readonly string URL = "http://tiar.ml/api/", pURL = "tiar.ml";
    [HideInInspector]
    public string SecretKey;
    public int UserID, SecretID;
    public bool status = false;
    public UserData userData;
    public JsonData Auth;

    // private and other =)
    private readonly string path = "Assets/key/key.txt";
    void Awake() {
            if (System.IO.File.Exists(path)) {
                SecretID = 2;
                SecretKey = System.IO.File.ReadAllText(path);
            }
            DontDestroyOnLoad(this);
        }
        [System.Serializable]
    public class UserData {
        public int id, points, agility, intelligence, stamina, strength, experience, level, capacity, gold, status;
        public string name, email;
    }
    // void Update() {
    // Debug.Log(userData.id);
    // }
}
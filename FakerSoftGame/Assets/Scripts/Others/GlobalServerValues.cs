using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class GlobalServerValues : MonoBehaviour {
    // Global
    public readonly string URL = "http://tiar.ml/api/", pURL = "tiar.ml";
    [HideInInspector]
    public string DBKey = null;
    public int UserID;
    public bool status = false;

    // private and other =)
    private readonly string path = "Assets/key/key.txt";
    void Awake () {
        if (System.IO.File.Exists (path)) {
            DBKey = Sha1Sum (System.IO.File.ReadAllText (path));
        }
    }
    private string Sha1Sum (string strToEncrypt) {
        UTF8Encoding ue = new UTF8Encoding ();
        byte[] bytes = ue.GetBytes (strToEncrypt);
        // encrypt bytes
        SHA1 sha = new SHA1CryptoServiceProvider ();
        byte[] hashBytes = sha.ComputeHash (bytes);
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++) {
            hashString += System.Convert.ToString (hashBytes[i], 16).PadLeft (2, '0');
        }
        return hashString.PadLeft (32, '0');
    }
}
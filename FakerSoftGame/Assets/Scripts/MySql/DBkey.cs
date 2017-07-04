using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DBkey : MonoBehaviour {
    public string dbkey;
    [HideInInspector]
    public string dbsecretkey;
    void Awake () {
        string path = "Assets/key/key.txt";
        if (System.IO.File.Exists (path) == true) {
            dbsecretkey = Sha1Sum (System.IO.File.ReadAllText (path));
        }else{
            dbsecretkey = null;
        }
    }
    public string Sha1Sum (string strToEncrypt) {
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public string[] foods;

    // Start is called before the first frame update
    void Start()
    {

        Resources.LoadAll

        DirectoryInfo dir = new DirectoryInfo("Assets/Kazb0/Resources");
        FileInfo[] info = dir.GetFiles("*.prefab");
        foods = info.Select(f => f.FullName).ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public string[] foods =
    {
        "Bacon",
        "Beef",
        "Bread",
        "Chicken",
        "Cucumber",
        "Egg",
        "Leek",
        "Lettuce",
        "Onion",
        "Pasta",
        "Peas",
        "Pepper",
        "Potato",
        "Rice",
        "Tofu",
        "Tomato",
    };

    // Start is called before the first frame update
    void Start()
    {

        //Resources.LoadAll("Food");

        /*DirectoryInfo dir = new DirectoryInfo("Assets/Kazb0/Resources");
        FileInfo[] info = dir.GetFiles("*.prefab");
        foods = info.Select(f => f.FullName).ToArray();*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

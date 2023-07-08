using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SandwichRecipe : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] list;
    static string[][] recipies = {
        new string[]{"bread", "lettice", "bread"},
        new string[]{"bread", "egg", "bread"},
        new string[]{"bread", "chicken", "lettice", "bread"}
    };
    SandwichRecipe setList(string[] list){this.list = list;return this;}
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
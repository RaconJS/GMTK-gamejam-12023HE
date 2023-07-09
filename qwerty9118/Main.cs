using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    private string[] foods =
    {
        "Bread",
        "Lettuce",
        "Tomato",
        "Egg",
        "Beef",
        "Bacon",
        "Chicken",
        "Potato",
        "Rice",
        "Pasta",
        "Cucumber",
        "Leek",
        "Onion",
        "Peas",
        "Pepper",
        "Tofu"
    };

    private int currentIngredient = 0;

    // Start is called before the first frame update
    void Start()
    {

        GameObject.Find(foods[currentIngredient]).GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().StartTrail();

        Debug.Log("start: " + currentIngredient + " - " + foods[currentIngredient]);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("before: "+currentIngredient + " - " + foods[currentIngredient]);

            GameObject.Find(foods[currentIngredient]).GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().StopTrail();
            //GameObject.Find(foods[currentIngredient]).transform.position = GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().firstPos;

            currentIngredient++;

            if (currentIngredient >= foods.Length)
            {
                currentIngredient = 0;
            }

            GameObject.Find(foods[currentIngredient]).GetComponent<PlayerMovement>().enabled = true;
            GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().RestartTrail();

            Debug.Log("after: " + currentIngredient + " - " + foods[currentIngredient]);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("before: " + currentIngredient + " - " + foods[currentIngredient]);

            GameObject.Find(foods[currentIngredient]).GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().StopTrail();
            //GameObject.Find(foods[currentIngredient]).transform.position = GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().firstPos;

            currentIngredient--;

            if (currentIngredient < 0)
            {
                currentIngredient = foods.Length - 1;
            }

            GameObject.Find(foods[currentIngredient]).GetComponent<PlayerMovement>().enabled = true;
            GameObject.Find(foods[currentIngredient]).GetComponent<SpawnTrail>().RestartTrail();

            Debug.Log("after: " + currentIngredient + " - " + foods[currentIngredient]);
        }

    }

}

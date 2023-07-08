using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<FoodItem>().getCookedLevel() > 0)
        {
            Destroy(this.GetComponent<Raw>());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.AddComponent<Raw>();

    }

}

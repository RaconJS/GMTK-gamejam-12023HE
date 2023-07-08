using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    GameObject orders;
    OrdersHandler ordersHandler;
    // Start is called before the first frame update
    void Start()
    {
        orders = transform.parent.parent.gameObject;
        ordersHandler = orders.GetComponent<OrdersHandler>();
    }
    void completeOrder(){
        ordersHandler.score += 1;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

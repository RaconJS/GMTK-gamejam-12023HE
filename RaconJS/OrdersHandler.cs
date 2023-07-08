using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersHandler : MonoBehaviour
{
	
	// Start is called before the first frame update
	float nextOrderTime;
	[SerializeField]GameObject possibleOrders;
	[SerializeField]GameObject orders;
	void Start()
	{
		nextOrderTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	void addOrder(){

	}
	void FixedUpdate(){
		if(Time.time>nextOrderTime){
			Instantiate(possibleOrders.transform.GetChild(Random.Range(0,possibleOrders.transform.childCount-1)),orders.transform);
			//addOrder();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersHandler : MonoBehaviour
{
	
	// Start is called before the first frame update
	float nextOrderTime;
	int maxOrders = 10;
	public int score = 0;
	[SerializeField]GameObject possibleOrders;
	[SerializeField]GameObject orders;
	void Start()
	{
		nextOrderTime = Time.time;
	}
	void OnTriggerEnter2D(Collider2D collider){//
		var i = 0;
		bool found = false;
		for(i=0;i<orders.transform.childCount;i++){
			GameObject order = orders.transform.GetChild(i).gameObject;
			{
				var recipe = order.GetComponent<SandwichRecipe>();
				var sandwichItem = collider.gameObject.GetComponent<SandwichItemHandler>();
				if(recipe&&sandwichItem)
				if(sandwichItem.isRecipe(recipe))
				{
    				Debug.Log("found recipe");
					found = true;
				}
			}
		}
		if(!found){
			//TODO:add animation
			//Destroy(collider.gameObject);
		}
		else{
			Destroy(collider.gameObject);
		}
	}
	// Update is called once per frame
	void Update()
	{
		
	}
	void addOrder(){

	}
	void FixedUpdate(){
		if(Time.time>nextOrderTime){
			if(possibleOrders.transform.childCount>=maxOrders){
				score -= 1;
			}
			else Instantiate(possibleOrders.transform.GetChild(Random.Range(0,possibleOrders.transform.childCount-1)),orders.transform);
			//addOrder();
			nextOrderTime =Time.time+8;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdersHandler : MonoBehaviour
{
	
	// Start is called before the first frame update
	float nextOrderTime;
	int maxOrders = 5;
	public int score = 0;
	[SerializeField]GameObject possibleOrders;
	[SerializeField]GameObject orders;
	[SerializeField]Text text;
	[SerializeField]float waitInterval = 15;
	void Start()
	{
		nextOrderTime = Time.time;
	}
	void destoryEntireObject(GameObject obj){
		while ( obj.transform.childCount>0) {
			destoryEntireObject(obj.transform.GetChild(0).gameObject);
		}
		Destroy(obj);
	}
	void OnTriggerEnter2D(Collider2D collider){//
		var i = 0;
		bool found = false;
		GameObject rootCompletedFood = collider.gameObject;
		for(i=0;i<orders.transform.childCount;i++){
			GameObject order = orders.transform.GetChild(i).gameObject;
			{
				var recipe = order.GetComponent<SandwichRecipe>();
				var sandwichItem = collider.gameObject.GetComponent<SandwichItemHandler>();
				if(recipe&&sandwichItem){
					if(recipe==null)Debug.Log("??");
					rootCompletedFood = sandwichItem.getRootObj();
					if(!rootCompletedFood)rootCompletedFood = collider.gameObject;
					if(sandwichItem.isRecipe(recipe))
					{
						Debug.Log("found recipe");
						found = true;
						break;
					}
				}
			}
			if(found)break;
		}
		if(found){
			//TODO:add animation
			Debug.Log(rootCompletedFood);
			destoryEntireObject(rootCompletedFood);
			Destroy(orders.transform.GetChild(i).gameObject);
			score++;
		}
		else{
			Debug.Log("invalid dish");
			score--;
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
			if(orders.transform.childCount>=maxOrders){
				score --;
			}
			else Instantiate(possibleOrders.transform.GetChild(Random.Range(0,possibleOrders.transform.childCount-1)),orders.transform);
			//addOrder();
			nextOrderTime =Time.time+waitInterval;
		}
		text.text = "score:"+score;
	}
}

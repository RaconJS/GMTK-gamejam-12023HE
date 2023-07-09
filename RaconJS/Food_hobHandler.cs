using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_hobHandler : MonoBehaviour
{
	// Start is called before the first frame update
	FoodItem foodItem;
	float timeLeft;
	bool isCooking = false;
	float cookInterval = 5;
	void Start()
	{
		foodItem = GetComponent<FoodItem>();
	}//HobHandler
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.GetComponent<HobHandler>()){
			startCooking();
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if(collider.gameObject.GetComponent<HobHandler>()){
			stopCooking();
		}
	}
	void startCooking(){
		isCooking = true;
		timeLeft = cookInterval;
	}
	void stopCooking(){
		isCooking = false;
	}
	// Update is called once per frame
	void Update()
	{
		if(isCooking){
			timeLeft -= Time.deltaTime;
			if(timeLeft<0){
				foodItem.cookedLevel++;
				startCooking();
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHandler : MonoBehaviour
{
	// Start is called before the first frame update
	void Start(){
		
	}
	void onTriggerEnter2D(Collider2D collider){
		var foodItem = collider.gameObject.GetComponent<FoodItem>();
		foodItem.cutLevel++;
	}
	// Update is called once per frame
	void Update(){
		
	}
}
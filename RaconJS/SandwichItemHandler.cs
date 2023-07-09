using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichItemHandler : MonoBehaviour
{
	// Start is called before the first frame update
	KeyCode placeItem_key = KeyCode.Space;
	/*SandwichItemHandler topOfSandwich{get{
		return transform.GetChild(transform.childCount-1).GetComponent<SandwichItemHandler>();
	}}*/
	//Components
	public bool isBread;
	PlayerMovement a;
	FoodItem foodItem;
	void Start()
	{
		foodItem = GetComponent<FoodItem>();
	}
    public bool isRecipe(GameObject sandwichRecipe){
    	if(sandwichRecipe.transform.childCount!=transform.childCount+1)return false;
    	Debug.Log(0);
    	for(var i=0;i<transform.childCount+1;i++){
    		var foodItem_recipe = sandwichRecipe.transform.GetChild(i).GetComponent<FoodItem>();
    		FoodItem foodItem_sandwich;
    		if(i==0)foodItem_sandwich = foodItem;
    		else foodItem_sandwich = transform.GetChild(i-1).GetComponent<FoodItem>();
    	Debug.Log(foodItem_sandwich.id);
    		if(foodItem_recipe.id != foodItem_sandwich.id)return false;
    	}
    	Debug.Log(2);
    	return true;
    }
    public GameObject getRootObj(){
    	if(transform.parent&&transform.parent.gameObject.GetComponent<SandwichItemHandler>())return transform.parent.gameObject;
    	else return gameObject;
    }
	void stackItem(FoodItem foodItem){
		var index = transform.childCount;
		foodItem.gameObject.transform.parent = transform;//topOfSandwich.gameObject.transform;
		var newPos = foodItem.gameObject.transform.localPosition;
		newPos.z = -1-index;
		foodItem.transform.localPosition = newPos;
	}
	void unstackItem(FoodItem foodItem){
		foodItem.gameObject.transform.parent = transform.parent;
		var index = transform.childCount;
		var newPos = foodItem.gameObject.transform.position;
		newPos.z+=index;//assume: item is on layer 0
		foodItem.gameObject.transform.position = newPos;
	}
	private void OnTriggerEnter2D(Collider2D collision){
		bool isReadyToBeStacked;
		SandwichItemHandler sandwichItem=collision.gameObject.GetComponent<SandwichItemHandler>();
		isReadyToBeStacked = sandwichItem!=null;
		if(isReadyToBeStacked){
			//foodItem.isMoving||isSandwichBase||
			if(
				isBread
				&&(!transform.parent||transform.parent.gameObject.GetComponent<SandwichItemHandler>()==null)
				&&sandwichItem.transform.childCount==0
				&&sandwichItem.transform.parent!=transform
			){
				stackItem(sandwichItem.foodItem);
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision){
		SandwichItemHandler sandwichItem=collision.gameObject.GetComponent<SandwichItemHandler>();
		if(isBread&&sandwichItem&&sandwichItem.transform.parent==transform){//assume: collision.gameObject's parent has SandwichItemHandler
			unstackItem(sandwichItem.foodItem);
		}
	}
	// Update is called once per frame
	bool isSelecting = false;
	void Update()
	{
		//space -> select the bottom of the sandwich for moving
		SandwichItemHandler script;
		if(isSelecting){
			if(transform.childCount>0)
				transform.GetChild(transform.childCount-1).GetComponent<SandwichItemHandler>().foodItem.selectThisItem(foodItem);
			else if(script=transform.parent.GetComponent<SandwichItemHandler>())
				script.foodItem.selectThisItem(foodItem);
			isSelecting = false;
		}
		if(foodItem.isMoving&&Input.GetKeyDown(placeItem_key)){
			isSelecting = true;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichItemHandler : MonoBehaviour
{
	// Start is called before the first frame update
	public SandwichItemHandler baseSandwich = null;//only on sandwich non-bases
	PlayerMovement a;
	[SerializeField]bool isSandwichBase = false;//is true if this is the bottom of the sandwich and there are items on top of this
	public SandwichItemHandler topOfSandwich = null;//only on sandwich bases
	[SerializeField]bool isBread;
	KeyCode placeItem_key = KeyCode.Space;
	//Components
	FoodItem foodItem;
	void Start()
	{
		foodItem = GetComponent<FoodItem>();
	}
    public bool isRecipe(SandwichRecipe sandwichRecipe){
    	if(!isSandwichBase && baseSandwich)return baseSandwich.isRecipe(sandwichRecipe);
    	if(!isSandwichBase)return false;//single item//baseSandwich.isRecipe(sandwichRecipe);
    	var transform = topOfSandwich.gameObject.transform;
    	var list = new string[sandwichRecipe.list.Length];
    	{//reverse list
    		int i = list.Length-1;
    		foreach(var foodItemId in sandwichRecipe.list)list[i--] = foodItemId;
    	}
    	foreach(var foodItemId in list){
    		//Debug.Log(foodItemId);Debug.Log(transform.gameObject?.GetComponent<FoodItem>()?.id);Debug.Log("_______");
    		if(foodItemId != transform.gameObject.GetComponent<FoodItem>().id)return false;
    		transform = transform.parent;
    	}
    	return true;
    }
	void stackItem(SandwichItemHandler sandwichItem){
		sandwichItem.gameObject.transform.parent = topOfSandwich.gameObject.transform;
		sandwichItem.baseSandwich = this;
		var newPos = sandwichItem.gameObject.transform.localPosition;
		newPos.z = -1;
		sandwichItem.gameObject.transform.localPosition = newPos;
		topOfSandwich = sandwichItem;
		if(sandwichItem==this)Debug.Log("BS");
	}
	void unstackItem(SandwichItemHandler sandwichItem){
		var parent = sandwichItem.gameObject.transform.parent = gameObject.transform.parent;
		var newPos = sandwichItem.gameObject.transform.position;
		newPos.z = parent?transform.parent.position.z-1f:transform.position.z;
		sandwichItem.gameObject.transform.position = newPos;
		sandwichItem.baseSandwich = null;
		var transform1 = sandwichItem.gameObject.transform;
		while(transform1.childCount>0){
			transform1 = transform1.GetChild(0);
			SandwichItemHandler script;
			if(script=transform1.GetComponent<SandwichItemHandler>())script.baseSandwich = sandwichItem;
			else break;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision){
		bool isReadyToBeStacked;
		SandwichItemHandler sandwichItem=collision.gameObject.GetComponent<SandwichItemHandler>();
		isReadyToBeStacked = sandwichItem!=null&&!sandwichItem.isSandwichBase&&!sandwichItem.baseSandwich;
		if(isReadyToBeStacked){
			if(isBread&&(!foodItem.isMoving)&&!sandwichItem.isSandwichBase&&!isSandwichBase){
				isSandwichBase = true;
				topOfSandwich = this;
			}
			//foodItem.isMoving||isSandwichBase||
			if(isSandwichBase&&baseSandwich!=sandwichItem){
				stackItem(sandwichItem);
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision){
		SandwichItemHandler sandwichItem=collision.gameObject.GetComponent<SandwichItemHandler>();
		if(isSandwichBase)
		if(sandwichItem&&sandwichItem.baseSandwich==this){//assume: collision.gameObject's parent has SandwichItemHandler
			var parent = sandwichItem.gameObject.transform.parent;
			unstackItem(sandwichItem);
			bool hasParent = false;
			if(parent){
				topOfSandwich = parent.gameObject.GetComponent<SandwichItemHandler>();
				hasParent = topOfSandwich!=this;
			}
			if(!hasParent){
				topOfSandwich = null;
				isSandwichBase = false;
			}
		}
	}
	// Update is called once per frame
	bool isSelecting = false;
	void Update()
	{
		//space -> select the bottom of the sandwich for moving
		if(isSelecting){
			if(isSandwichBase)
				topOfSandwich.foodItem.selectThisItem(foodItem);
			else if(baseSandwich)
				baseSandwich.foodItem.selectThisItem(foodItem);
			isSelecting = false;
		}
		if(foodItem.isMoving&&Input.GetKeyDown(placeItem_key)){
			isSelecting = true;
		}
	}
}
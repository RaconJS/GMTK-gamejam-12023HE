using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichItemHandler : MonoBehaviour
{
	// Start is called before the first frame update
	public SandwichItemHandler baseSandwich = null;//only on sandwich non-bases
	PlayerMovement a;
	bool isSandwichBase = false;//is true if this is the bottom of the sandwich and there are items on top of this
	public SandwichItemHandler topOfSandwich = null;//only on sandwich bases
	[SerializeField]bool isBread;
	KeyCode placeItem_key = KeyCode.Space;
	//Components
	FoodItem foodItem;
	void Start()
	{
		foodItem = GetComponent<FoodItem>();
	}
	private void OnTriggerEnter2D(Collider2D collision){
		bool isReadyToBeStacked;
		SandwichItemHandler sandwichItem=collision.gameObject.GetComponent<SandwichItemHandler>();
		isReadyToBeStacked = sandwichItem!=null;
		if(isReadyToBeStacked){
			Debug.Log("isReadyToBeStacked");
			Debug.Log(isBread);
			Debug.Log(foodItem.isMoving);
			if(isBread&&(!foodItem.isMoving)&&!sandwichItem.isSandwichBase&&!isSandwichBase){
				isSandwichBase = true;
				topOfSandwich = this;
			}
			if(isSandwichBase){
				Debug.Log(topOfSandwich);
				collision.gameObject.transform.parent = topOfSandwich.gameObject.transform;
				topOfSandwich = sandwichItem;
				sandwichItem.baseSandwich = this;
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision){
		SandwichItemHandler sandwichItem=collision.gameObject.GetComponent<SandwichItemHandler>();
		if(isSandwichBase)
		if(sandwichItem&&sandwichItem.baseSandwich==this){//assume: collision.gameObject's parent has SandwichItemHandler
			collision.gameObject.transform.parent = gameObject.transform.parent;
			var parent = collision.gameObject.transform.parent;
			if(parent){
				topOfSandwich = parent.gameObject.GetComponent<SandwichItemHandler>();
				sandwichItem.baseSandwich = null;
			}else{
				topOfSandwich = null;
				isSandwichBase = false;
			}
		}
	}
	// Update is called once per frame
	void Update()
	{
		if(foodItem.isMoving&&Input.GetKeyDown(placeItem_key)){

		}
	}
}
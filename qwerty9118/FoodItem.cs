using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] string id = "";
    [SerializeField] int cutLevel = 0;
    [SerializeField] int cookedLevel = 0;
    public PlayerMovement movement;
    public bool isMoving{get{return movement.enabled;}set{}}//used by: SandwichItemHandler
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void selectThisItem(FoodItem oldItem){
        if(oldItem){
            oldItem.unselectThisItem(this);
        }
        isSelected = true;
        isMoving = true;
    }
    private void unselectThisItem(FoodItem newItem){
        isSelected = false;
        isMoving = false;
    }
    public int getCutLevel()
    {
        return this.cutLevel;
    }

    public void incrementCutLevel()
    {
        this.cutLevel++;
    }

    public int getCookedLevel()
    {
        return this.cookedLevel;
    }

    public void incrementCookedLevel()
    {
        this.cookedLevel++;
    }

}

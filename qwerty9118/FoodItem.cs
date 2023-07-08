using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] string id = "";
    [SerializeField] int cutLevel = 0;
    [SerializeField] int cookedLevel = 0;
    private int oldCutLevel = 0;
    private int oldCookedLevel = 0;
    public PlayerMovement movement;
    public bool isMoving{get{return movement.enabled;}set{}}//used by: SandwichItemHandler
    public bool isSelected;
    public int dontSelectFrames = 0;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dontSelectFrames>0)dontSelectFrames--;
    }
    public bool selectThisItem(FoodItem oldItem){//returns false if it failed
        if(dontSelectFrames>0)return false;
        if(oldItem){
            oldItem.unselectThisItem(this);
        }
        isSelected = true;
        isMoving = true;
        movement.enabled=true;
        return true;
    }
    private void unselectThisItem(FoodItem newItem){
        isSelected = false;
        isMoving = false;
        movement.enabled=false;
    }

    // Start is called before the first frame update
    void Start()
    {

        movement = GetComponent<PlayerMovement>();
        //.Log("Food/" + this.gameObject.name + cutLevel + cookedLevel);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(
            "Food/" + this.gameObject.name + cutLevel + cookedLevel,
            typeof(Sprite)) as Sprite;

    }
    // Update is called once per frame
    void Update()
    {

        if (oldCutLevel != cutLevel || oldCookedLevel != cookedLevel)
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(
                "Food/" + this.gameObject.name + cutLevel + cookedLevel,
                typeof(Sprite)) as Sprite;

            oldCutLevel = cutLevel;
            oldCookedLevel = cookedLevel;

        }

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

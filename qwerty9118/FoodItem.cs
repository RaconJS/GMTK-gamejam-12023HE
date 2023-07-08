using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public string id = "";
    [SerializeField] int cutLevel = 0;
    [SerializeField] int cookedLevel = 0;
    private int oldCutLevel = 0;
    private int oldCookedLevel = 0;

    private Sprite[,] foodStateTextures = new Sprite[3, 2];

    public PlayerMovement movement;
    public bool isMoving{get{return movement.enabled;}set{}}//used by: SandwichItemHandler
    public bool isSelected;
    public int dontSelectFrames = 0;
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

        this.foodStateTextures[0,0] = Resources.Load(
            "Food/" + this.gameObject.name + "00",
            typeof(Sprite)) as Sprite;
        this.foodStateTextures[1, 0] = Resources.Load(
            "Food/" + this.gameObject.name + "10",
            typeof(Sprite)) as Sprite;
        this.foodStateTextures[2, 0] = Resources.Load(
            "Food/" + this.gameObject.name + "20",
            typeof(Sprite)) as Sprite;
        this.foodStateTextures[0, 1] = Resources.Load(
            "Food/" + this.gameObject.name + "01",
            typeof(Sprite)) as Sprite;
        this.foodStateTextures[1, 1] = Resources.Load(
            "Food/" + this.gameObject.name + "11",
            typeof(Sprite)) as Sprite;
        this.foodStateTextures[2, 1] = Resources.Load(
            "Food/" + this.gameObject.name + "21",
            typeof(Sprite)) as Sprite;

        for (int cut = 0; cut < 3; cut++)
        {
            for (int cook = 0; cook < 2; cook++)
            {

                this.foodStateTextures[cut, cook] = Resources.Load(
                    "Food/" + this.gameObject.name + cut + cook,
                    typeof(Sprite)) as Sprite;

                if (this.foodStateTextures[cut, cook] == null)
                {

                    if (cut + cook == 0)
                    {
                        this.foodStateTextures[cut, cook] = Resources.Load(
                            "Food/GenericFoodItem00",
                            typeof(Sprite)) as Sprite;
                    }

                    else if (cook == 0)
                    {

                    }

                }

            }
        }

        //.Log("Food/" + this.gameObject.name + cutLevel + cookedLevel);
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = ;

    }
    // Update is called once per frame
    void Update()
    {
        if(dontSelectFrames>0)dontSelectFrames--;
        if (oldCutLevel != cutLevel || oldCookedLevel != cookedLevel)
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = this.foodStateTextures[cutLevel, cookedLevel];

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

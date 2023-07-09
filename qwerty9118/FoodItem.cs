using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [Header("foodStates")]
    public string id = "";
    [SerializeField] int cutLevel = 0;
    [SerializeField] int cookedLevel = 0;

    private int oldCutLevel = 0;
    private int oldCookedLevel = 0;
    private bool genCut1 = false;
    private bool genCut2 = false;
    private bool genCook = false;

    private Sprite[,] foodStateTextures = new Sprite[3, 2];
    SpriteRenderer foodRend;

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
    public bool compair(FoodItem foodItem){
        if(foodItem.id!=id)return false;
        if(foodItem.cookedLevel!=foodItem.cookedLevel)return false;
        if(foodItem.cutLevel!=foodItem.cutLevel)return false;
        return true;
    }

    public void setId(string theId)
    {
        id = theId;

        for (int cut = 0; cut < 3; cut++)
        {
            for (int cook = 0; cook < 2; cook++)
            {

                this.foodStateTextures[cut, cook] = Resources.Load(
                    "Food/" + this.id + cut + cook,
                    typeof(Sprite)) as Sprite;

                if (this.foodStateTextures[cut, cook] == null)
                {

                    if (cook == 1)
                    {
                        this.foodStateTextures[cut, cook] = this.foodStateTextures[cut, 0];
                        genCook = true;
                        continue;
                    }

                    else if (cut == 1)
                    {
                        this.foodStateTextures[cut, cook] = this.foodStateTextures[0, cook];
                        genCut1 = true;
                        continue;
                    }

                    else if (cut == 2)
                    {
                        this.foodStateTextures[cut, cook] = this.foodStateTextures[1, cook];
                        genCut2 = true;
                        continue;
                    }

                    else
                    {
                        this.foodStateTextures[cut, cook] = Resources.Load(
                            "Food/GenericFoodItem00",
                            typeof(Sprite)) as Sprite;
                        continue;
                    }

                }

            }

        }

        //.Log("Food/" + this.gameObject.name + cutLevel + cookedLevel);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.foodStateTextures[0, 0];

    }

    // Start is called before the first frame update
    void Start()
    {

        movement = GetComponent<PlayerMovement>();
        foodRend = GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        if(id == null)
        if(dontSelectFrames>0)dontSelectFrames--;
        if (oldCutLevel != cutLevel || oldCookedLevel != cookedLevel)
        {

            GetComponent<Renderer>().material.mainTextureScale = new Vector2(1f, 1f);
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(1f, 1f);

            if (cutLevel > 2)
            {
                Destroy(this);
            }
            if (cookedLevel > 1)
            {
                Destroy(this);
            }

            this.gameObject.GetComponent<SpriteRenderer>().sprite = this.foodStateTextures[cutLevel, cookedLevel];

            if (genCook && cookedLevel == 1)
            {
                foodRend.color = new Color(0.5f, 0.5f, 0.5f);
            }
            if (genCut1 && cutLevel == 1)
            {
                //this.gameObject.GetComponent<Material>().SetTextureScale(this.foodStateTextures[cutLevel, cookedLevel].name, new Vector2(0.7f, 0.6f));
                //this.gameObject.GetComponent<Material>().SetTextureOffset(this.gameObject.name + cutLevel + cookedLevel, new Vector2(0.7f, 0.6f));
                GetComponent<Renderer>().material.mainTextureScale = new Vector2(2f, 1f);
                //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0.5f, 0f);
            }
            if (genCut2 && cutLevel == 2)
            {
                GetComponent<Renderer>().material.mainTextureScale = new Vector2(4f, 5f);
                //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0.7f, 0.8f);
            }

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

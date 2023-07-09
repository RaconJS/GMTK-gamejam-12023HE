using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrail : MonoBehaviour
{
    private bool toggle = false;
    private int framesForNPC = 60;
    private int frameCount = 0;
    private float distForNPC = 5.5f;
    private float distTravelled = 0;
    private int framesForTrail = 15;
    private int framesTravelled = 0;
    private bool resetTrail = false;
    public bool hasMoved = false;
    public Vector2 firstPos;
    public Vector2 lastPos;
    public List<Vector3> trail = new List<Vector3>();
    public List<GameObject> npcFoods = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        firstPos = transform.position;
        lastPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if ((hasMoved && !toggle))// || resetTrail)
        {
            if (frameCount > framesForNPC)
            {
                frameCount = 0;
                GameObject npcFood = Instantiate(this.gameObject, firstPos, Quaternion.identity);
                npcFood.GetComponent<PlayerMovement>().enabled = false;
                npcFood.GetComponent<SpawnTrail>().enabled = false;
                npcFood.GetComponent<NPCMovement>().enabled = true;
                npcFood.GetComponent<CircleCollider2D>().enabled = true;
                npcFood.GetComponent<NPCMovement>().parentName = this.gameObject.name;
                npcFood.GetComponent<FoodItem>().id = this.gameObject.name;
                npcFood.transform.parent = transform.parent;
                //npcFood.tag = this.gameObject.name;
                npcFoods.Add(npcFood);
            }
            else
            {
                frameCount++;
            }
        }

        if (toggle)
        {

            if (distTravelled < distForNPC)
            {
                distTravelled += Vector2.Distance(transform.position, lastPos);
            }
            else
            {
                distTravelled = 0;
                GameObject npcFood = Instantiate(this.gameObject, firstPos, Quaternion.identity);
                npcFood.GetComponent<PlayerMovement>().enabled = false;
                npcFood.GetComponent<SpawnTrail>().enabled = false;
                npcFood.GetComponent<NPCMovement>().enabled = true;
                npcFood.GetComponent<NPCMovement>().parentName = this.gameObject.name;
                //npcFood.tag = this.gameObject.name;
                npcFoods.Add(npcFood);
            }

            if (Vector2.Distance(transform.position, lastPos) > 0)//distTravelled2 < distForTrail)
            {
                if(!hasMoved) hasMoved = true;

                if (resetTrail)
                {

                    transform.position = firstPos;

                    resetTrail = false;
                    for (int i = 0; i < npcFoods.Count; i++)
                    {

                        Destroy(npcFoods[i]);

                    }
                    npcFoods = new List<GameObject>();
                    trail = new List<Vector3>();

                }

                framesTravelled++;

                //distTravelled2 += Vector2.Distance(transform.position, lastPos);
                if (framesTravelled > framesForTrail)
                {
                    framesTravelled = 0;
                    trail.Add(transform.position);
                }
            }

            lastPos = transform.position;

        }

    }

    public void StopTrail()
    {
        toggle = false;
    }

    public void StartTrail()
    {
        toggle = true;
    }

    public void RestartTrail()
    {
        toggle = true;
        resetTrail = true;
    }

    public bool CheckTrail()
    {
        return toggle;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrail : MonoBehaviour
{

    private float distForNPC = 5.5f;
    private float distTravelled = 0;
    private int framesForTrail = 15;
    private int framesTravelled = 0;
    private Vector2 firstPos;
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

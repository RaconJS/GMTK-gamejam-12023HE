using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public string parentName = "";
    private int nextPoint = 0;
    private int framesForTrail = 15;
    private int framesTravelled = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if parent fooditem is moving, move
        if (Vector2.Distance(GameObject.Find(parentName).transform.position, GameObject.Find(parentName).GetComponent<SpawnTrail>().lastPos) > 0)
        {
            float distToNext = Vector2.Distance(transform.position, GameObject.Find(parentName).GetComponent<SpawnTrail>().trail[nextPoint]);

            framesTravelled++;

            if (framesTravelled > framesForTrail)
            {
                framesTravelled = 0;
                nextPoint++;
            }

            transform.position += (GameObject.Find(parentName).GetComponent<SpawnTrail>().trail[nextPoint] - transform.position) / framesForTrail;

        }

    }

}

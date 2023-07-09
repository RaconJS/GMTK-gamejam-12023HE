using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public string parentName = "";
    private int nextPoint = 0;
    private int framesForTrail = 15;
    private int framesTravelled = 0;
    private Vector3 step;

    // Start is called before the first frame update
    void Start()
    {

        step = (GameObject.Find(parentName).GetComponent<SpawnTrail>().trail[nextPoint] - transform.position) / framesForTrail;

    }

    // Update is called once per frame
    void Update()
    {

        //if parent fooditem is moving, or parent fooditem has moved and switched control, move
        if
        (
            (
                GameObject.Find(parentName).GetComponent<SpawnTrail>().hasMoved && !GameObject.Find(parentName).GetComponent<SpawnTrail>().CheckTrail()
            )

            || Vector2.Distance(GameObject.Find(parentName).transform.position, GameObject.Find(parentName).GetComponent<SpawnTrail>().lastPos) > 0
        )
        {
            //float distToNext = Vector2.Distance(transform.position, GameObject.Find(parentName).GetComponent<SpawnTrail>().trail[nextPoint]);

            framesTravelled++;

            if (framesTravelled > framesForTrail)
            {

                framesTravelled = 0;
                nextPoint++;
                if (nextPoint <= GameObject.Find(parentName).GetComponent<SpawnTrail>().trail.Count)
                {
                    step = (GameObject.Find(parentName).GetComponent<SpawnTrail>().trail[nextPoint] - transform.position) / framesForTrail;
                }
                
            }

            transform.position += step;

        }

    }

}

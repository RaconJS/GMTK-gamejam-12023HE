using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 5.5f;
    private float varSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        varSpeed = speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.W))
        {

            if (Input.GetKey(KeyCode.S))
            {
                return;
            }

            this.transform.position = this.transform.position + new Vector3(0, varSpeed, 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {

            this.transform.position = this.transform.position + new Vector3(0, -varSpeed, 0);

        }

        if (Input.GetKey(KeyCode.A))
        {

            if (Input.GetKey(KeyCode.D))
            {
                return;
            }

            this.transform.position = this.transform.position + new Vector3(-varSpeed, 0, 0);

        }
        else if (Input.GetKey(KeyCode.D))
        {

            this.transform.position = this.transform.position + new Vector3(varSpeed, 0, 0);

        }

    }
}

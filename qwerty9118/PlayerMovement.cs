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

        int x = 0, y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            y++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x--;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x++;
        }

        this.transform.position += Vector3.Normalize(new Vector3(x, y, 0)) * varSpeed;

    }

    private void OnBecameInvisible()
    {

        transform.position = new Vector2(0,0);

    }

}

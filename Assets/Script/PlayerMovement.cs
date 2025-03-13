using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
 
    
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(moveX, moveY, 0);

        float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y + direction.z + direction.z);
        Vector3 normalized = new Vector3(direction.x / magnitude, direction.y / magnitude, direction.z / magnitude);


        //Vector3 direction = new Vector3(moveX, moveY, 0).normalized;


        if (magnitude < 0)
        {
            Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
            transform.position += move;
        }
          
        
      

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow3D : MonoBehaviour
{
   

    public float speed = 5f;
    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                transform.position = targetPosition;

            }
        }
        
    }
   
}

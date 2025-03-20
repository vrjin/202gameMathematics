using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class degreetored : MonoBehaviour
{
     public float degres = 45f;
     public float  speed = 4f;
     public float angle = 30f;

    
    void Start()
    {
        float degres = 45f;
        float radians = degres * Mathf.Deg2Rad;
        Debug.Log("45도 -> 라디안 : " + radians);

        float radianValue = Mathf.PI / 3;
        float degreeValue = radianValue * Mathf.Rad2Deg;
        Debug.Log("파이/3 라디안 -> 도 변환 :" + degreeValue);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 4f;
        float angle = 30f;
        float radians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
        transform.position += direction * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed -=1f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += 1f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angle -= 15f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            angle += 15f;
        }
    }

    



    

    

   
}

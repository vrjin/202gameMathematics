using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform sun;
    public float degres = 25f;
    public float speed = 4f;
    public float angle = 30f;




    // Update is called once per frame
    void Update()
    {
        float speed = 4f;
        float angle = 30f;
        float radians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
        transform.position += direction * speed * Time.deltaTime;


    }
}

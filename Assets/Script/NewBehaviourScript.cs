using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;

    public float viewAngle = 60f; 
   
    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 forward = transform.forward;

        float dot = Vector3.Dot(forward, toPlayer);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (angle < viewAngle / 2)
        {
            Debug.Log("�÷��̾ �þ߾ȿ� �ֽ��ϴ�!");
        }
    }
}

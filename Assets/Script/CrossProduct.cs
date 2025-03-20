using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    public Transform targer;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerFoward = transform.forward;
        Vector3 toTarger = (targer.position - transform.position).normalized;

        if (IsLeft(playerFoward, toTarger, Vector3.up))
        {
            Debug.Log("타켓 플레이어 기준 왼쪽에 있습니다");
        }
        else
        {
            Debug.Log("타켓 플레이어 기준 오른쪽에 있습니다");
        }


    }

    bool IsLeft (Vector3 forward, Vector3 targeDirection, Vector3 up)
    {
        Vector3 cross = Vector3.Cross(forward, targeDirection);
        return Vector3.Dot(cross, up) > 0;

    }
    
    
}

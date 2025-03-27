using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerForward = transform.forward;
        Vector3 toTarget = (target.position - transform.position).normalized;

        if (IsLeft(playerForward, toTarget, Vector3.up))
        {
            Debug.Log("Ÿ���� �÷��̾� ���� ���ʿ� ����");

        }
        else
        {
            Debug.Log("Ÿ���� �÷��̾� ���� �����ʿ� ����");
        }
    }

    bool IsLeft(Vector3 forwrd, Vector3 targetDirection, Vector3 up)
    {
        Vector3 cross = Vector3.Cross(forwrd, targetDirection);

        return Vector3.Dot(cross, up) < 0;
    }
}

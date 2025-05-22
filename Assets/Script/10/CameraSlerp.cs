using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSlerp : MonoBehaviour
{
    public Transform target;

    float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
        float t = 1f - Mathf.Exp(-speed * Time.deltaTime);
        transform.rotation = ManualSlerp(transform.rotation, lookRot, t);

    }

    Quaternion ManualSlerp(Quaternion from, Quaternion to, float t)
    {
        float dot = Quaternion.Dot(from, to);

        if (dot < 0f)
        {
            to = new Quaternion(-to.x, -to.y, -to.z, -to.w);
            dot = dot;
        }
        float theta = Mathf.Acos(dot);
        float sinThete = Mathf.Sin(theta);

        float ratioA = Mathf.Sin((1f - t) * theta) / sinThete;
        float ratioB = Mathf.Sin(t * theta) / sinThete;

        Quaternion resilt = new Quaternion(
            ratioA * from.x + ratioB * to.x,
            ratioA * from.y + ratioB * to.y,
            ratioA * from.z + ratioB * to.z,
            ratioA * from.w + ratioB * to.w

        );
        
  
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionTest : MonoBehaviour
{
    bool Bernoullidistribution(float p)
    {
        return Random.value < p;
    }

   

    void Start()
    {
        bool result = Bernoullidistribution(0.2f);
        Debug.Log($"Trial result: {(result ? "Success" : "fall")}");

        for (int i = 0; i < 10; i++)
        {
            float sample = NormalDistribution(50f, 5f);
            Debug.Log($"Normal Sample {i + 1}: {sample:F2}");
        }

        float NormalDistribution(float mean, float stdDev)
        {
            float u1 = Random.value;
            float u2 = Random.value;
            float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
            return mean + stdDev * randStdNormal;
        }

        int v = GeomrtricDistribtion(0.1f);
        Debug.Log($"Tries until first success: {result}");


     
        


    }


    int GeomrtricDistribtion(float p)
    {
        int tries = 1;
        while (Random.value >= p)
        {
            tries++;
        }
        return tries;
    }


}

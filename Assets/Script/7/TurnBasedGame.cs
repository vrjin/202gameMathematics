using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedGame : MonoBehaviour
{
    [SerializeField] float critChance = 0.2f;
    [SerializeField] float meanDamage = 20f;
    [SerializeField] float stdDevDamage = 5f;
    [SerializeField] float enemyHP = 100f;
    [SerializeField] float poissonLambda = 2f;
    [SerializeField] float hitRate = 0.6f;
    [SerializeField] float critDamageRate = 2f;
    [SerializeField] int maxHitsPerTurn = 5;

    int turn = 0;
    bool rareItemObtained = false;

    string[] rewards = { "Gold", "Weapon", "Armor", "Potion" };

    public void StartSimulation()
    {
        // ���Ϻ��� ���ø�: ���� �������� ���� ������ �ݺ��ϴ� ����
        rareItemObtained = false;
        turn = 0;
        while (!rareItemObtained)
        {
            SimulateTurn();
            turn++;
        }

        Debug.Log($"���� ������ {turn} �Ͽ� ȹ��");
    }

    void SimulateTurn()
    {
        Debug.Log($"--- Turn {turn + 1} ---");

        // Ǫ�Ƽ� ���ø�: �� ���� ��
        int enemyCount = SamplePoisson(poissonLambda);
        Debug.Log($"�� ���� : {enemyCount}");

        for (int i = 0; i < enemyCount; i++)
        {
            // ���� ���ø�: ���� Ƚ��
            int hits = SampleBinomial(maxHitsPerTurn, hitRate);
            float totalDamage = 0f;

            for (int j = 0; j < hits; j++)
            {
                float damage = SampleNormal(meanDamage, stdDevDamage);

                // �������� ���� ���ø�: Ȯ�� ��� ġ��Ÿ �߻�
                if (Random.value < critChance)
                {
                    damage *= critDamageRate;
                    Debug.Log($" ũ��Ƽ�� hit! {damage:F1}");
                }
                else
                    Debug.Log($" �Ϲ� hit! {damage:F1}");

                totalDamage += damage;
            }

            if (totalDamage >= enemyHP)
            {
                Debug.Log($"�� {i + 1} óġ! (������: {totalDamage:F1})");

                // �յ� ���� ���ø�: ���� ����
                string reward = rewards[UnityEngine.Random.Range(0, rewards.Length)];
                Debug.Log($"����: {reward}");

                if (reward == "Weapon" && Random.value < 0.2f)
                {
                    rareItemObtained = true;
                    Debug.Log("���� ���� ȹ��!");
                }
                else if (reward == "Armor" && Random.value < 0.2f)
                {
                    rareItemObtained = true;
                    Debug.Log("���� �� ȹ��");
                }
            }
        }
    }

    // --- ���� ���� �Լ��� ---
    int SamplePoisson(float lambda)
    {
        int k = 0;
        float p = 1f;
        float L = Mathf.Exp(-lambda);
        while (p > L)
        {
            k++;
            p *= Random.value;
        }
        return k - 1;
    }

    int SampleBinomial(int n, float p)
    {
        int success = 0;
        for (int i = 0; i < n; i++)
            if (Random.value < p) success++;
        return success;
    }

    float SampleNormal(float mean, float stdDev)
    {
        float u1 = Random.value;
        float u2 = Random.value;
        float z = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
        return mean + stdDev * z;
    }
}

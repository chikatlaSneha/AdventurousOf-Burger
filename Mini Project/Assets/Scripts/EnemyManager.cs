using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    float health = 100;
    float SpeedVal;

    public void OnEnable()
    {
        health = 100;
    }

    void Update()
    {
        if (gameObject.transform.position.z > 0)
        {
            SpeedVal = -2.0f * Time.deltaTime;
            gameObject.transform.Translate(Vector3.forward * SpeedVal);
        }
        else
        {
            gameObject.SetActive(false);
            }
    }

    public void HealthAffected()
    {
        health -= 100f;
        gameObject.SetActive(false);
        }
}

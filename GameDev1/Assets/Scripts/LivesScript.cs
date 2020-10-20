using System;
using UnityEngine;

public class LivesScript : MonoBehaviour
{
    public IntData lifeCount;
    public FloatData health;
    public Vector3 spawn;
    public GameObject spawnPoint;

    private void Start()
    {
        spawn = spawnPoint.transform.position;
    }

    private void Update()
    {
        if (health.value < 0)
        {
            lifeCount.value--;
            gameObject.transform.position = spawn;
            health.value = 1f;
        }

        if (lifeCount.value == 0)
        {
            gameObject.SetActive(false);
        }
    }
}

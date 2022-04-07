using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject EnnemyToSpawn;
    private GameObject CurrentEnnemy;
    private bool canSpawnNewEnnemy = true, isWaitingToSpawn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!EnnemyToSpawn) return;
        if (!CurrentEnnemy)
        {
            if (canSpawnNewEnnemy) { CurrentEnnemy = Instantiate(EnnemyToSpawn, transform); canSpawnNewEnnemy = false; }
        }
        else
        {
            if (!CurrentEnnemy.GetComponent<Ennemy>().IsAlive) { Destroy(CurrentEnnemy); StartCoroutine(SpawnEnnemyInSec(1)); }
        }
    }

    private IEnumerator SpawnEnnemyInSec(int s)
    {
        yield return new WaitForSeconds(s);
        canSpawnNewEnnemy = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //todo add audio

    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] float secondsBetweenSpawns = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddEnemy());
    }

    private IEnumerator AddEnemy()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.transform.parent = GameObject.Find("Enemies").transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}

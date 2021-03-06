﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] float secondsBetweenSpawns = 10f;
    [SerializeField] int numEnemies = 10;
    [SerializeField] Text enemiesLeft;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddEnemy());
    }

    private IEnumerator AddEnemy()
    {
        while (numEnemies > 0 && playerHealth.isPlaying == true)
        {
            var newEnemy = Instantiate(enemyPrefab, enemyPrefab.transform.position, transform.rotation);
            newEnemy.transform.parent = GameObject.Find("Enemies").transform;
            numEnemies--;
            enemiesLeft.text = "Enemies Remaining: " + numEnemies.ToString();
            GetComponent<AudioSource>().PlayOneShot(spawnSound);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}

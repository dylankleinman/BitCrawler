using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] int attackRange = 10;
    [SerializeField] ParticleSystem projectileParticle;

    //State
    Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if (sceneEnemies.Length == 0) { return; };

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        var closestEnemyDist = Vector3.Distance(transform.position, closestEnemy.position);
        var testEnemyDist = Vector3.Distance(transform.position, testEnemy.position);
        if (testEnemyDist < closestEnemyDist)
        {
            return testEnemy;
        }
            return closestEnemy;
    }

    private void FireAtEnemy()
    {
        if (Vector3.Distance(targetEnemy.position, objectToPan.position) <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}

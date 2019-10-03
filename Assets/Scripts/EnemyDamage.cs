using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnParticleCollision(GameObject other)
    {
        print("Particles Collided with enemy " + gameObject.name);
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints--;
    }
}

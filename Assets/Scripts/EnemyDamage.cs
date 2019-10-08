using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnParticleCollision(GameObject other)
    {
        //print("Particles Collided with enemy " + gameObject.name);
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy(deathParticlePrefab);
        }
    }

    public void KillEnemy(ParticleSystem particleSystem)
    {
        var deathParticles = Instantiate(particleSystem, transform.position, Quaternion.identity);
        deathParticles.Play();
        Destroy(deathParticles.gameObject, deathParticles.main.duration);

        Destroy(gameObject); //remove enemy
    }

    private void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
    }
}

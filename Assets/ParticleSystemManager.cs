using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem deathParticle;
    private bool isDead = false;

    public void Start()
    {    }

    public void InstantiateDeathParticle(Vector3 bulletD )
    {
        if (isDead == false)
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(Instantiate(deathParticle.gameObject, transform.position, Quaternion.FromToRotation(Vector3.forward, bulletD)) as GameObject, deathParticle.startLifetime);
            isDead = true;
        }
    }
}

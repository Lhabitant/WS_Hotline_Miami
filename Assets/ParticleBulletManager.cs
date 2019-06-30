using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBulletManager : MonoBehaviour
{
    public ParticleSystem trace;
    public ParticleSystem hitParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InstantiateTraceParticle()
    {
        //!\\ Not Working
        //Debug.Log("Trace Activated");
       // ParticleSystem thisTrace = Instantiate(trace, transform.position, transform.rotation);
        //thisTrace.GetComponent<TraceGetParentTransform>().normalizeDirection = GetComponent<BulletScript>().normalizeDirection;
        //thisTrace.GetComponent<TraceGetParentTransform>().speed = GetComponent<BulletScript>().speed;
    }

    public void InstantiateImpactParticle()
    {
        Destroy(Instantiate(hitParticle.gameObject, transform.position, transform.rotation) as GameObject, hitParticle.startLifetime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceGetParentTransform : MonoBehaviour
{
    public Vector3 normalizeDirection;
    public float speed;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = normalizeDirection * speed * Time.deltaTime;
    }
}

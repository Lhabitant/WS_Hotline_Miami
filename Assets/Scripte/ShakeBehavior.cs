using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    private Transform transform;
    private float shakeDuration;
    [SerializeField]
    float shakeDurationInput = 0.2f;
    [SerializeField]
    float shakeMagnitude = 0f;
    [SerializeField]
    float dampingSpeed = 1f;

    Vector3 initialPosition;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        TriggerShake();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = transform.localPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = shakeDurationInput;
    }
}

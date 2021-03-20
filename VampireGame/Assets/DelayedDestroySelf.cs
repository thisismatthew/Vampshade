using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroySelf : MonoBehaviour
{
    public float delaySeconds = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delaySeconds);
    }
}

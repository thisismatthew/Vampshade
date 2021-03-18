using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().shaded = true;
        Debug.Log("Shaded");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().shaded = false;
    }
}

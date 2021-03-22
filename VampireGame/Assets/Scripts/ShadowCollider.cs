using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            collision.transform.GetComponent<Player>().shaded += 1;
            /*Debug.Log("Shaded");*/
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            collision.transform.GetComponent<Player>().shaded -= 1;
        }
    }
}

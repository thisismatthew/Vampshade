using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    public GameObject vamp;
    public Color startColor;
    public Color shadedColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().shaded +=1;
        //Debug.Log("Shaded");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().shaded -= 1;
        
    }
}

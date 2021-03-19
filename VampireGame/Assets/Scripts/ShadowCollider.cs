using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    public GameObject vamp;
    public Color startColor;
    public Color shadedColor;

    private void Start()
    {
        startColor = vamp.GetComponent<Renderer>().material.GetColor("_Color");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().shaded = true;
        vamp.GetComponent<Renderer>().material.SetColor("_Color", shadedColor);
        //Debug.Log("Shaded");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().shaded = false;
        vamp.GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a convoluted solution and I'm sure theres a much better (non colider) way of doing this but I don't know how.
//basically this checks for colliders placed on objects that then sorts that object in front or behind the player sprite. 
public class IsometricLayerOrder : MonoBehaviour
{
    public int layerColliderCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "shadow")
        {
            layerColliderCounter++;
            if (collision.tag == ("sortInfront"))
            {
                collision.GetComponentInParent<Renderer>().sortingOrder = -1;
                Debug.Log("Infront" + collision.transform.parent.name);
            }

            if (collision.tag == ("sortBehind"))
            {
                collision.GetComponentInParent<Renderer>().sortingOrder = 1;
                Debug.Log("Behind" + collision.transform.parent.name);

            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        layerColliderCounter--;
        if (collision.tag == ("sortInfront") || collision.tag == ("sortBehind"))
        {
            if (layerColliderCounter == 0 && gameObject.tag == "player")
            {
                collision.GetComponentInParent<Renderer>().sortingOrder = 1;
                Debug.Log("Unordered" + collision.transform.parent.name);
            }
        }
    }

}

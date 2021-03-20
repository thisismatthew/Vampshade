using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsometricLayerOrder : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("layerPivot"))
        {
            if (collision.transform.position.x + collision.transform.position.y > transform.position.x + transform.position.y)
            {
                Debug.Log(transform.position + " infront of " + collision.name +" "+ collision.transform.position);
                GetComponentInParent<Renderer>().sortingOrder = 1;
            }
            else
            {
                Debug.Log(transform.position + "behind " + collision.name + " " + collision.transform.position);
                GetComponentInParent<Renderer>().sortingOrder = -1;
            }
        }
    }

}

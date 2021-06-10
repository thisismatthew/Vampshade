using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//loll this is convoluted and I'm sure theres a much better non colider way of doing this but the maths is not in my head.
//basically this checks for colliders placed on objects that then sorts that object in front or behind lil vamp. 
public class IsometricLayerOrder : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Player>().layerColliderCounter += 1;
        if (collision.tag == ("sortInfront"))
        {
            collision.GetComponentInParent<Renderer>().sortingOrder = -1;
            Debug.Log("Infront" + collision.transform.parent.name) ;
        }

        if (collision.tag == ("sortBehind"))
        {
            collision.GetComponentInParent<Renderer>().sortingOrder = 1;
            Debug.Log("Behind" + collision.transform.parent.name);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
/*        GetComponent<Player>().layerColliderCounter -= 1;*/
        if (collision.tag == ("sortInfront") || collision.tag == ("sortBehind"))
        {
            if (GetComponent<Player>().layerColliderCounter == 0)
            {
                collision.GetComponentInParent<Renderer>().sortingOrder = 1;
                Debug.Log("Unordered" + collision.transform.parent.name);
            }
        }
    }

}

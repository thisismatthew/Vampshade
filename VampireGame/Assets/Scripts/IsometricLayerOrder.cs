using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsometricLayerOrder : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Player>().layerColliderCounter += 1;
        if (collision.tag == ("sortInfront"))
        {
            GetComponent<Renderer>().sortingOrder = 1;
            Debug.Log("Infront");
        }

        if (collision.tag == ("sortBehind"))
        {
            GetComponent<Renderer>().sortingOrder = -1;
            Debug.Log("Behind");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Player>().layerColliderCounter -= 1;
        if (collision.tag == ("sortInfront") || collision.tag == ("sortBehind"))
        {
            if (GetComponent<Player>().layerColliderCounter == 0)
            {
                GetComponent<Renderer>().sortingOrder = 0;
                Debug.Log("Unordered");
            }
        }
    }

}

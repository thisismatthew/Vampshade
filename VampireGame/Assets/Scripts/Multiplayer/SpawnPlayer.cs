using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject newPlayer;
    private GameObject[] players;
    public void Start()
    {
        newPlayer = PhotonNetwork.Instantiate(playerPrefab.name, transform.position, Quaternion.identity);

        CapsuleCollider2D newPlayerCollider = newPlayer.GetComponent<CapsuleCollider2D>();
        //find all the players in the game and make sure that we are ignoring eachothers colliders
        players = GameObject.FindGameObjectsWithTag("player");
        foreach( GameObject p in players)
        {
            CapsuleCollider2D otherPlayerCollider = p.GetComponent<CapsuleCollider2D>();
            Physics2D.IgnoreCollision(newPlayerCollider, otherPlayerCollider);
        }
    }
}

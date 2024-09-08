using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBound : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (!other.gameObject.CompareTag("Bad"))
            gameManager.GameOver();
    }
}

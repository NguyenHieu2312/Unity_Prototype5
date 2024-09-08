using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public int targetValue = 5;
    [SerializeField] private float forceStrength;
    [SerializeField] private List<ParticleSystem> particales = new List<ParticleSystem>();
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        TargetControll();
    }

    void TargetControll()
    {
        rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)));
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.ScoreManager(targetValue);

            int index = Random.Range(0, particales.Count);
            Instantiate(particales[index], this.transform.position, particales[index].transform.rotation);
            Destroy(this.gameObject);
        }
    }
}

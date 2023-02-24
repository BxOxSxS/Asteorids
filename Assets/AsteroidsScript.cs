using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();

        Vector3 movmentVector = player.transform.position - transform.position;
        movmentVector = movmentVector.normalized * 10;

        rb.GetComponent<Rigidbody>().AddForce(movmentVector, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)));

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().GameOver();
        }
    }
}

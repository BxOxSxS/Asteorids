using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();

        Vector3 movmentVector = player.transform.position - transform.position;
        movmentVector = movmentVector.normalized * 20;


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
        Destroy(gameObject);
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControler>().Hited();
        }
    }

    public void Explode()
    {
        GameObject e = GameObject.Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 2.5F);
    }
}

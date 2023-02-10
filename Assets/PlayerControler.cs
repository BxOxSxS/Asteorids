using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Rigidbody rb;
    Vector2 input;

    public float enginePower = 20;

    public float gyroPower = 2;

    private CameraScript cs;

    public GameObject bulletPrefab;
    public Transform gunLeft, gunRight;
    public float bulletSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cs = Camera.main.transform.GetComponent<CameraScript>();
        input = Vector2.zero;

        gunLeft = transform.Find("GunLeft").transform;
        gunRight = transform.Find("GunRight").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        input.x = x;
        input.y = y;

        if(Mathf.Abs(transform.position.x) > cs.gameWidth /2)
        {
            Vector3 newPosition = transform.position = new Vector3 (transform.position.x * -0.99f, 0, transform.position.z);

            transform.position = newPosition;
        }
        if (Mathf.Abs(transform.position.z) > cs.gameHeight / 2)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z * -0.99f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * input.y * enginePower, ForceMode.Acceleration);
        rb.AddTorque(transform.up * input.x * gyroPower, ForceMode.Acceleration);
    }

    void Fire()
    {
        GameObject leftBullet = Instantiate(bulletPrefab, gunLeft.position, Quaternion.identity);

        leftBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
        
        Destroy(leftBullet, 5);

        GameObject rightBullet = Instantiate(bulletPrefab, gunRight.position, Quaternion.identity);

        rightBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);

        Destroy(rightBullet, 5);
    }
}

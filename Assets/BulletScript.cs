using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletScript : MonoBehaviour
{
    public GameObject player;

    public AudioClip destorySound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.CompareTag("Enemy")) {
            audioSource.PlayOneShot(destorySound, 2F);
            Destroy(target);

            player.GetComponent<PlayerControler>().Hit();
        }
    }
}

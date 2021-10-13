using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject controller;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (audio == null)
            audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.GetComponent<Scorekeeper>().AddPoints();

        //don't do it this way -- clumsy though it works
       /* audio.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 1); //destroys game object with a delay of 1 sec*/


        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        Destroy(gameObject); //destroys itself after points have been added 
    }
}

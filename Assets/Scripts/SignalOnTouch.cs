using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class SignalOnTouch : MonoBehaviour {

    public UnityEvent onTouch;

    public bool playAudioOnTouch = true;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Damage");
        SendSignal(collider.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Damage1");
        SendSignal(collision.gameObject);
    }

    void SendSignal(GameObject objectThatHit)
    {
        
        if (objectThatHit.CompareTag("Player"))
        {
            
            if (playAudioOnTouch) { 
                var audio = GetComponent<AudioSource>();
                if (audio && audio.gameObject.activeInHierarchy)
                    audio.Play();
            }
            onTouch.Invoke();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

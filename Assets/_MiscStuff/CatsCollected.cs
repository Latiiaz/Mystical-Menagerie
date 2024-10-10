using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsCollected : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Cat Collected");
            //Insert particles to avoid making it look like cat died.
            PlaySound(); //Cooldown for cat meow
            
            //Destroy(gameObject);
        }

    }
    public void PlaySound()
    {
        // Play the sound effect using PlayOneShot
        audioSource.PlayOneShot(soundEffect);
    }
}

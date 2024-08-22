using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip soundEffect;

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

    public void LoadNextScene(string sceneName)
    {
        ButtonClickSound();
        StartCoroutine(CooldownBeforeSwitchingScenes());
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(soundEffect);
    }


    IEnumerator CooldownBeforeSwitchingScenes()
    {
        yield return new WaitForSeconds(1);
    }
}

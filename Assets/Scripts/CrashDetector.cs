using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float secondsBeforeReloadOnCrash = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSoundEffect;

    private Collider2D circleCollider;

    private bool crashed = false;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !crashed) {
            crashed = true;

            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSoundEffect);
            Invoke("ReloadScene", secondsBeforeReloadOnCrash);

            FindObjectOfType<PlayerController>().DisableControl();
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float secondsBeforeReloadOnFisish = 1f;
    [SerializeField] ParticleSystem finishEffect;

    private bool finished = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !finished) {
            finished = true;
            finishEffect.Play();
            Invoke("ReloadScene", secondsBeforeReloadOnFisish);
            GetComponent<AudioSource>().Play();
            GetComponent<PlayerController>().DisableControl();
        }
    }
    
    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}

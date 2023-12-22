using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGlideEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem snowGlideEffect;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            snowGlideEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            snowGlideEffect.Stop();
        }
    }
}

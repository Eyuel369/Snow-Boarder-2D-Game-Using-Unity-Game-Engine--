using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Ground" && !hasCrashed){
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke( "LoadScene",delay);
        }
   }
   
   void LoadScene(){
 SceneManager.LoadScene(0); 
    }
}

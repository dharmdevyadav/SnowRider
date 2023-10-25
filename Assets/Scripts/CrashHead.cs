using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashHead : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] ParticleSystem Crasheffect;
    [SerializeField] ParticleSystem BoardEffect;
    [SerializeField] AudioClip CrashSFX;
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            FindObjectOfType<Player>().DisableControl() ;
            Crasheffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashSFX);
            Debug.Log("My head Bumped...");
            Invoke("ReloadScene1", delay);
;        }
    }
    void ReloadScene1()
    {
        SceneManager.LoadScene(0);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        
            BoardEffect.Play();
        if (c.gameObject.tag == "Break")
        {
            Crasheffect.Play();
            Invoke("ReloadScene1", delay);
        }
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag != "Break")
        {
            BoardEffect.Stop();
        }
    }
}

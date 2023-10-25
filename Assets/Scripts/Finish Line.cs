
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float Delay = 3f;
    [SerializeField] ParticleSystem finisheffect;
    bool hasCrash = false;
    // [SerializeField] ParticleSystem Crasheffect; 
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player" && !hasCrash)
        {
            hasCrash = true;
            finisheffect.Play();
            //Crasheffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", Delay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

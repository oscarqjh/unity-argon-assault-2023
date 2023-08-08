using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  private Controls control_script;
  private bool isTransitioning = false;
  private AudioSource audioSource;
  [SerializeField] private float delay = 1f;
  [SerializeField] private ParticleSystem crashParticle;
  [SerializeField] private AudioClip crash;
  // Start is called before the first frame update
  void Start()
  {
    control_script = GetComponent<Controls>();
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    if (isTransitioning)
    {
      return;
    }

    Debug.Log(this.name + "collided with " + other.gameObject.name);
    OnCrashSequence();

  }

  private void OnCrashSequence()
  {
    isTransitioning = true;
    control_script.enabled = false;
    crashParticle.Play();
    audioSource.PlayOneShot(crash);
    Invoke("ReloadScene", delay);
  }

  private void ReloadScene()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
    control_script.enabled = true;
  }
}

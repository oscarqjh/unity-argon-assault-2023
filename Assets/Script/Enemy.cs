using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private GameObject deathFX;
  [SerializeField] private GameObject hitVFX;
  [SerializeField] private int killValue = 200;
  [SerializeField] private int hitPoint = 10;

  ScoreBoard scoreBoard;
  GameObject parentGameObject;
  // Start is called before the first frame update
  void Start()
  {
    scoreBoard = FindObjectOfType<ScoreBoard>();
    parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    AddRigidbody();
  }

  private void AddRigidbody()
  {
    Rigidbody rb = gameObject.AddComponent<Rigidbody>();
    rb.useGravity = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnParticleCollision(GameObject other)
  {
    ProcessHit();
    if (hitPoint <= 0)
    {
      KillObject();
    }

  }

  private void ProcessHit()
  {
    GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
    vfx.transform.parent = parentGameObject.transform;
    hitPoint -= 1;
    scoreBoard.UpdateScore(killValue);
    // Debug.Log(hitPoint);
  }


  private void KillObject()
  {
    GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
    fx.transform.parent = parentGameObject.transform;

    Destroy(gameObject);
  }
}

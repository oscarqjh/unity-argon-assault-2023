using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
  [SerializeField] private float timeToSelfDestruct = 2f;
  // Start is called before the first frame update
  void Start()
  {
    Destroy(gameObject, timeToSelfDestruct);
  }

  // Update is called once per frame
  void Update()
  {

  }
}

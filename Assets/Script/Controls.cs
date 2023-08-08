using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
  [SerializeField] private float controlSpeed = 10f;
  [SerializeField] private float angleScaleZ = 10f;
  [SerializeField] private float angleScaleX = 10f;
  [SerializeField] private float angleScaleY = 10f;
  [SerializeField] private GameObject[] lasers;
  [SerializeField] private AudioClip laserSound;
  private AudioSource audioSource;

  // Start is called before the first frame update
  void Start()
  {
    audioSource = GetComponent<AudioSource>();

  }

  // Update is called once per frame
  void Update()
  {
    HorizontalControl();
    VerticalControl();
    FiringControl();
    quitApplication();
  }

  void quitApplication()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
  }

  void FiringControl()
  {
    if (Input.GetButton("Fire1"))
    {
      ActivateLasers(true);
      PlayLaserSound(true);
    }
    else
    {
      ActivateLasers(false);
      PlayLaserSound(false);
    }
  }

  void ActivateLasers(bool isActive)
  {
    foreach (GameObject laser in lasers)
    {
      var emissionModule = laser.GetComponent<ParticleSystem>().emission;
      emissionModule.enabled = isActive;
    }
  }

  void PlayLaserSound(bool isShooting)
  {
    if (isShooting && !audioSource.isPlaying)
    {
      audioSource.PlayOneShot(laserSound);
    }
    else if (!isShooting)
    {
      audioSource.Stop();
    }
  }

  void HorizontalControl()
  {
    // x axis
    float horizontalThrow = Input.GetAxis("Horizontal");
    float newXPos = transform.localPosition.x + horizontalThrow * Time.deltaTime * controlSpeed;

    float minX = -28f;
    float maxX = 28f;
    newXPos = Mathf.Clamp(newXPos, minX, maxX);
    // Debug.Log(normalisedX);

    transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);

    // rotation z
    float normalisedX = (newXPos - (minX)) / (maxX - (minX)) * 2 - 1;
    float newZRotation = angleScaleZ * horizontalThrow;
    // rotation y
    float newYRotation = normalisedX * angleScaleY;

    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newYRotation, newZRotation);
  }

  void VerticalControl()
  {
    // y axis
    float verticalThrow = Input.GetAxis("Vertical");
    float newYPos = transform.localPosition.y + verticalThrow * Time.deltaTime * controlSpeed;

    float minY = -9;
    float maxY = 20;
    newYPos = Mathf.Clamp(newYPos, minY, maxY);
    // Debug.Log(transform.localPosition.y);

    transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);

    // rotation x
    float normaliseY = (newYPos - (minY)) / (maxY - minY) * 2 - 1;
    float newXRotation = angleScaleX * verticalThrow;
    transform.localEulerAngles = new Vector3(newXRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
    // Debug.Log(transform.localEulerAngles);
  }
}

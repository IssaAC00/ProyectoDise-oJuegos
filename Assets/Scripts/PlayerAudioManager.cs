using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
  [SerializeField]
  private AudioClip jumpSound;

  [SerializeField]
  private AudioClip shootSound;
  [SerializeField]
  private AudioClip collectSound;

  private AudioSource audioSource;
  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }

  public void PlayJumpSound()
  {
    audioSource.PlayOneShot(jumpSound);
  }

  public void PlayShootSound()
  {
    audioSource.PlayOneShot(shootSound);
  }

  public void PlayCollectSound()
  {
    audioSource.PlayOneShot(collectSound);
  }
}

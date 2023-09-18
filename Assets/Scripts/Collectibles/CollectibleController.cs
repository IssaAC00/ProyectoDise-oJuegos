using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    private PlayerAudioManager pam;
    public int collectibleCount;

    private void Awake()
    {
        pam = FindObjectOfType<PlayerAudioManager>();
    }

    public void AddCollectible()
    {
        pam.PlayCollectSound();
        collectibleCount++;
    }
}

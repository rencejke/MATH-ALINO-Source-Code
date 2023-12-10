// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(AudioSource))]
// public class SoundEffectsListener : MonoBehaviour
// {
//     public static SoundEffectsListener Instance { get; private set; }

//     private AudioSource audioSource;

//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             audioSource = GetComponent<AudioSource>();
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     public void PlaySound(AudioClip sound)
//     {
//         audioSource.PlayOneShot(sound);
//     }
// }

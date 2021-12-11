using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public class AudioPlayerManager: MonoBehaviour
{
      private static AudioPlayerManager instance = null;
      public static AudioSource audio;

      private void Awake()
      {
          if (instance == null)
          { 
               instance = this;
               DontDestroyOnLoad(gameObject);
               return;
          }
          if (instance == this) return; 
          Destroy(gameObject);
      }

      void Start()
      {
         audio = GetComponent<AudioSource>();
         audio.Play();
      }
}
}

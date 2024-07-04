using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour

{
    //public AudioSource AudioSource;

    //private float musicVolume = 1f;

    public static GameObject instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this.gameObject;

            DontDestroyOnLoad(this.gameObject); //don't destroy audio object when loading next scene
        }
        else if (instance != null)
        {
            Destroy(this.gameObject); //destroy audio object if there is more than one in the scene
        }

    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    AudioSource.Play();
    //}

    //void Update()
    //{
    //    AudioSource.volume = musicVolume;
    //}

    //public void updateVolume (float volume)
    //{
    //    musicVolume = volume;
    //}


}

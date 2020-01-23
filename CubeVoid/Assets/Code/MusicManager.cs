using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Slider volume;
    public GameObject system;
    private AudioSource masterAudio;

    // Start is called before the first frame update
    void Start()
    {
        masterAudio = system.GetComponent<AudioSource>();
        volume.value = masterAudio.volume;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Volume", volume.value);
        masterAudio.volume = volume.value;
    }
}

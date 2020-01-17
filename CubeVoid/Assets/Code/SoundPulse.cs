using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPulse : MonoBehaviour
{
    public GameObject gameSystem;
    private AudioSource audioSource;

    private float[] samples;
    private float rms; //root mean squared (the sound level)
    private int totalSamples = 1024;

    private float originalY = 0;
    private float originalX = 0;

    [SerializeField]
    private float scaleVariation = 1.0f;

    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameSystem.GetComponent<AudioSource>();
        samples = new float[totalSamples];
        originalY = transform.localScale.y;
        originalX = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        AnalyzeSound();
        scale = transform.localScale;

        scale.y = originalY + scaleVariation * rms;
        scale.x = originalX + scaleVariation * rms;

        /*
        if (rms > 0.15)
        {
            scale.y = originalY + scaleVariation * rms;
            scale.x = originalX + scaleVariation * rms;
        }
        else
        {
            scale.y = originalY;
            scale.x = originalX;
        }
        */

        transform.localScale = scale;
    }

    private void AnalyzeSound()
    {
        audioSource.GetOutputData(samples, 0); //we get some samples 

        float sum = 0;

        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i]; //sum squared samples
        }

        //formula for sound level
        rms = Mathf.Sqrt(sum / totalSamples);
    }
}

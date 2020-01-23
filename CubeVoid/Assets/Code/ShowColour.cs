using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowColour : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    private Image colour;

    // Start is called before the first frame update
    void Start()
    {
        colour = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        byte red = (byte)redSlider.value;
        byte green = (byte)greenSlider.value;
        byte blue = (byte)blueSlider.value;

        colour.color = new Color32(red, green, blue, 255);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class RGBSlider : MonoBehaviour
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

    // When you create a new colour add it to log of colours
    public void AddColour()
    {
        string path = "Assets/Resources/UnlockedColours.txt";

        int red = (int)redSlider.value;
        int green = (int)greenSlider.value;
        int blue = (int)blueSlider.value;

        string colourToAdd = ("(" + (byte)red + ", " + (byte)green + ", " + (byte)blue + ")");
        bool alreadyInFile = false;

        // Check colour is not already in file
        StreamReader sr = new StreamReader(path);

        while (!sr.EndOfStream)
        {
            if (sr.ReadLine() == colourToAdd)
            {
                alreadyInFile = true;
            }
            
        }

        sr.Close();

        // If not in file add to file
        if (!alreadyInFile)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(
                    "(" + (byte)red +
                    ", " + (byte)green +
                    ", " + (byte)blue + ")");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ColourPicker : MonoBehaviour
{
    private Image display;

    public Material solid;
    public Material cracked;
    public Material disappearing;
    public Material appearing;

    private string[] RGBAcolours = new string[0];
    private int totalColours = 0;
    private int currentColour = 0;

    private bool fromSliders = false;

    private void Awake()
    {
        ObtainColours();
        display = GetComponent<Image>();

        display.color = new Color32(1, 0, 0, 1);
        UpdateDisplay();
    }

    public void NextColour ()
    {
        Debug.Log("next");
        Debug.Log("before " + currentColour);

        currentColour += 1;
        if (currentColour > totalColours - 1)
        {
            currentColour = 0;
        }

        UpdateDisplay();
    }

    public void PrevColour()
    {
        Debug.Log("prev");
        currentColour -= 1;
        if (currentColour < 0)
        {
            currentColour = totalColours - 1;
        }

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        display.color = FindColour();
    }

    //correct and working
    public void SetColour()
    {
        Color currentColour;

        if (fromSliders == true)
        {
            currentColour = GameObject.FindGameObjectWithTag("Colour").GetComponent<Image>().color;
            fromSliders = false;
        }
        else
        {
            currentColour = FindColour();
        }

        solid.color = currentColour;
        cracked.color = currentColour;
        disappearing.color = currentColour;

        appearing.color = new Color32(System.Convert.ToByte(currentColour.r),
            System.Convert.ToByte(currentColour.g), 
            System.Convert.ToByte(currentColour.b), 
            0);
    }

    public void SetColourFromSliders()
    {
        fromSliders = true;
        SetColour();
    }

    // correct and working
    private void ObtainColours()
    {
        string path = "Assets/Resources/UnlockedColours.txt";
        StreamReader sr = new StreamReader(path);

        while(!sr.EndOfStream)
        {
            totalColours += 1;
            System.Array.Resize(ref RGBAcolours, totalColours);
            RGBAcolours[totalColours - 1] = sr.ReadLine();
        }

        sr.Close();

        for (int i = 0; i < RGBAcolours.Length; i++)
        {
            Debug.Log(RGBAcolours[i]);
        }
    }

    public Color FindColour()
    {
        string toFind = RGBAcolours[currentColour];
        string[] numbers = new string[3];

        int x = 0;
        for (int i = 0; i < toFind.Length; i++)
        {
            if (toFind[i] == System.Convert.ToChar(","))
            {
                x += 1;
            }
            else if (toFind[i] == System.Convert.ToChar("(") || toFind[i] == System.Convert.ToChar(")") || toFind[i] == System.Convert.ToChar(" ")) { }
            else
            {
                numbers[x] += toFind[i];
            }
        }

        byte red = System.Convert.ToByte(numbers[0]);
        byte green = System.Convert.ToByte(numbers[1]);
        byte blue = System.Convert.ToByte(numbers[2]);
        byte alpha = 255;


        return new Color32(red, green, blue, alpha);
    }
}

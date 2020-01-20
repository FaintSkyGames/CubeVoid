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

    //public Material test;

    private void Awake()
    {
        ObtainColours();
        display = GetComponent<Image>();

        display.color = new Color(1, 0, 0, 1);
        UpdateDisplay();
    }

    public void NextColour ()
    {
        Debug.Log("next");
        Debug.Log("before " + currentColour);

        currentColour += 1;
        Debug.Log("after " + currentColour);
        if (currentColour > totalColours - 1)
        {
            currentColour = 0;
        }
        Debug.Log("check " + currentColour);

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
        Debug.Log("update");
        display.color = FindColour();
    }

    //correct and working
    public void SetColour()
    {
        solid.color = FindColour();
        cracked.color = FindColour();
        disappearing.color = FindColour();
        appearing.color = FindColour();
        //spriteRenderer.color = GetColorFromString("23339a");  //
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

        /*
        Debug.Log("before "+ numbers[0]);
        Debug.Log("before " + numbers[1]);
        Debug.Log("before " + numbers[2]);
        */

        float red = System.Convert.ToInt32(numbers[0]);
        float green = System.Convert.ToInt32(numbers[1]);
        float blue = System.Convert.ToInt32(numbers[2]);
        float alpha = 1f;

        /*
        Debug.Log("after " + red);
        Debug.Log("after " + green);
        Debug.Log("after " + blue);
        */

        return new Color(red, green, blue, alpha);
    }



    /* 1st attempt
     * 
     *     [SerializeField] private GameObject spriteGameObject;
    SpriteRenderer spriteRenderer;
    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 32); //
        return dec;
    }

    private string DecToHex(int dec)
    {
        return dec.ToString("X2");
    }

    private string FloatToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }
    private float HexToFloat(string hex)
    {
        return HexToDec(hex) / 255f;  //
    }

    private Color GetColorFromString(string hexString)
    {
        float red = HexToFloat(hexString.Substring(0, 2));
        float green = HexToFloat(hexString.Substring(2, 2));
        float blue = HexToFloat(hexString.Substring(4, 2));  //
        float alpha = 1f;

        if (hexString.Length >= 8)
        {
            alpha = HexToFloat(hexString.Substring(6, 2));
        }

        return new Color(red, green, blue, alpha);
    }

    */
}

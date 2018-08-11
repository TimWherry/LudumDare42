using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eKittyTrait
{
    None = -1,
    Biter = 0,
    Scratcher = 1,
    Zoomer = 2,
    Lap = 3,
    Max = 4,
}

public enum eKittyColors
{
    Tan = 0,
    Brown = 1,
    Orange = 2,
    Yellow = 3,
    White = 4,
    Max = 5,
}

public class KittyEnums
{
    public static Color GetColor(eKittyColors color)
    {
        Color retVal = Color.white;

        switch (color)
        {
            case eKittyColors.Tan:
                retVal = new Color(1.0f, 0.7f, 0.5f);
                break;
            case eKittyColors.Brown:
                retVal = new Color(0.66f, 0.26f, 0.0f);
                break;
            case eKittyColors.Orange:
                retVal = new Color(1.0f, 0.4f, 0.0f);
                break;
            case eKittyColors.Yellow:
                retVal = Color.yellow;
                break;
            case eKittyColors.White:
                retVal = Color.white;
                break;
        }
        return retVal;
    }

    public static eKittyColors GetRandomColor()
    {
        return (eKittyColors)Random.Range(0, (int)eKittyColors.Max);
    }

    public static eKittyTrait GetRandomTrait(eKittyTrait invalidOption)
    {
        eKittyTrait retVal = eKittyTrait.None;
        int count = 0;
        do
        {
            int random = Random.Range(0, (int)eKittyTrait.Max);
            retVal = (eKittyTrait)random;
        } while (retVal.Equals(invalidOption));

        return retVal;
    }
}
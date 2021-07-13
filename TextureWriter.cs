using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureWriter
{
    public static void WriteArrayToDisk_AsTexture(float[,] arr, string pathInResourcesFolder)
    {
        WriteTextureToDisk(WriteArrayToTexture(arr), pathInResourcesFolder);

    }

    public static Texture2D WriteArrayToTexture(float[,] arr)
    {
        Texture2D tex = new Texture2D(arr.GetLength(0), arr.GetLength(1));

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                tex.SetPixel(i, j, new Color(arr[i, j], 0f, 0f));


            }
        }

        tex.Apply();

        return tex;
    }

    public static void WriteArrayToDisk_AsTexture(Vector3[,] arr, string pathInResourcesFolder)
    {
        WriteTextureToDisk(WriteArrayToTexture(arr), pathInResourcesFolder);

    }

    public static Texture2D WriteArrayToTexture(Vector3[,] arr)
    {
        Texture2D tex = new Texture2D(arr.GetLength(0), arr.GetLength(1));

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                tex.SetPixel(i, j, new Color(arr[i, j].x, arr[i, j].y, arr[i, j].z));

            }
        }

        tex.Apply();

        return tex;
    }


    public static void WriteTextureToDisk(Texture2D texture, string pathInResourcesFolder)
    {
        File.WriteAllBytes("Assets/Resources/" + pathInResourcesFolder + ".png", texture.EncodeToPNG());

    }

}

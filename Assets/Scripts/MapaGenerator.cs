using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        // Crear una textura para almacenar el mapa generado
        Texture2D texture = new Texture2D(width, height);

        // Generar el mapa utilizando el ruido de Perlin
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                Color color = new Color(sample, sample, sample);
                texture.SetPixel(x, y, color);
            }
        }

        // Aplicar los cambios y asignar la textura al material de algún objeto en tu escena
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}

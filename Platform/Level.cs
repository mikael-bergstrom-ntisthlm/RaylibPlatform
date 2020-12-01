using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Platform
{
  public class Level
  {
    public static Dictionary<string, Level> levels = new Dictionary<string, Level>();

    string name;

    int[,] levelData = {
      {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0},
      {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    };

    Image levelImage;
    Texture2D levelTexture;
    int blockSize = 32;


    public Level(string name)
    {
      this.name = name;
      levels.Add(name, this);

      levelImage = Raylib.GenImageColor(
        levelData.GetLength(1) * blockSize,
        levelData.GetLength(0) * blockSize,
        Color.WHITE);

      for (int y = 0; y < levelData.GetLength(0); y++)
      {
        for (int x = 0; x < levelData.GetLength(1); x++)
        {
          if (levelData[y, x] == 1)
          {
            Raylib.ImageDrawRectangle(ref levelImage, x * blockSize, y * blockSize, blockSize, blockSize, Color.BLACK);
          }
        }
      }
      levelTexture = Raylib.LoadTextureFromImage(levelImage);
    }

    public void Draw()
    {
      Raylib.DrawTexture(levelTexture, 0, 0, Color.WHITE);
    }
  }
}

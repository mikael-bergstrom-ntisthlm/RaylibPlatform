using System;
using System.Numerics;
using Raylib_cs;

namespace Platform
{
  public class Widgets
  {
    public static void DrawPlus(int x, int y, int size, Color color)
    {
      Raylib.DrawLine(x, y-size, x, y+size, color);
      Raylib.DrawLine(x-size, y, x+size, y, color);
    }

    public static void DrawPlus(Vector2 pos, int size, Color color)
    {
      DrawPlus((int) pos.X, (int) pos.Y, size, color);
    }
  }
}

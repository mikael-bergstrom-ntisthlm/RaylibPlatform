using System;
using Raylib_cs;

namespace Platform
{
  public class Ground : GameObject
  {
    public Ground(float x, float y, float width, float height)
    {
      rect.x = x;
      rect.y = y;
      rect.width = width;
      rect.height = height;
    }

    public override void Update()
    {
      
    }
  }
}

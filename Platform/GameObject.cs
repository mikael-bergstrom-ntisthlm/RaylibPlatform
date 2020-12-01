using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Platform
{
  public abstract class GameObject
  {
    public static List<GameObject> gameObjects = new List<GameObject>();

    public Rectangle rect = new Rectangle();

    public Color color = Color.BLACK;

    public abstract void Update();
    public virtual void Draw()
    {
      Raylib.DrawRectangleRec(rect, color);
    }

    public GameObject()
    {
      gameObjects.Add(this);
    }

  }
}

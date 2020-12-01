using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Platform
{
  class Program
  {
    static void Main(string[] args)
    {
      // https://2dengine.com/?p=platformers
      
      Raylib.InitWindow(800,600,"Platforming test");
      Raylib.SetTargetFPS(60);

      new Ground(0,500,800,20);

      new Ground(200,400,300,20);

      Player p = new Player();

      Level l = new Level("Level 1");

      List<Level> levels = new List<Level>();
      levels.Add(l);
      Level currentLevel = levels[0];


      while (!Raylib.WindowShouldClose())
      {
        p.Update();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.YELLOW);
        
        currentLevel.Draw();

        GameObject.gameObjects.ForEach(x => x.Draw());

        Raylib.EndDrawing();

      }
    }
  }
}

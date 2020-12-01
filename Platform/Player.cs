using System.Linq;
using System.Collections.Generic;
using System;
using System.Numerics;
using Raylib_cs;

namespace Platform
{
  public class Player : GameObject
  {

    public Vector2 velocity = new Vector2();
    public Vector2 position = new Vector2();
    public float gravityScale = 10;
    public float jumpForce = 400;
    public float walkSpeed = 30;

    private bool isGrounded = false;
    private bool hitHead = false;

    private Vector2[] feetCheckers;
    private Vector2[] headCheckers;
    private Vector2[] leftCheckers;
    private Vector2[] rightCheckers;



    public Player()
    {
      rect.width = 10;
      rect.height = 20;

      position = new Vector2(400 - rect.width / 2, 450);
      color = Color.DARKBLUE;

      feetCheckers = new Vector2[] {
        new Vector2(rect.width*0.2f,rect.height+1),
        new Vector2(rect.width*0.8f, rect.height+1)
      };

      headCheckers = new Vector2[] {
        new Vector2(rect.width/2, 0)
      };
    }

    public override void Update()
    {
      float deltaTime = Raylib.GetFrameTime();

      // Apply gravity to velocity
      velocity.Y += World.gravity * gravityScale * deltaTime;

      // Check ground collision
      GroundChecker();

      // Jumping
      JumpChecker();

      // Walking
      if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
      {
        position.X -= walkSpeed * deltaTime;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
      {
        position.X += walkSpeed * deltaTime;
      }

      // Apply velocity to position;
      position.Y += velocity.Y * deltaTime;

      // Update position of object rect
      UpdateRect();
    }

    public void UpdateRect()
    {
      rect.x = position.X;
      rect.y = position.Y;
    }

    public override void Draw()
    {
      base.Draw();

      Widgets.DrawPlus(feetCheckers[0] + new Vector2(rect.x, rect.y), 50, Color.GREEN);
      Widgets.DrawPlus(feetCheckers[1] + new Vector2(rect.x, rect.y), 50, Color.GREEN);
    }

    private void JumpChecker()
    {
      if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && isGrounded)
      {
        velocity.Y = -jumpForce;
      }
    }

    private void GroundChecker()
    {
      // Check if colliding with ground object

      // Very inefficient way of getting all ground objects
      List<GameObject> groundObjects = gameObjects.FindAll(x => x is Ground);

      isGrounded = false;
      foreach (GameObject groundObject in groundObjects)
      {
        // Check head
        foreach(Vector2 headChecker in headCheckers)
        {
          if (Raylib.CheckCollisionPointRec(headChecker + new Vector2(rect.x, rect.y), groundObject.rect))
          {
            velocity.Y = 0;
            Rectangle overlapRect = Raylib.GetCollisionRec(rect, groundObject.rect);
            position.Y += overlapRect.height+1;
            break;
          }
        }

        // Check feet
        foreach (Vector2 groundChecker in feetCheckers)
        {
          if (Raylib.CheckCollisionPointRec(groundChecker + new Vector2(rect.x, rect.y), groundObject.rect))
          {
            velocity.Y = 0;
            Rectangle overlapRect = Raylib.GetCollisionRec(rect, groundObject.rect);
            position.Y -= overlapRect.height;
            isGrounded = true;
            break;
          }
        }
      }
    }
  }
}

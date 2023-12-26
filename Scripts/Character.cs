using Godot;
using System;

public partial class Character : CharacterBody2D
{
	public const float Speed = 300.0f;


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		if (velocity.X > 0)
		{
			animatedSprite2D.Play("run_right");
		}
		else if (velocity.X < 0)
		{
			animatedSprite2D.Play("run_left");
		}
		else if (velocity.Y > 0)
		{
			animatedSprite2D.Play("run_down");
		}
		else if (velocity.Y < 0)
		{
			animatedSprite2D.Play("run_up");
		}
		else
		{
			animatedSprite2D.Stop();
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

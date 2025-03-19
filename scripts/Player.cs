using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 300.0f;

	public override void _PhysicsProcess(double delta){
		PlayerMovement(delta);
		MoveAndSlide();
	}

	private void PlayerMovement(double delta){
		Vector2 direction = Input.GetVector("left", "right", "up", "down");

		Velocity = direction * Speed;
	}
}

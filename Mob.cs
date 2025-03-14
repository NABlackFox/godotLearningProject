using System;
using Godot;

public partial class Mob : RigidBody2D{

	[Export]
	public int Speed = 400;
	private AnimatedSprite2D _animatedSprite2D;
	private string[] _mobTypes;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		// Get all the animations of the sprites
		_mobTypes = _animatedSprite2D.SpriteFrames.GetAnimationNames();

		// Play a random animations of the sprite, index range (0 - (n-1))
		_animatedSprite2D.Play(_mobTypes[GD.Randi() % _mobTypes.Length]);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
	}

	// OnScreenNotifer2DScreenExited signal
	private void OnVisibleOnScreenNotifier2DScreenExited(){

		// Delete the mob when leave the screen
		QueueFree();
	}
}

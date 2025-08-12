using Godot;
using System;
using System.Linq;

public partial class Enemy : CharacterBody2D
{
	[Export] public Vector2I startPosition;
	[Export] public Vector2I endPosition;
	[Export] public Node player;
	private bool movingToEnd = true;
	private float speed = 10.0f;
	private Area2D area2D;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = startPosition;
		area2D = GetNode<Area2D>("Area2D");
	}
	private void MoveTowards(double delta)
	{
		// Pick current target
		var target = movingToEnd ? endPosition : startPosition;

		// Move toward it
		Position = Position.MoveToward(target, speed * (float)delta);

		// Switch when close enough
		if (Position.DistanceTo(target) < 0.5f)
			movingToEnd = !movingToEnd;
	}

	public override void _Process(double delta)
	{
		MoveTowards(delta);
		if (area2D.GetOverlappingBodies().Contains(player))
		{
			GetTree().ReloadCurrentScene();
		}
	}
}

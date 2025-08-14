using Godot;
using System;
using System.Linq;

public partial class Enemy : CharacterBody2D
{
	[Export] public Vector2I startPosition;
	[Export] public Vector2I endPosition;
	private Player player;

	private bool movingToEnd = true;
	[Export] public float speed = 300.0f;
	private Area2D area2D;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = startPosition;
		area2D = GetNode<Area2D>("Area2D");
		player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as Player;
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
		if (area2D.GetOverlappingBodies().Contains(player) && !player.isShadow)
		{
			var sfx = player.deathSfx;
			sfx.Reparent(GetTree().Root);
			sfx.ProcessMode = ProcessModeEnum.Always;

			sfx.Finished += () => sfx.QueueFree();
			sfx.Play();

			GetTree().ReloadCurrentScene();
		}
	}
}

using Godot;
using System;
using System.Linq;

public partial class Coin : CharacterBody2D
{
	private CharacterBody2D player;
	private Area2D area2D;
	[Export] public string levelName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as CharacterBody2D;
		area2D = GetNode<Area2D>("Area2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (area2D.GetOverlappingBodies().Contains(player))
		{
			var levelManager = GetTree().Root.GetNode<Node2D>(levelName);
			levelManager?.Set("collectedCoins", (int)levelManager.Get("collectedCoins") + 1);
			QueueFree();
		}
	}
}

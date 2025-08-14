using Godot;
using System;
using System.Linq;

public partial class Coin : CharacterBody2D
{
	private Player player;
	private Area2D area2D;
	[Export] public string levelName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as Player;
		area2D = GetNode<Area2D>("Area2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (area2D.GetOverlappingBodies().Contains(player) && player.isShadow == false)
		{
			var lm = GetTree().CurrentScene as LevelManager;
			player.coinsSfx.Play();
			var levelManager = GetTree().Root.GetNode<LevelManager>(levelName);
			levelManager?.Set("collectedCoins", (int)levelManager.Get("collectedCoins") + 1);
			lm?.OpenClose();
			QueueFree();
		}
	}

}

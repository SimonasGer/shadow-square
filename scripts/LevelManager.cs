using Godot;
using System;

public partial class LevelManager : Node2D
{
	private int coinCount = 0, collectedCoins = 0, switchCount = 0, switchedSwitches = 0;
	[Export] public CharacterBody2D player;
	[Export] public string nextScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (player == null) return;

		coinCount = GetTree().GetNodesInGroup("Coins").Count;
		switchCount = GetTree().GetNodesInGroup("Switches").Count;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (collectedCoins == coinCount && switchedSwitches == switchCount)
		{

		}
	}
}

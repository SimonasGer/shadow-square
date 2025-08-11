using Godot;
using System;

public partial class LevelManager : Node2D
{
	private int CoinCount = 0, CollectedCoins = 0, SwitchCount = 0, SwitchedSwitches = 0;
	[Export] public CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (player == null) return;

		CoinCount = GetTree().GetNodesInGroup("Coins").Count;
    	SwitchCount = GetTree().GetNodesInGroup("Switches").Count;
		
		GD.Print($"Coins: {CoinCount}, Swiches: {SwitchCount}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}

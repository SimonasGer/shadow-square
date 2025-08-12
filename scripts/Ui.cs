using Godot;
using System;

public partial class Ui : CanvasGroup
{
	[Export] public Label label;
	[Export] public string levelName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (label == null) return;

		var levelManager = GetTree().Root.GetNode<Node2D>(levelName);

		label.Text = $"Coins: {levelManager.Get("collectedCoins")}/{levelManager.Get("coinCount")}\nSwitches: {levelManager.Get("allSwitchedSwitches")}/{levelManager.Get("switchCount")}";
	}
}

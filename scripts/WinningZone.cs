using Godot;
using System;
using System.Linq;

public partial class WinningZone : Area2D
{
	private CharacterBody2D player;
	[Export] public string nextLevelName;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as CharacterBody2D;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GetOverlappingBodies().Contains(player))
		{
			GetTree().ChangeSceneToFile($"res://levels/{nextLevelName}.tscn");
		}
	}
}

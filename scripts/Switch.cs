using Godot;
using System;
using System.Linq;

public partial class Switch : CharacterBody2D
{
	private CharacterBody2D player;
	private Area2D area2D;
	private Sprite2D sprite;
	[Export] public string levelName = "Level1";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as CharacterBody2D;
		area2D = GetNode<Area2D>("Area2D");
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (area2D.GetOverlappingBodies().Contains(player))
		{
			if (Input.IsActionJustPressed("interact"))
			{
				var levelManager = GetTree().Root.GetNode<Node2D>(levelName);
				levelManager?.Set("switchedSwitches", (int)levelManager.Get("switchedSwitches") + 1);
				sprite.Texture = GD.Load<Texture2D>("res://sprites/SwitchOn.png");
			}
		}
	}
}

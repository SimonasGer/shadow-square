using Godot;
using System;
using System.Linq;

public partial class Switch : CharacterBody2D
{
	private CharacterBody2D player;
	private Area2D area2D;
	private Sprite2D sprite;
	public bool isOn = false;
	[Export] public string levelName = "Level1";
	[Export] public bool real = true;
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
			var lm = GetTree().CurrentScene as LevelManager;
			var levelManager = GetTree().Root.GetNode<Node2D>(levelName);
			if (Input.IsActionJustPressed("interact") && !isOn)
			{
				isOn = true;
				sprite.Texture = GD.Load<Texture2D>("res://sprites/SwitchOn.png");

				if (real)
				{
					levelManager?.Set("realSwitchedSwitches", (int)levelManager.Get("realSwitchedSwitches") + 1);
					levelManager?.Set("allSwitchedSwitches", (int)levelManager.Get("allSwitchedSwitches") + 1);
				}
				else
				{
					levelManager?.Set("allSwitchedSwitches", (int)levelManager.Get("allSwitchedSwitches") + 1);
				}
				lm?.OpenClose();
			}
			else if (Input.IsActionJustPressed("interact") && isOn)
			{
				isOn = false;
				sprite.Texture = GD.Load<Texture2D>("res://sprites/SwitchOff.png");
				if (real)
				{
					levelManager?.Set("realSwitchedSwitches", (int)levelManager.Get("realSwitchedSwitches") - 1);
					levelManager?.Set("allSwitchedSwitches", (int)levelManager.Get("allSwitchedSwitches") - 1);
				}
				else
				{
					levelManager?.Set("allSwitchedSwitches", (int)levelManager.Get("allSwitchedSwitches") - 1);
				}
				lm?.OpenClose();
			}
		}
	}
}

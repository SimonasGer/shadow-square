using Godot;
using System;
using System.Linq;

public partial class ShadowBar : HSlider
{
	private CharacterBody2D player;
	public override void _Ready()
	{
		player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as CharacterBody2D;
	}

	public override void _Process(double delta)
	{
		Value = (float)player.Get("shadowTime")/ (float)player.Get("shadowDuration");
	}   

}

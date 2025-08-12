using Godot;
using System;
using System.Linq;

public partial class LevelManager : Node2D
{
	private int coinCount = 0, collectedCoins = 0, switchCount = 0, allSwitchedSwitches = 0, realSwitchedSwitches = 0;
	[Export] public CharacterBody2D player;
	[Export] public Vector2I gateCords;
	[Export] public TileMapLayer walls;
	private int gate;
	private Vector2I gateAtlas;
	private int gateAlt;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (player == null) return;
		coinCount = GetTree().GetNodesInGroup("Coins").Count;
		switchCount = GetTree().GetNodesInGroup("Switches")
			.OfType<Switch>()
			.Where(s => s.real == true)
			.Count();
		gate = walls.GetCellSourceId(gateCords);
		gateAtlas = walls.GetCellAtlasCoords(gateCords);
		gateAlt = walls.GetCellAlternativeTile(gateCords);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void OpenClose()
	{
		if (collectedCoins == coinCount && allSwitchedSwitches == switchCount && realSwitchedSwitches == switchCount)
		{
			walls.SetCell(gateCords, -1);
		}
		else
		{
			walls.SetCell(gateCords, gate, gateAtlas, gateAlt);
		}
	}
}

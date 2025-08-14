using Godot;
using System;

public partial class Menu : CanvasGroup
{
	private Panel panel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
		GetTree().Paused = true;
		panel = GetNode<Panel>("Panel");
		var label = GetNode<Label>("Panel/Label");
		panel.Size = GetViewport().GetVisibleRect().Size;
		label.Position = panel.Size / 2 - label.Size / 2;
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("interact") && GetTree().Paused)
		{
			GetTree().Paused = false;
			panel.Visible = false;
			GetViewport().SetInputAsHandled();
		}
		else if (@event.IsActionPressed("pause") && !GetTree().Paused) //now just this doesnt work
		{
			panel.Visible = true;
			GetTree().Paused = true;
			GetViewport().SetInputAsHandled();
		}
		else if (@event.IsActionPressed("pause") && GetTree().Paused)
		{
			GetTree().Quit();
		}
	}
}

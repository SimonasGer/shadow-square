using Godot;

public partial class Player : CharacterBody2D
{
	[Export] public float speed = 220.0f;
	[Export] public float shadowDuration = 2.0f;
	[Export] public AudioStreamPlayer gateSfx, coinsSfx, switchSfx, shadowSfx, deathSfx;
	public bool isShadow = false;
	private bool cooldown = false;
	public float shadowTime = 0.0f;
	private Sprite2D sprite2D;

	public override void _Ready()
	{
		sprite2D = GetNode<Sprite2D>("Sprite2D");
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 dir = Vector2.Zero;

		if (Input.IsActionPressed("move_right")) dir.X += 1;
		if (Input.IsActionPressed("move_left")) dir.X -= 1;
		if (Input.IsActionPressed("move_down")) dir.Y += 1;
		if (Input.IsActionPressed("move_up")) dir.Y -= 1;

		if (Input.IsActionPressed("shadow") && shadowTime <= shadowDuration && !cooldown)
		{

			if (isShadow == false)
			{
				isShadow = true;
				shadowSfx.Play();
			}
			if (sprite2D.Texture == GD.Load<Texture2D>("res://sprites/PlayerSolid.png")) sprite2D.Texture = GD.Load<Texture2D>("res://sprites/PlayerShadow.png");
			shadowTime += (float)delta;
			GD.Print(shadowTime);

			if (shadowTime >= shadowDuration && !cooldown)
			{
				cooldown = true;
			}
		}
		else if (shadowTime >= 0.0f)
		{
			if (isShadow == true)
			{
				isShadow = false;
				shadowSfx.Play();
			}
			if (sprite2D.Texture == GD.Load<Texture2D>("res://sprites/PlayerShadow.png")) sprite2D.Texture = GD.Load<Texture2D>("res://sprites/PlayerSolid.png");
			shadowTime -= (float)delta;
			if (shadowTime <= 0.0f)
			{
				shadowTime = 0.0f;
				cooldown = false;
			}

		}
		Velocity = dir.Normalized() * speed;
		MoveAndSlide();
	}
}
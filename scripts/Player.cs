using Godot;
using System;

public partial class Player : Area2D, IHasScore
{
    [Export] private int moveSpeed = 200;
    public AudioStreamPlayer ScoreSound { get; set; }
    [Export] public Label ScoreDisplay { get; set; }
    public int Score { get; set; }

    public override void _Ready()
    {
        ScoreSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        var input = Input.GetActionStrength("ui_down") -  Input.GetActionStrength("ui_up");
        var position = Position;
        position += new Vector2(0, (float)(input * moveSpeed * delta));
        position.Y = Mathf.Clamp(position.Y, 16, GetViewportRect().Size.Y - 16);
        Position = position;
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            var direction = new Vector2(Vector2.Right.X, (float)Random.Shared.NextDouble() * 2  - 1).Normalized();
            ball.Bounce(direction);
        }
    }
}

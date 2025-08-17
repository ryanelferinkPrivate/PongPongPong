using Godot;

public partial class Ball : Area2D
{
    public double MoveSpeed = 500;
    [Export] public Vector2 Direction = Vector2.Left;

    private AudioStreamPlayer bounceSound;
    private static readonly Vector2 startingPoint = new() { X = 640, Y = 360 };

    public override void _Ready()
    {
        bounceSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        Position = Position with
        {
            X = (float)(Position.X + MoveSpeed * delta * Direction.X),
            Y = (float)(Position.Y + MoveSpeed * delta * Direction.Y)
        };
    }

    public void Reset(Vector2 direction)
    {
        Direction = direction;
        Position = startingPoint;
    }

    public void Bounce(Vector2 direction)
    {
        Direction = direction;
        bounceSound.Play();
    }
}
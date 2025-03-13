using Godot;

public partial class Player : Area2D{

    private AnimatedSprite2D _animatedSprite2D;

    [Export]
    public int Speed {get; set;} = 400;

    public Vector2 ScreenSize;

    // Ready method, load on game ready
    public override void _Ready(){

        // Get the screen size
        ScreenSize = GetViewportRect().Size;

        // Get the node on ready
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    // Process function, run every frame

    public override void _Process(double delta){
        Vector2 velocity = Vector2.Zero;

        // check fot input
        if (Input.IsActionPressed("move_right")){
            velocity.X += 1;
        }
        if (Input.IsActionPressed("move_left")){
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("move_up")){
            velocity.Y += 1;
        }
        if (Input.IsActionPressed("move_down")){
            velocity.Y -= 1;
        }

        if (velocity.Length() > 0){
            velocity = velocity.Normalized() * Speed;
            _animatedSprite2D.Play();
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );

        if (velocity.X != 0){
            _animatedSprite2D.Animation = "walk";
            _animatedSprite2D.FlipV = false;
            // See the note below about the following boolean assignment.
            _animatedSprite2D.FlipH = velocity.X < 0;
        } else if (velocity.Y != 0){
            _animatedSprite2D.Animation = "up";
            _animatedSprite2D.FlipV = velocity.Y > 0;
        }

        if (velocity.X < 0){
            _animatedSprite2D.FlipH = true;
        } else {
             _animatedSprite2D.FlipH = false;
        }
    }
}

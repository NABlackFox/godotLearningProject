using Godot;

public partial class Main : Node{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public PackedScene MobScene { get; set;}

	// Node
	private Timer _mobTimer;
	private Timer _scoreTimer;
	private Timer _startTimer;
	private Player _player;
	private Marker2D _startPosition;

	private int _score;
	public override void _Ready(){
		_mobTimer = GetNode<Timer>("MobTimer");
		_scoreTimer = GetNode<Timer>("ScoreTimer");
		_startTimer = GetNode<Timer>("StartTimer");
	}
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
	}

	
	// New game create
	public void NewGame(){
		// Reset the score
		_score = 0;

		_player = GetNode<Player>("Player");
		_startPosition = GetNode<Marker2D>("StartPosition");

		_startTimer.Start();
	}

	// Reciver of Hit event
	public void GameOver(){
		_mobTimer.Stop();
		_scoreTimer.Stop();
	}

	// Score Timer Event
	private void OnScoreTimerTimout(){
		_score++;
	}

	private void OnStartTimerTimOut(){
		_mobTimer.Start();
		_scoreTimer.Start();
	}

	private void OnMobTimerTimeOut(){
		// Create new mob
		Mob mob = MobScene.Instantiate<Mob>();

		// Get the spawn path
		PathFollow2D mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");

		// Choose a random location on the path
		mobSpawnLocation.ProgressRatio = GD.Randf();

		// Spawn a mob to that location perpendicular to the path direction
		float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;
	}
}

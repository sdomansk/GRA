using Godot;
using System;

public class Player : Area2D
{
    [Export]
    public int Speed = 0; // How fast the player will move (pixels/sec).

    private Vector2 _screenSize; // Size of the game window.
	public override void _Ready()
	{
    	_screenSize = GetViewport().GetSize();
	}
	
	public override void _Process(float delta)
	{
    	var velocity = new Vector2(); // The player's movement vector.
	    if (Input.IsActionPressed("ui_right")) {
        velocity.x += 1;
    	}

    	if (Input.IsActionPressed("ui_left")) {
        velocity.x -= 1;
	    }

    	if (Input.IsActionPressed("ui_down")) {
        velocity.y += 1;
    	}

    	if (Input.IsActionPressed("ui_up")) {
        velocity.y -= 1;
    	}

    	var animatedSprite = (AnimatedSprite) GetNode("AnimatedSprite");
    	if (velocity.Length() > 0) {
        	velocity = velocity.Normalized() * Speed;
        	animatedSprite.Play();
    	}else {
        animatedSprite.Stop();
    	}
		
		Position += velocity * delta;
		Position = new Vector2(
    	Mathf.Clamp(Position.x, 0, _screenSize.x),
    	Mathf.Clamp(Position.y, 0, _screenSize.y)
);
	}
}

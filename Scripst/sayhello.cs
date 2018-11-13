using Godot;
using System;

// IMPORTANT: the name of the class MUST match the filename exactly.
// this is case sensitive!
public class sayhello : Panel
{
    public override void _Ready()
    {
        GetNode("Button").Connect("pressed", this, nameof(_OnButtonPressed));
    }

    public void _OnButtonPressed()
    {
		var enemies = GetTree().GetNodesInGroup("Enemies");
		foreach(var node in enemies)
		{
      var scene = (PackedScene)ResourceLoader.Load("res://Scens//Hellow.tscn");
	var node2=scene.Instance();
AddChild(node2);
		}
    }
}

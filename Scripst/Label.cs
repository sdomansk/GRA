using Godot;
using System;

public class Label : Godot.Label
{
    private float _accum;

    public override void _Process(float delta)
    {
        _accum += delta;
        Text = _accum.ToString(); // 'Text' is a built-in label property.
    }
}

using Godot;
using System;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public partial class SceneNodeAttribute : Attribute
{
    public string NodePath { get; }

    public SceneNodeAttribute(string nodePath)
    {
        NodePath = nodePath;
    }
}

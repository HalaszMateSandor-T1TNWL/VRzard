using Godot;
using System;
using System.Runtime;

public static class SceneNodeResolver
{
    public static void Resolve(Node target)
    {
        var fields = target.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        foreach (var field in fields)
        {
            var attrib = Attribute.GetCustomAttribute(field, typeof(SceneNodeAttribute));

            if (attrib is SceneNodeAttribute attribute)
            {
                var nodePath = attribute.NodePath;
                var nodeType = field.FieldType;

                var node = target.GetNode(nodePath);

                field.SetValue(target, node);
            }
        }

    }
}

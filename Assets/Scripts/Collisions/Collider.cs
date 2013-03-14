using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

abstract public class Collider
{
    // C# equivalent of a union for holding 
    // collider properties
    [StructLayout(LayoutKind.Explicit)]
    public struct Data
    {
        // CircleCollider
        [FieldOffset(0)]
        public float Radius;

        // RectangleCollider
        [FieldOffset(0)]
        public float Width;
        [FieldOffset(4)]
        public float Height;
    }

    public Data Properties;

	public abstract bool CollidesWith (GameObject o2);
}

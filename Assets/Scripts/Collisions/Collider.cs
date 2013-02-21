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
        [FieldOffset(0)]
        public float Radius; // CircleCollider

        // As an example, if we had a SquareCollider, 
        // its properties would go after Radius like this:
        // [FieldOffset(0)]
        // public float Width;
        // [FieldOffset(4)]
        // public float Height;
    }

    public Data Properties;

	public abstract bool CollidesWith (GameObject o2);
}

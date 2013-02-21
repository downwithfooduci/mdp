using System.Collections.Generic;
using UnityEngine;

public class ColorComparer : IEqualityComparer<Color> 
{
	public bool Equals(Color c1, Color c2)
    {
        return 
            (c1.r == c2.r) &&
            (c1.g == c2.g) &&
            (c1.b == c2.b);
    }

    public int GetHashCode(Color obj)
    {
        return obj.GetHashCode();
    }
}

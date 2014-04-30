// MDPEntity must be attached onto all game objects
// This class ensures that the game object will have
// required components (such as a collider)

using UnityEngine;
using System.Collections;

abstract public class MDPEntity : MonoBehaviour {
	public Collider Collider;

    virtual protected void CheckCollisions() { }
}

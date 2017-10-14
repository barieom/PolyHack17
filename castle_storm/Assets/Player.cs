using System;
using UnityEngine;

public class Player : MonoBehaviour {
	public uint moduleIndex;
	public string uniqueId = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
	public bool isDead = false;
}

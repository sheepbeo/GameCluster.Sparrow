using UnityEngine;
using System.Collections;

public interface IPool {
	void Recycle();
	void Recycle(Transform transform);
}

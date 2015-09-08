using UnityEngine;
using System.Collections;

public interface IEffects
{
	void dealDamage(int damage, Entity target);

	void takeDamage(int damage);
}


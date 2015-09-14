using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;


public class EffectsHandler
{
	Type thisType;

	List<string> drawEffects;
	List<string> inHandEffects;
	List<string> onCastEffects;
	List<string> InPlayEffects;
	List<string> onDestroyEffects;

	Regex r;

	public EffectsHandler (string effects)
	{
		string[] effectsArray = effects.Split ('|');
		if (effectsArray.Length == 5) {
			thisType = typeof(EffectsHandler);
			drawEffects = effectsArray [0].Split ('&').ToList ();
			inHandEffects = effectsArray [1].Split ('&').ToList ();
			onCastEffects = effectsArray [2].Split ('&').ToList ();
			InPlayEffects = effectsArray [3].Split ('&').ToList ();
			onDestroyEffects = effectsArray [4].Split ('&').ToList ();
			r = new Regex ("(\\w+) ?(?:\\((.*)\\))?");
		} else {
			throw new System.ArgumentException("Must have a length of 5.","effects");
		}
	}

	void Invoke (List<string> callEffects)
	{
		List<List<string>>  effects = effectRegMatch (callEffects);
		if (effects.Count == 0) {
			return;
		}
		foreach (List<string> effectAndArgs in effects) {
			if(effectAndArgs[0] == ""){
				return;
			}
			MethodInfo method = thisType.GetMethod (effectAndArgs[0]);
			if(effectAndArgs[1] == ""){
				method.Invoke(this, null);
				return;
			}
			method.Invoke(this, effectAndArgs[1].Split(',') as object[]);
		}
	}

	List<List<string>> effectRegMatch(IList<string> effects){
		List<List<string>> matches = new List<List<string>> ();
		foreach (string effect in effects) {
			if(effect == ""){
				continue;
			}
			List<string> match = new List<string>();
			var callAndArgs = r.Match(effect);
			match.Add(callAndArgs.Groups[1].Value);
			match.Add(callAndArgs.Groups[2].Value);
			matches.Add(match);
		}

		return matches;
	}

	public virtual void Draw(){
		Invoke (drawEffects);
	}
	
	public virtual void InHand(){
		Invoke (inHandEffects);
	}
	
	public virtual void OnCast(){
		Invoke (onCastEffects);
	}
	
	public virtual void InPlay(){
		Invoke (InPlayEffects);
	}
	
	public virtual void OnKill(){
		Invoke (onDestroyEffects);
	}
	
	void dealDamage (int damage, Entity target)
	{
	}

	public void takeDamage ()
	{
		Debug.Log ("took damage!");
	}
}

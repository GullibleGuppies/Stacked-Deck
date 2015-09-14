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

	Card caller;

	Regex effectReg;

	public EffectsHandler (string effects, Card caller)
	{
		string[] effectsArray = effects.Split ('|');
		if (effectsArray.Length == 5) {
			thisType = typeof(EffectsHandler);
			drawEffects = effectsArray [0].Split ('&').ToList ();
			inHandEffects = effectsArray [1].Split ('&').ToList ();
			onCastEffects = effectsArray [2].Split ('&').ToList ();
			InPlayEffects = effectsArray [3].Split ('&').ToList ();
			onDestroyEffects = effectsArray [4].Split ('&').ToList ();
			this.caller = caller;
			effectReg = new Regex ("(\\w+) ?(?:\\((.*)?\\))");
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
			MethodInfo method = thisType.GetMethod (effectAndArgs[0],BindingFlags.NonPublic | BindingFlags.Instance);
			if(effectAndArgs[1] == ""){
				method.Invoke(this, null);
				return;
			} else {
				string[] args = effectAndArgs[1].Split(',');
				object[] proccessedArgs = new object[args.Length];
				for (int i = 0; i < args.Length; i++){
					if(args[i] == "this"){
						proccessedArgs[i] = caller;
					} else if(Regex.IsMatch(args[i],"\\d*")){
						proccessedArgs[i] = Int32.Parse(args[i]);
					} else {
						proccessedArgs[i] = args[i];
					}
				}

				method.Invoke(this, proccessedArgs);
			}
		}
	}

	List<List<string>> effectRegMatch(IList<string> effects){
		List<List<string>> matches = new List<List<string>> ();
		foreach (string effect in effects) {
			if(effect == ""){
				continue;
			}
			List<string> match = new List<string>();
			var callAndArgs = effectReg.Match(effect);
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
	
	void damageEntity (int damage, Entity target){

	}
	void damageHero(int damage, Hero hero){

	}
	
}

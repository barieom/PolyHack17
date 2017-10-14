using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CastleModule;
using Health;

public class Castle : MonoBehaviour {
	public Health castleHealth;

	List<Object> modules;
	List<CastleModule_TopModule> top_mod;
	List<CastleModule_CoreModule> core_mod;
	List<CastleModule_BaseModule> base_mod;

	// Use this for initialization
	void Start () {
		//Build castle on screen
	}
	
	// Update is called once per frame
	void Update () {
		if (castle_health.isDead ()) {
			//Trigger game over sequence
		}
	}

	void movePlayer(Player pl, uint module_index, uint destination_index)
	{

	}

	void swapModule<T>(List<T> module_list, uint module_index, T replacement_module)
	{
		if (module_list [module_index].players.Count == 0) {
			if (!module_list [module_index].onCooldown ()) {
				module_list.RemoveAt (module_index);
				module_list.Insert (module_index, replacement_module);
			} else {
				//Trigger "Module to be replaced is on cooldown." dialogue.
			}
		} else {
			//Trigger "Module to be replaced contains players." dialgoue.
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CastleModule;
using Health;

public class Castle : MonoBehaviour {
	public Health castleHealth;

	List<Object> modules;
	//Behind castle is first, then bottom module, then core modules, then top module.

	void Start () {
		//Build castle on screen with default modules
	}

	void Update () {
		if (castle_health.isDead ()) {
			//Trigger game over sequence
		}
		for (int i = 0; i < modules.Count; i++) {
			modules [i].updateModule ();
		}
	}

	void movePlayer(ref Player pl, uint current_index, uint destination_index)
	{
		modules [current_index].players.Remove (pl.uniqueId);
		modules [current_index].toRemove.Add (pl.uniqueId);
		modules [destination_index].players.Add (pl.uniqueId, &pl);
		pl.moduleIndex = destination_index;
	}

	void swapModule(uint module_index, Object replacement_module)
	{
		if (modules[module_index].players.Count == 0) {
			if (!modules[module_index].onCooldown ()) {
				modules.RemoveAt (module_index);
				modules.Insert (module_index, replacement_module);
			} else {
				//Trigger "Module to be replaced is on cooldown." dialogue.
			}
		} else {
			//Trigger "Module to be replaced contains players." dialgoue.
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CastleModule {
	uint cooldown;
	uint cooldown_start_time = 0;
	uint max_players;
	public Dictionary<string, Player*> players;
	public List<string> toRemove;

	public bool onCooldown()
	{
		if (Time.time - cooldown_start_time > cooldown) {
			return false;
		} else {
			return true;
		}
	}
}

public class CastleModule_ProjectileModule : CastleModule {
	//catapult, oil, archer, ice mage

	public struct moduleType {
		List<Vector2> positions;
	};

	static moduleType thismodule;
	public enum moduleTypes {catapult, oil, archer, icemage};
	moduleTypes mType;
	public void createProjectile(/*id of Player Spawning Proj & Speed Vector*/)
	{
		if (mType == moduleTypes.catapult) {
			//spawn stone
		} else if (mType == moduleTypes.oil) {
			//spawn oil projectile
		} else if (mType == moduleTypes.archer) {
			//spawn arrow
		} else if (mType == moduleTypes.icemage) {
			//spawn ice bolt
		}
		/* 
		 * spawn projectile at location with speed vector & 
		 * define physics behavior based on type of projectile
		 */
	}

	public void updateModule()
	{
		for(int i = 0; i < players.Keys.Count; i++) {
			GameObject player = GameObject.FindGameObjectWithTag(players.Keys[i]);

		}

		for (int i = 0; i < toRemove.Count; i++) {
			toRemove.RemoveAt (0);
		}
	}
}

public class CastleModule_BaseModule : CastleModule {
    //melee    
	public void updateModule()
	{				
		for (int i = 0; i < players.Keys.Count; i++) {
			GameObject player = GameObject.FindGameObjectWithTag(players.Keys[i]);
			if(player == null && !players.Values[i]->isDead){
				/* Create game object, set id to players.Values[i]->uniqueId, set position
				 * to right outside the castle
				 */
			}
		}

		for (int i = 0; i < toRemove.Count; i++) {
			GameObject.Destroy(GameObject.FindGameObjectWithTag (toRemove [0]));
			toRemove.RemoveAt (0);
		} 
	}
}


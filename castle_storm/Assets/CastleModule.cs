using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CastleModule {
	static uint max_players;
	public Dictionary<string, Player*> players;
	public List<string> toRemove;
}
	
class CastleModule_ProjectileModule : CastleModule {
	//catapult, oil, archer, ice mage
	uint cooldown;
	uint cooldown_start_time = 0;
	public bool onCooldown()
	{
		if (Time.time - cooldown_start_time > cooldown) {
			return false;
		} else {
			return true;
		}
	}

	public enum moduleTypes {catapult, oil, archer, icemage};
	static moduleTypes mType;
	static List<Vector2> positions;
	GameObject projectile;

	public void updateModule()
	{
		for(int i = 0; i < players.Keys.Count; i++) {
			GameObject player = GameObject.FindGameObjectWithTag(players.Keys[i]);

		}

		for (int i = 0; i < toRemove.Count; i++) {
			toRemove.RemoveAt (0);
		}
	}
	public void createProjectile(string player_id, Vector2 speed_vector)
	{
		cooldown_start_time = Time.time;
		GameObject projectile_instance = GameObject.Instantiate (projectile);
		projectile_instance.transform.position = positions [0];
		projectile_instance.GetComponent(Rigidbody2D).velocity = speed_vector;
	}
}

public class CastleModule_ProjectileModule_Catapult : CastleModule_ProjectileModule {
	static uint cooldown = 1;
	static uint max_players = 1;
	static moduleTypes mType = moduleTypes.catapult;
	static List<Vector2> positions = new List<Vector2>() {
		new Vector2(-1.25, -.5)
	};
	GameObject projectile = Resources.Load ("Stone") as GameObject;
}

public class CastleModule_ProjectileModule_Oil : CastleModule_ProjectileModule {
	static uint cooldown = 1;
	static uint max_players = 1;
	static moduleTypes mType = moduleTypes.oil;
	static List<Vector2> positions = new List<Vector2>() {
		new Vector2(-1.25, -.5)
	};
	GameObject projectile = Resources.Load ("Oil") as GameObject;
}

public class CastleModule_ProjectileModule_Archer : CastleModule_ProjectileModule {
	static uint cooldown = 1;
	static uint max_players = 2;
	static moduleTypes mType = moduleTypes.archer;
	static List<Vector2> positions = new List<Vector2>() {
		new Vector2(-1.25, -.5),
		new Vector2(1.5, -.5)
	};
	GameObject projectile = Resources.Load ("Arrow") as GameObject;
}

public class CastleModule_ProjectileModule_Icemage : CastleModule_ProjectileModule {
	static uint max_players = 2;
	static moduleTypes mType = moduleTypes.icemage;
	static List<Vector2> positions = new List<Vector2>() {
		new Vector2(-1.25, -.5),
		new Vector2(1.5, -.5)
	};
	GameObject projectile = Resources.Load ("Icebolt") as GameObject;
}

public class CastleModule_BaseModule : CastleModule {
    //melee
	static uint max_players = 4;
	GameObject sword_player = Resources.Load("Sword Player") as GameObject;
	public void updateModule()
	{
		for (int i = 0; i < players.Keys.Count; i++) {
			GameObject player = GameObject.FindGameObjectWithTag(players.Keys[i]);
			if(player == null && !players.Values[i]->isDead){
				GameObject player_instance = GameObject.Instantiate (sword_player);
				player_instance.transform.position = new Vector2 (.15,-1.5);
				player_instance.tag = players.Values [i]->uniqueId;
			}
		}

		for (int i = 0; i < toRemove.Count; i++) {
			GameObject.Destroy(GameObject.FindGameObjectWithTag (toRemove [0]));
			toRemove.RemoveAt (0);
		} 
	}
}


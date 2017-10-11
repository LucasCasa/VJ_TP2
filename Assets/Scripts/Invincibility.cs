using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUp {

	public float shield_duration = 10;

	public override void Effect(Player player){
		player.shield = true;
		player.shieldDuration = shield_duration;
		player.totalShieldDuration = shield_duration;
		Destroy (gameObject);
	}
}

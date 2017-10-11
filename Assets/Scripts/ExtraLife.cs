using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : PowerUp {

	public override void Effect(Player player){
		player.life++;
		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

namespace unitygames.leveldesign.game {
	
	public class GameBootstrap : ContextView {

		void Awake () {
			//Instantiate the context, passing it this instance.
			context = new GameContext (this);
		}

	}

}
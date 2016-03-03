﻿using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace unitygames.leveldesign.game {
	
	public class GameBootstrap : ContextView {

		void Awake () {
			//Instantiate the context, passing it this instance.
			context = new GameContext (this);
		}

	}

}
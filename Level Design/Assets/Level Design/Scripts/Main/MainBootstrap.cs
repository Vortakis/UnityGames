using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace unitygames.leveldesign.main {
	
	public class MainBootstrap : ContextView {

		void Awake () {
			//Instantiate the context, passing it this instance.
			context = new MainContext (this);
		}

	}

}
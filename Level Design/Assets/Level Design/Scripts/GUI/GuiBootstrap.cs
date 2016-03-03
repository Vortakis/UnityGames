using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace unitygames.leveldesign.gui {
	
	public class GuiBootstrap : ContextView {

		void Awake () {
			//Instantiate the context, passing it this instance.
			context = new GuiContext (this);
		}

	}

}
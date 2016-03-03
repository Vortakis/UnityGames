using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

namespace unitygames.leveldesign.gui {
	
	public class StartGuiCommand : Command {

		[Inject (ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{ get; set; }

		public override void Execute () {

		}
	}
}

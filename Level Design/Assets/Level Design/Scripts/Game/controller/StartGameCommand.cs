using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

namespace unitygames.leveldesign.game {
	
	public class StartGameCommand : Command {

		[Inject (ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{ get; set; }

		public override void Execute () {

		}
	}
}

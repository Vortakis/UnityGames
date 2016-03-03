using UnityEngine;
using System.Collections;

namespace unitygames.leveldesign.gui {

	public class GuiContext : SignalContext {

		public GuiContext (MonoBehaviour contextView) : base (contextView) {
		}

		/*
		 * Override to map project-specific bindings.
		 */
		protected override void mapBindings () {

			base.mapBindings ();

			//StartSignal is now fired instead of the START event.
			//Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
			commandBinder.Bind<StartSignal> ().To<StartGuiCommand> ().Once ();

		}
			
	}
}

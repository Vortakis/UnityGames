﻿using System;
using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;


namespace unitygames.leveldesign {
	
	public class SignalsContext : MVCSContext {

		/*
		 * Constructor. 
		 */
		public SignalsContext (MonoBehaviour view) : base (view) {
		}

		/* 
		 * Unbind the default EventCommandBinder and rebind the SignalCommandBinder.
		 */
		protected override void addCoreComponents () {
			base.addCoreComponents ();
			injectionBinder.Unbind<ICommandBinder> ();
			injectionBinder.Bind<ICommandBinder> ().To<SignalCommandBinder> ().ToSingleton ();
		}

		/*
		 * First ContextEvent.START. Whatever Command/Sequence you want to happen first should be mapped to this event.
		 */
		public override void Launch () {
			base.Launch ();

			// Get StartSignal instance.
			StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal> ();
			// Dispatch signal.
			startSignal.Dispatch ();
		}

		/*
		 * Override to map project-specific bindings.
		 */
		protected override void mapBindings () {

			base.mapBindings ();

			//StartSignal is now fired instead of the START event.
			//Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
			commandBinder.Bind<StartSignal> ().To<StartCommand> ().Once ();

		}


	}
}

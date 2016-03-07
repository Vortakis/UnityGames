namespace unitygames.leveldesign {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.IOC;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UniRx;
    
    
    public class BobPlayerController : BobPlayerControllerBase {
        
        public override void InitializeBobPlayer(BobPlayerViewModel viewModel) {
            base.InitializeBobPlayer(viewModel);
            // This is called when a BobPlayerViewModel is created
        }
    }
}

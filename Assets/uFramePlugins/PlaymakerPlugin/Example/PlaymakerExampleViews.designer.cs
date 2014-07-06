// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using HutongGames.PlayMaker;
using UnityEngine;


[DiagramInfoAttribute("PlaymakerExample")]
public abstract class PlaymakerElementViewBase : ViewBase {
    
    [UFToggleGroup("State")]
    [UnityEngine.HideInInspector()]
    public bool _BindState;
    
    [UFToggleGroup("UpgradeCompleteTime")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("UpgradeCompleteTimeChanged")]
    public bool _BindUpgradeCompleteTime;
    
    [UFToggleGroup("CurrentLevel")]
    [UnityEngine.HideInInspector()]
    public bool _BindCurrentLevel;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public PlaymakerElementState _State;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public System.DateTime _UpgradeCompleteTime;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public int _CurrentLevel;
    
    [UnityEngine.SerializeField()]
    private PlayMakerFSM[] _FSMS;
    
    private HutongGames.PlayMaker.FsmString[] _FsmState;
    
    private HutongGames.PlayMaker.FsmInt[] _FsmCurrentLevel;
    
    public override System.Type ViewModelType {
        get {
            return typeof(PlaymakerElementViewModel);
        }
    }
    
    public override bool IsMultiInstance {
        get {
            return true;
        }
    }
    
    public PlaymakerElementViewModel PlaymakerElement {
        get {
            return ((PlaymakerElementViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public virtual PlayMakerFSM[] FSMS {
        get {
            if (_FSMS == null || _FSMS.Length < 1) {
                this._FSMS = this.GetComponents<PlayMakerFSM>();
            }
            return this._FSMS;
        }
    }
    
    public virtual HutongGames.PlayMaker.FsmString[] FsmState {
        get {
            if ((this._FsmState == null)) {
                this._FsmState = FSMS.GetVariables<FsmString>((fsm) => fsm.FsmVariables.FindFsmString("State")).ToArray();
            }
            return this._FsmState;
        }
    }
    
    public virtual HutongGames.PlayMaker.FsmInt[] FsmCurrentLevel {
        get {
            if ((this._FsmCurrentLevel == null)) {
                this._FsmCurrentLevel = FSMS.GetVariables<FsmInt>((fsm) => fsm.FsmVariables.FindFsmInt("CurrentLevel")).ToArray();
            }
            return this._FsmCurrentLevel;
        }
    }
    
    public virtual void StateChanged(PlaymakerElementState value) {
        if ((this.FsmState == null)) {
        }
        else {
            FsmState.Each(v=>v.Value = value.ToString());
        }
        FSMS.Each(f=>f.Fsm.Event("StateChanged"));
    }
    
    public virtual void UpgradeCompleteTimeChanged(System.DateTime value) {
    }
    
    public virtual void CurrentLevelChanged(int value) {
        if ((this.FsmCurrentLevel == null)) {
        }
        else {
            FsmCurrentLevel.Each(v=>v.Value = value);
        }
        FSMS.Each(f=>f.Fsm.Event("CurrentLevelChanged"));
    }
    
    public override void Bind() {
        if (this._BindState) {
            this.BindProperty(()=>PlaymakerElement._StateProperty, this.StateChanged);
        }
        if (this._BindUpgradeCompleteTime) {
            this.BindProperty(()=>PlaymakerElement._UpgradeCompleteTimeProperty, this.UpgradeCompleteTimeChanged);
        }
        if (this._BindCurrentLevel) {
            this.BindProperty(()=>PlaymakerElement._CurrentLevelProperty, this.CurrentLevelChanged);
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<PlaymakerElementController>());
    }
    
    public virtual void ExecuteUpgrade() {
        this.ExecuteCommand(PlaymakerElement.Upgrade);
    }
    
    public virtual void ExecuteKill() {
        this.ExecuteCommand(PlaymakerElement.Kill);
    }
    
    public virtual void ExecuteTick() {
        this.ExecuteCommand(PlaymakerElement.Tick);
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        PlaymakerElementViewModel playmakerElement = ((PlaymakerElementViewModel)(viewModel));
        playmakerElement.State = this._State;
        playmakerElement.UpgradeCompleteTime = this._UpgradeCompleteTime;
        playmakerElement.CurrentLevel = this._CurrentLevel;
    }
}

public partial class PlaymakerView : PlaymakerElementViewBase {
}
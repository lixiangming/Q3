using System;
using GameFramework.Fsm;
using UniRx;
using UnityGameFramework.Runtime;
using PlayerOwner = GameFramework.Fsm.IFsm<GamePlay.Player>;

namespace GamePlay
{
    public class PlayerStateBanker : PlayerStateBase
    {
        protected override void OnInit(GameFramework.Fsm.IFsm<Player> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnEnter(GameFramework.Fsm.IFsm<Player> fsm)
        {
            base.OnEnter(fsm);
            fsm.Owner.OnBid();
            Log.Debug("进入抢庄");
        }

        protected override void OnUpdate(GameFramework.Fsm.IFsm<Player> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            if (fsm.Owner.state == EPlayerState.Bet)
            {
                ChangeState<PlayerStateBet>(fsm);
            }
        }

        protected override void OnLeave(GameFramework.Fsm.IFsm<Player> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        protected override void OnDestroy(GameFramework.Fsm.IFsm<Player> fsm)
        {
            base.OnDestroy(fsm);
        }
    } 
}


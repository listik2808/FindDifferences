namespace Scripts.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }

    public interface IPayLoadState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IPayLoadStateLevel<TPayLoad, TPayLoadInt> : IExitableState 
    {
        void Enter(TPayLoad payLoad, TPayLoadInt payLoadInt);
    }

}
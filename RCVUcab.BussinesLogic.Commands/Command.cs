namespace RCVUcab.BussinesLogic.Commands
{
    public abstract class Command<TOut> : ICommand<TOut>
    {
        private TOut _result;

        public abstract void Execute();

        protected void SetResult(TOut result)
        {
            _result = result;
        }

        public TOut GetResult()
        {
            return _result;
        }
    }
}


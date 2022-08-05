using System;
namespace RCVUcab.BussinesLogic.Commands
{
    public abstract class Command<TOut> : ICommand<TOut>
    {
        public abstract void Execute();

        public abstract List<TOut> GetResult();
    }
}


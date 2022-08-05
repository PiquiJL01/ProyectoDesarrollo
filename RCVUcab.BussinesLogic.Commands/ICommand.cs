using System;
namespace RCVUcab.BussinesLogic.Commands
{
    public interface ICommand<TOut>
    {
        void Execute();
        List<TOut> GetResult();
    }
}


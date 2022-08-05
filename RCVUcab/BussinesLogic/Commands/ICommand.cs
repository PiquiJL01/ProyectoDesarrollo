namespace RCVUcab.BussinesLogic.Commands;

public interface ICommand<TOut>
{
    void Execute();
    TOut GetResult();
}
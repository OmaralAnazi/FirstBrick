namespace FirstBrick.Interfaces;

public interface IEventHandler<TEvent>
{
    Task HandleAsync(TEvent eventMessage);
}

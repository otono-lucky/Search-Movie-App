using MediatR;

namespace Movie_App.Search.Command
{
    public class SaveLatestSearchCommand : IRequest<int>
    {
        public string Query { get; set; }
    }
}

using Zenject;

namespace _Project.Codebase.Core.Line
{
    public class LineViewModel
    {
        private readonly ILineView _view;

        [Inject]
        public LineViewModel(ILineView view)
        {
            _view = view;
        }
    }
}
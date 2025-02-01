using System;
using UniRx;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public class HealthViewModel : IHealthViewModel, IDisposable
	{
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly IHealthModel _model;
		private readonly IHealthView _view;
		private readonly IHealthHitBox _hitBox;

		private ReactiveProperty<string> _label = new();
		private ReactiveProperty<int> _max = new();
		private ReactiveProperty<int> _current = new();

		public HealthViewModel(IHealthModel model, IHealthView view, IHealthHitBox hitBox)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_hitBox = hitBox ?? throw new ArgumentNullException(nameof(hitBox));

			Bind();
		}
		
		public void Dispose()
		{
			_compositeDisposable?.Dispose();
		}

		private void Bind()
		{
			_model.Label
				.Subscribe(label => _label.Value = label)
				.AddTo(_compositeDisposable);

			_model.Max
				.Subscribe(max => _max.Value = max)
				.AddTo(_compositeDisposable);

			_model.Current
				.Subscribe(current => _current.Value = current)
				.AddTo(_compositeDisposable);

			_label
				.Subscribe(label => OnViewModelChanged(label, _current.Value, _max.Value))
				.AddTo(_compositeDisposable);

			_current
				.Subscribe(current => OnViewModelChanged(_label.Value, current, _max.Value))
				.AddTo(_compositeDisposable);
			
			_max.Subscribe(max => OnViewModelChanged(_label.Value, _current.Value, max))
				.AddTo(_compositeDisposable);

			_hitBox.TakeDamageRequested
				.Subscribe(OnTakeDamageRequested)
				.AddTo(_compositeDisposable);
		}

		private void OnTakeDamageRequested(int damage)
		{
			if (damage <= 0)
				throw new ArgumentOutOfRangeException(nameof(damage));
			
			throw new NotImplementedException();
		}

		private void OnViewModelChanged(string label, int current, int max)
		{
			if (current < 0)
				throw new ArgumentOutOfRangeException(nameof(current));
			if (max <= 0)
				throw new ArgumentOutOfRangeException(nameof(max));
			
			_view.Redraw(label, current.ToString(), max.ToString());
		}
	}
}
using ReactiveUI;
using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaTest
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string _text;
        private int _count = 0;

        public MainWindowViewModel()
        {
            ActionButton = ReactiveCommand.Create(RunActionButton);
            Text = "Value = " + _count;
            Task.Run(() => Incerement());
        }

        private void Incerement()
        {
            while (true)

            {
                _count++;

                Text = "Value = " + _count;

                Thread.Sleep(1000);
            }
        }


        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }

        public ReactiveCommand<Unit, Unit> ActionButton { get; }

        void RunActionButton()
        {
            _count = 0;
        }
    }
}

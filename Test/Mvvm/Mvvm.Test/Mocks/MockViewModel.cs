using System.Collections.ObjectModel;

namespace Mvvm.Test.Mocks
{
    public class MockViewModel : Kinugasa.Mvvm.BindableBase
    {
        private int _mockInt;

        public int MockInt
        {
            get { return this._mockInt; }
            set
            {
                this.SetProperty(ref this._mockInt, value);
            }
        }

        private string _mockString;

        public string MockString
        {
            get { return this._mockString; }
            set
            {
                this.SetProperty(ref this._mockString, value);
            }
        }

        private object MockProperty { get; set; }

        private ObservableCollection<Mocks.MockModel> _mockObservalCollection = new ObservableCollection<MockModel>();

        public ObservableCollection<Mocks.MockModel> MockObservalCollection
        {
            get { return this._mockObservalCollection; }
            set
            {
                this.SetProperty(ref this._mockObservalCollection, value);
            }
        }

        internal void InvokeOnPropertyChanged()
        {
            this.OnPropertyChanged(nameof(this.MockProperty));
        }
    }
}

# Mvvm

Kinugasa.Mvvm is minimum MVVM library.

# BindableBase

BindableBase class is implemented INotifyPropertyChanged and provide notification when propertie's value change.

## Usaga

```cs
public class MockViewModel : Kinugasa.Mvvm.BindableBase
{
    private int _sampleInt;

    public int SampleProperty
    {
            get { return this._sampleInt; }
            set
            {
                this.SetProperty(ref this._sampleInt, value);
            }
    }
```

# DelegateCommand

Delegate command class are provide whoes command can execute or not.

## Usaga

Can input null to constrcture, if no need to check that command can execute or not.
```cs
var command = new Kinugasa.Mvvm.DelegateCommand(null);
```

Please input whose method if you need check that command can execute or not.
```cs
var command = new Kinugasa.Mvvm.DelegateCommand(Method, CheckMethod);
```

You can input one argument method.
```cs
var command = new Kinugasa.Mvvm.DelegateCommand<int>(HasArgumentMethod, null);
```
```cs
var command = new Kinugasa.Mvvm.DelegateCommand<int>(HasArgumentMethod, CheckMethod);
```
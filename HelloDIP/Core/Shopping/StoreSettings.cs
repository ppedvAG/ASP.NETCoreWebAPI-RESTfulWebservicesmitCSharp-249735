namespace HelloDIP.Core.Shopping;

public class StoreSettings
{
    public string Foo { get; }

    public StoreSettings()
    {
        Foo = $"Bar Hash: [{GetHashCode()}]";
    }
}
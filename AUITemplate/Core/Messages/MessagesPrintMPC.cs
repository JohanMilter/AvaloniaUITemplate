using AUITemplate.Core.Fails;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AUITemplate.Core.Messages;

public class FailMessage : ValueChangedMessage<FailItem>
{
    //Add interface: IRecipient<FailMessage>
    //Instanciate in constructer: WeakReferenceMessenger.Default.Register<FailMessage>(this);
    //Send Message: WeakReferenceMessenger.Default.Send(new FailMessage(FailItem));
    public FailMessage(FailItem value) : base(value)
    {
    }
}
namespace RemoteLearning.VendingMachine.Payment
{
    public interface IPaymentAlgorithm
    {
        string Name { get; }
        public abstract void Run(float price);
    }
}

namespace RemoteLearning.VendingMachine.UseCases

{
    public interface IPaymentUseCase
    {
        public void Execute(float price);
    }
}

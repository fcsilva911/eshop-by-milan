namespace Domain.Costumers
{
    public interface ICostumerRepository
    {
        Task<Costumer?> GetByIdAsync(CostumerId id);

        Task<bool> IsEmailUniqueAsync(string email);

        void Add(Costumer costumer);
    }
}

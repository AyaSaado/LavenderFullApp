namespace Lavender.Core.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IDesignSectionRepository DesignSections { get; }
        IMakerSectionRepository MakerSections { get; }
        IProductionEmpRepository ProductionEmps { get; } 
        IPatternMakerRepository PatternMakers { get; }
        IOrderRepository Orders { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;


namespace Lavender.Infrastructure.Repository
{
 
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context, UserManager<User> userManager )
        {
            _context = context;
            Users = new UserRepository(userManager, context);
            DesignSections = new DesignSectionRepository(context);
            MakerSections = new MakerSectionRepository(context);
            ProductionEmps = new ProductionEmpRepository(context);
            PatternMakers = new PatternMakerRepository(context);    
        }

        public IUserRepository Users {  get; private set; }
        public IDesignSectionRepository DesignSections { get; private set; }
        public IMakerSectionRepository MakerSections { get; private set; }
        public IProductionEmpRepository ProductionEmps { get; private set; }
        public IPatternMakerRepository PatternMakers { get; private set; }

        public async void Dispose()
        {
           await _context.DisposeAsync();
        }
   
        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

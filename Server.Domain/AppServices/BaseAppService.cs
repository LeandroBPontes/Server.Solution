using Server.Domain.Contracts.UnitOfWork;

namespace Server.Domain.AppServices;

    public class BaseAppService
    {
        private readonly IUnitOfWork _uow;

        public BaseAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected async Task<bool> CommitAsync()
        {
            if (await _uow.SaveChangesAsync() > 0) return true;
            
            
            return false;
        }
    }

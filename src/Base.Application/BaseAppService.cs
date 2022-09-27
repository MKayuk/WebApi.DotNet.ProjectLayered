using MassTransit;
using Base.Application.Adapter;
using Base.Application.Interface;
using Base.Application.ViewModel;
using Util.Notification;
using System;
using System.Threading.Tasks;

namespace Base.Application
{
    public class BaseAppService : IBaseAppService
    {
        private readonly Notify _notify;

        public BaseAppService(INotify notify)
        {
            _notify = notify.Invoke();
        }

        public async Task<BaseView> GetDataById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseView> GetDataByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseView> InsertAsync(BasePost viewModel)
        {
            var entity = viewModel.ToEntity();

            throw new NotImplementedException();
        }
    }
}

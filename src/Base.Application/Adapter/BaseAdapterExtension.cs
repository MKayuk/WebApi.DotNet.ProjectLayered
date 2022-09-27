using Base.Application.ViewModel;
using System;

namespace Base.Application.Adapter
{
    public static class BaseAdapterExtension
    {
        public static BaseView ToView(this Core.Aggregate.Base Core)
        {
            if (Core is null)
                return null;

            var result = new BaseView()
            {
                Id = Core.Id,
                Cpf = Core.Cpf
            };

            return result;
        }

        public static Core.Aggregate.Base ToEntity(this BasePost viewModel)
        {
            if (viewModel is null)
                throw new ArgumentException($"Invalid argument {nameof(viewModel)}.");

            var result = new Core.Aggregate.Base(viewModel.Cpf);

            return result;
        }
    }
}

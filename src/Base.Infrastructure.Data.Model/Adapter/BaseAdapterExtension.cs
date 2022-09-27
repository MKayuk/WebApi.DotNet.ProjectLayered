using System;

namespace Base.Infrastructure.Data.Model.Adapter
{
    public static class BaseAdapterExtension
    {
        public static Model.Base ToDataModel(this Core.Aggregate.Base Core)
        {
            if (Core is null)
                return null;

            var result = new Model.Base()
            {
                Id = Core.Id,
                Cpf = Core.Cpf
            };

            return result;
        }

        public static Core.Aggregate.Base ToEntity(this Model.Base dataModel)
        {
            if (dataModel is null)
                throw new ArgumentException($"Invalid argument {nameof(dataModel)}.");

            var result = new Core.Aggregate.Base(dataModel.Id, dataModel.Cpf);

            return result;
        }
    }
}

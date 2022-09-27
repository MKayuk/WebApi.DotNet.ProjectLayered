using Base.Application.ViewModel;
using System.Threading.Tasks;

namespace Base.Application.Interface
{
    public interface IBaseAppService
    {
        /// <summary>
        /// Get information by id.
        /// </summary>
        /// <param name="id">Information's reference id.</param>
        /// <returns>Information required.</returns>
        Task<BaseView> GetDataById(string id);

        /// <summary>
        /// Get information by CPF (personal document).
        /// </summary>
        /// <param name="cpf">CPF (personal document).</param>
        /// <returns>Information required.</returns>
        Task<BaseView> GetDataByCpf(string cpf);

        /// <summary>
        /// Insert new information.
        /// </summary>
        /// <param name="baseData">Data to be registered.</param>
        /// <returns>Information registered.</returns>
        Task<BaseView> InsertAsync(BasePost baseData);
    }
}

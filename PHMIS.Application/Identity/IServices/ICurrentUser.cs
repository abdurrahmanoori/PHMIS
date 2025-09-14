
namespace PHMIS.Application.Identity.IServices
{
    public interface ICurrentUser
    {
        int GetUserId();
        /// <summary>
        /// Retrieves the HospitalId from current user.    
        /// </summary>
        /// <returns>An integer representing the hospital's unique identifier.</returns>
        int GetHospitalId();

    }
}

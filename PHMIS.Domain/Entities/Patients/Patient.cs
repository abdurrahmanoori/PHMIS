using PHMIS.Domain.Common.BaseAbstract;
using PHMIS.Domain.Entities.Patients;

namespace PHMIS.Domain.Entities.Patients;

public class Patient : BaseEntity
{
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public int HospitalId { get; set; }

    public Hospital? Hospital { get; set; }

    public ICollection<PatientLabTest> PatientLabTests { get; set; } = new List<PatientLabTest>();
}
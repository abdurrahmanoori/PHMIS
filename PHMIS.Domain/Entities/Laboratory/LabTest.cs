using PHMIS.Domain.Common.BaseAbstract;
using PHMIS.Domain.Entities.Patients;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHMIS.Domain.Entities.Laboratory
{
    public class LabTest : BaseEntity
    {
        public string? Description { get; set; }
        public int? Price { get; set; }
        public bool IsActive { get; set; } = true;
        public int LabTestGroupId { get; set; }

        // New fields
        public string? UnitOfMeasurment { get; set; }
        public string? NormalRange { get; set; }
        public string? Abbreviation { get; set; }

        [ForeignKey(nameof(LabTestGroupId))]
        public LabTestGroup LabTestGroup { get; set; }

        public ICollection<PatientLabTest> PatientLabTests { get; set; } = new List<PatientLabTest>();
    }
}

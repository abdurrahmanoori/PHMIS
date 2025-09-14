using PHMIS.Application.DTO.Patients;

namespace PHMIS.Test.Builders;

public class PatientBuilder
{
    private string _name = "Test";
    private string _lastName = "User";
    private DateTime _dateOfBirth = new DateTime(1995, 1, 1);
    private string _gender = "Male";
    private string _phoneNumber = "123456789";
    private string _email = $"user_{Guid.NewGuid():N}@test.local";
    private string _address = "123 Test Street";
    private int _hospitalId = 1;

    public PatientBuilder WithFirstName(string firstName)
    {
        _name = firstName;
        return this;
    }

    public PatientBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public PatientBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public PatientBuilder WithDateOfBirth(DateTime dateOfBirth)
    {
        _dateOfBirth = dateOfBirth;
        return this;
    }

    public PatientBuilder WithHospitalId(int hospitalId)
    {
        _hospitalId = hospitalId;
        return this;
    }

    public PatientCreateDto BuildCreateDto() => new()
    {
        Name = _name,
        LastName = _lastName,
        DateOfBirth = _dateOfBirth,
        Gender = _gender,
        PhoneNumber = _phoneNumber,
        Email = _email,
        Address = _address,
        HospitalId = _hospitalId
    };

    public static PatientCreateDto CreateValidPatient() => new PatientBuilder().BuildCreateDto();
}

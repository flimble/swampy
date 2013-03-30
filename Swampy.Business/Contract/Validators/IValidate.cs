namespace Swampy.Business.Contract.Validators
{
    /// <summary>
    /// Interface for validating text of an entity
    /// </summary>
    public interface IValidate
    {
        bool IsValid(string toValidate);
    }
}

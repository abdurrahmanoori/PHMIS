namespace PHMIS.Domain.Common.Interfaces
{
    // Marker interface for entities that have localized translations
    public interface IHasTranslations<TTranslation>
    {
        ICollection<TTranslation> Translations { get; set; }
    }
}

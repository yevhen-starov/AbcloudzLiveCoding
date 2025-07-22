namespace Abcloudz.Models.Interfaces
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public interface ICreatable
    {
        DateTime CreatedDate { get; set; }
    }

    public interface IUpdatable
    {
        DateTime? UpdatedDate { get; set; }
    }
}

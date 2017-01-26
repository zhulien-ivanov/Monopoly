namespace Monopoly.Models.Contracts.Players
{
    public interface IBank : IParticipant
    {
        int HousesCount { get; set; }

        int HotelsCount { get; set; }
    }
}

using Adesso.Models.Dto;

namespace Adesso.Business {
    public interface IWorldLeagueOperation {
        List<GroupDto> SetGroup(string fullName, int groupNumber);
    }
}

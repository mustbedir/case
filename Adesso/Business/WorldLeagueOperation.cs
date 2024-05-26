using Adesso.Dao;
using Adesso.Models;
using Adesso.Models.Dto;
using System.Data;

namespace Adesso.Business {
    public class WorldLeagueOperation : IWorldLeagueOperation {
        private readonly ICountryDao countryDao;
        private readonly IDrawGroupDao drawGroupDao;

        public WorldLeagueOperation(ICountryDao _countryDao, IDrawGroupDao _drawGroupDao) {
            countryDao = _countryDao;
            drawGroupDao = _drawGroupDao;
        }
        public List<GroupDto> SetGroup(string fullName, int groupNumber) {
            if (groupNumber is not 4 and not 8) {
                throw new Exception("Group Number Error");
            }
            List<GroupDto> dtos = new List<GroupDto>();
            List<GroupTeam> groupTeams = new List<GroupTeam>();
            var countries = countryDao.GetAll();
            
            int totalGroup = groupNumber == 4 ? 8 : 4;

            int firstIndex = 0;

            for (int i = 0; i < groupNumber; i++) {
                GroupDto response = new() {
                    Teams = [],
                    GroupName = (i + 1).ToString()
                };

                for (int j = firstIndex; j<totalGroup; j++) {
                    var country = countries[j];
                    if (!country.Teams.Any()) {
                        firstIndex += totalGroup;
                        totalGroup += totalGroup;
                        j = firstIndex;
                        country = countries[firstIndex];
                    }
                    var countryTeams = country.Teams.Select(t => t.Name);

                    Random rand = new Random();
                    int randomIndex = rand.Next(0, countryTeams.Count());
                    string randomValue = countryTeams.ElementAt(randomIndex);

                    TeamDto teamDto = new TeamDto();
                    teamDto.Name = randomValue;
                    response.Teams.Add(teamDto);

                    GroupTeam groupTeam = new GroupTeam {
                        Name = randomValue
                    };
                    groupTeams.Add(groupTeam);

                    countries[j].Teams.Remove(country.Teams.FirstOrDefault(t => t.Name == teamDto.Name));
                }

                dtos.Add(response);
                
            }

            foreach (var item in dtos) {
                Draw draw = new Draw {
                    FullName = fullName
                };
                Group group = new Group {
                    Name = item.GroupName,
                };

                DrawGroup d = new DrawGroup {
                    Draw = draw,
                };

                drawGroupDao.Save(d);
            }

            return dtos;
        }
    }
}

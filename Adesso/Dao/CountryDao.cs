using Adesso.Models;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Dao {
    public class CountryDao : ICountryDao{
        private readonly AdessoContext adessoContext;
        public CountryDao(AdessoContext _adessoContext) {
            adessoContext = _adessoContext;
        }

        public List<Country> GetAll() {
            return adessoContext.Countries.Include(c => c.Teams).ToList();
        }
    }
}

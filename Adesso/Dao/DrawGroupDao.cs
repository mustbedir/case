using Adesso.Models;

namespace Adesso.Dao {
    public class DrawGroupDao : IDrawGroupDao {
        private readonly AdessoContext adessoContext;

        public DrawGroupDao(AdessoContext _adessoContext) {
            adessoContext = _adessoContext;
        }
        public void Save(DrawGroup drawGroup) {
            adessoContext.DrawGroups.Add(drawGroup);
            adessoContext.SaveChanges();
        }
    }
}

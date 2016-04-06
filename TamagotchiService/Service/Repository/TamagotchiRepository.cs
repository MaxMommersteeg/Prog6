using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TamagotchiService.Model;
using System.Data.Entity;

namespace TamagotchiService.Repository {
    public class TamagotchiRepository : IRepository<Tamagotchi> {

        protected readonly Context _context;

        public TamagotchiRepository(Context context) {
            _context = context;
        }

        public void Add(Tamagotchi entity) {
            _context.Set<Tamagotchi>().Add(entity);
        }

        public void AddOrUpdate(Tamagotchi entity) {
            _context.Set<Tamagotchi>().AddOrUpdate(entity);
        }

        public void AddRange(IEnumerable<Tamagotchi> entities) {
            _context.Set<Tamagotchi>().AddRange(entities);
        }

        public IEnumerable<Tamagotchi> Find(Expression<Func<Tamagotchi, bool>> predicate) {
            return _context.Set<Tamagotchi>()
                .Include(x => x.Player)
                .Where(predicate);
        }

        public Tamagotchi Get(int id) {
            return _context.Set<Tamagotchi>().Where(x => x.TamagotchiId == id)
                .Include(x => x.Player)
                .FirstOrDefault();
        }

        public IEnumerable<Tamagotchi> GetAll() {
            return _context.Set<Tamagotchi>()
                .Include(x => x.Player)
                .ToList();
        }

        public void Remove(Tamagotchi entity) {
            _context.Set<Tamagotchi>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Tamagotchi> entities) {
            _context.Set<Tamagotchi>().RemoveRange(entities);
        }
    }
}
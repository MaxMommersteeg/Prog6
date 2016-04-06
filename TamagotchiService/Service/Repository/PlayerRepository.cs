using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TamagotchiService.Model;
using System.Data.Entity;

namespace TamagotchiService.Repository {
    public class PlayerRepository : IRepository<Player> {

        protected readonly Context _context;

        public PlayerRepository(Context context) {
            _context = context;
        }

        public void Add(Player entity) {
            _context.Set<Player>().Add(entity);
        }

        public void AddOrUpdate(Player entity) {
            _context.Set<Player>().AddOrUpdate(entity);
        }

        public void AddRange(IEnumerable<Player> entities) {
            _context.Set<Player>().AddRange(entities);
        }

        public IEnumerable<Player> Find(Expression<Func<Player, bool>> predicate) {
            return _context.Set<Player>()
                .Include(x => x.Tamagotchies)
                .Where(predicate);
        }

        public Player Get(int id) {
            return _context.Set<Player>()
                .Include(x => x.Tamagotchies)
                .Where(x => x.PlayerId == id)
                .FirstOrDefault();
        }

        public IEnumerable<Player> GetAll() {
            return _context.Set<Player>()
                .Include(x => x.Tamagotchies)
                .ToList();
        }

        public void Remove(Player entity) {
            _context.Set<Player>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Player> entities) {
            _context.Set<Player>().RemoveRange(entities);
        }
    }
}